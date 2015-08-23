using HXF.WebServices.Descriptors;
using HXF.WebServices.Generators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;

namespace HXF.WebServices.Server
{
    public class HxfHandler: IHttpHandler
    {
        private const string INTERFACE = "interface";
        private const string METHOD = "method";
        private const string PARAMETERS = "parameters";

        protected RuntimeConfig runtimeConfig;

        public bool IsReusable
        {
            get { return false; }
        }

        public HxfHandler()
        {
            this.runtimeConfig = new RuntimeConfig();
            this.runtimeConfig.Latency = 0;
            this.runtimeConfig.ReturnInternalErrors = false;
            this.runtimeConfig.ServiceConfig = null;
        }

        public void ProcessRequest(HttpContext context)
        {
            if (runtimeConfig.Latency > 0)
            {
                Thread.Sleep(runtimeConfig.Latency);
            }

            context.Response.Charset = "utf-8";
            context.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            if (this.runtimeConfig.SupportCors)
            {
                context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            }

            NameValueCollection qs = context.Request.QueryString;
            StreamReader sreader = new StreamReader(context.Request.InputStream);
            string body = sreader.ReadToEnd();
            
            if (qs.AllKeys.Length == 0)
            {
                if (string.IsNullOrEmpty(body))
                {
                    processDefaultPage(context);
                }
                else
                {
                    processCallRequest(context, body);
                }
            }
            else
            {
                processInfoRequest(qs, context);
            }
        }

        private void processDefaultPage(HttpContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("HXF.WebServices.Server.Res.default.html"))
            {
                StreamReader reader = new StreamReader(stream);
                string pageContent = string.Format(reader.ReadToEnd(), Path.GetFileName(context.Request.Url.AbsolutePath));
                context.Response.Write(pageContent);
            }            
        }

        private Service createService()
        {
            Service svc = new Service(runtimeConfig.ServiceConfig.Name);
            svc.Description = runtimeConfig.ServiceConfig.Description;
            svc.Interfaces = new List<Interface>();
            foreach (InterfaceConfiguration iconf in runtimeConfig.ServiceConfig.InterfaceConfigs)
            {
                Interface intr = InterfaceBuilder.BuildFromInterfaceType(iconf.RuntimeInfo.InterfaceType);
                intr.Name = iconf.Name;
                intr.Description = iconf.Description;
                svc.Interfaces.Add(intr);
            }
            return svc;
        }

        private void processDescriptor(HttpContext context)
        {
            Service svc = createService();
            string json = svc.ToJson();
            context.Response.ContentType = "text/plain";
            context.Response.Write(json);
        }

        private void processClientCode(NameValueCollection queryString, HttpContext context)
        {
            IProxyGenerator generator = null;
            ResourceManager resMan = new ResourceManager();
            string platform = queryString["platform"];
            if (string.IsNullOrEmpty(platform))
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("No Platform is Specified");
                return;
            }
            platform = platform.ToLower();
            if (platform == "csharp")
            {
                TypeMap tm = resMan.GetTypeMap("dotnet-csharp.typemap");
                generator = new CSharpGenerator(tm);
            }
            else if (platform == "java")
            {
                TypeMap tm = resMan.GetTypeMap("dotnet-java.typemap");
                generator = new JavaGenerator(tm);
            }
            else if (platform == "js-angularjs")
            {
                generator = new AngularGenerator();
            }
            else if (platform == "js-dojo")
            {
                generator = new JavaScriptGenerator();
            }
            else if (platform == "js-dojo-amd")
            {
                generator = new JavaScriptDojoAMDGenerator();
            }
            else if (platform == "flex")
            {
                generator = new FlexGenerator();
            }
            else if (platform == "objc")
            {
                TypeMap tm = resMan.GetTypeMap("dotnet-objc.typemap");
                generator = new ObjectiveCGenerator(tm);
            }

            if (generator == null)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Unknown Platform");
                return;
            }

            string format = queryString["format"];
            format = format == null ? "zip" : format.ToLower();


            Service svc = createService();
            IDictionary<string, string> files = generator.Generate(svc);

            if (format == "zip")
            {
                byte[] buffer = ZipExporter.Export(files);
                MemoryStream ms = new MemoryStream(buffer);
                //context.Response.ContentType = "application/zip";
                context.Response.ContentType = "application/octet-stream";
                string fileName = string.Format("{0}_{1}.zip", svc.Name, platform);
                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
                ms.CopyTo(context.Response.OutputStream);
                context.Response.OutputStream.Close();
            }
            else if (format == "json")
            {
                string s = JsonConvert.SerializeObject(files);
                context.Response.ContentType = "text/json";
                context.Response.Write(s);
            }
            else if (format == "xml")
            {

            }
            
        }

        private void processInfoRequest(NameValueCollection queryString, HttpContext context)
        {
            string action = queryString["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }
            action = action.ToLower();
            if (action == "sd")
            {
                processDescriptor(context);
            }
            else if (action == "code")
            {
                processClientCode(queryString, context);
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Unknown Action");
            }
        }

        private void processCallRequest(HttpContext context, string body)
        {
            context.Response.ContentType = "text/plain";
            
            // parse POST body
            JObject jobject = (JObject)JsonConvert.DeserializeObject(body);
            string interfaceName = (string)jobject[INTERFACE];
            string methodName = (string)jobject[METHOD];
            JObject parameters = (JObject)jobject[PARAMETERS];

            InterfaceConfiguration interfaceConfig = this.runtimeConfig.ServiceConfig.GetInterfaceConfiguration(interfaceName);

            if (interfaceConfig == null)
            {
                throw new Exception(string.Format("Interface name: '{0}' was not found in service", interfaceName));
            }

            Type interfaceType = interfaceConfig.RuntimeInfo.InterfaceType;
            Type classType = interfaceConfig.RuntimeInfo.ClassType;

            var classIntance = Activator.CreateInstance(classType);

            MethodInfo serviceMethod = classType.GetMethod(methodName);
            ParameterInfo[] methodParams = serviceMethod.GetParameters();
            object[] ps = new object[methodParams.Length];
            foreach (ParameterInfo pi in methodParams)
            {
                string n = pi.Name;
                if (parameters[n].GetType() == typeof(JObject))
                {
                    JObject j = (JObject)parameters[n];
                    ps[pi.Position] = convertJobjectToType(j, pi.ParameterType);
                }
                else if (parameters[n].GetType() == typeof(JArray))
                {
                    JArray j = (JArray)parameters[n];
                    ps[pi.Position] = convertJArrayToType(j, pi.ParameterType);
                }
                else
                {
                    JValue j = (JValue)parameters[n];
                    ps[pi.Position] = convertJvalueToType(j, pi.ParameterType);
                }
            }


            ServiceResult sr = null;
            try
            {
                if (serviceMethod.ReturnType != typeof(void))
                {
                    object o = serviceMethod.Invoke(classIntance, ps);
                    sr = ServiceResult.CreateSuccessfulResult(o);
                }
                else
                {
                    serviceMethod.Invoke(classIntance, ps);
                    sr = ServiceResult.CreateSuccessfulResult();
                }
            }
            catch (Exception ex)
            {
                sr = ServiceResult.CreateFailResult(ex.InnerException);
            }

            JsonSerializerSettings jsettings = new JsonSerializerSettings();
            jsettings.NullValueHandling = NullValueHandling.Ignore;
            string serializedObject = JsonConvert.SerializeObject(sr, Formatting.None, jsettings);
            context.Response.Write(serializedObject);
        }

        private object convertJobjectToType(JObject jo, Type t)
        {
            MethodInfo mi = jo.GetType().GetMethod("ToObject", new Type[] { });
            MethodInfo gmi = mi.MakeGenericMethod(t);
            return gmi.Invoke(jo, new object[] { });
        }

        private object convertJvalueToType(JValue jv, Type t)
        {
            MethodInfo mi = jv.GetType().GetMethod("ToObject", new Type[] { });
            MethodInfo gmi = mi.MakeGenericMethod(t);
            return gmi.Invoke(jv, new object[] { });
        }

        private object convertJArrayToType(JArray ja, Type t)
        {
            MethodInfo mi = ja.GetType().GetMethod("ToObject", new Type[] { });
            MethodInfo gmi = mi.MakeGenericMethod(t);
            return gmi.Invoke(ja, new object[] { });
        }
    }
}