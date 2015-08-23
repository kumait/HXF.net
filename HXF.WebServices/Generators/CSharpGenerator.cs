using HXF.Common;
using HXF.WebServices.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Generators
{
    public class CSharpGenerator: IProxyGenerator
    {
        private const string HEADER = @"
// HXF.WebServices Generated Code
";

        private const string USING_STRING = 
@"using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;"; 

        private const string LOAD_METHOD =
@"private string Load(string contents)
{
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(SERVICE_URL);
    req.AllowWriteStreamBuffering = true;
    req.Method = ""POST"";
    req.Timeout = 60000;
    Stream outStream = req.GetRequestStream();
    StreamWriter outStreamWriter = new StreamWriter(outStream);
    outStreamWriter.Write(contents);
    outStreamWriter.Flush();
    outStream.Close();
    WebResponse res = req.GetResponse();
    Stream httpStream = res.GetResponseStream();
    MemoryStream memoryStream = new MemoryStream();
    try
    {
        byte[] buff = new byte[BUFFER_SIZE];
        int readedBytes = httpStream.Read(buff, 0, buff.Length);
        while (readedBytes > 0)
        {
            memoryStream.Write(buff, 0, readedBytes);
            readedBytes = httpStream.Read(buff, 0, buff.Length);
        }
    }
    finally
    {
        if (httpStream != null)
        {
            httpStream.Close();
        }

        if (memoryStream != null)
        {
            memoryStream.Close();
        }
    }
    byte[] data = memoryStream.ToArray();
    string result = Encoding.UTF8.GetString(data, 0, data.Length);
    return result;
}
";
        public TypeMap TypeMap { get; set; }

        public CSharpGenerator(TypeMap typeMap)
        {
            this.TypeMap = typeMap; 
        }

        public CSharpGenerator() : this(null) { }

        public IDictionary<string, string> Generate(Service service)
        {
            IDictionary<string, string> files = new Dictionary<string, string>();
            foreach (Interface intr in service.Interfaces)
            {
                string fileName = intr.Name + ".cs";
                string code = GenerateClientClass(service, intr);
                files[fileName] = code;
            }

            return files;
        }

        public string GenerateClientClass(Service service, Interface intr)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine(USING_STRING);
            writer.WriteLine();
            writer.WriteLineFormat("namespace {0}", service.Name);
            writer.WriteLine("{");
            writer.PushIdent();
            string className = intr.Name + "Client";
            writer.WriteLineFormat("public class {0}", className);
            writer.WriteLine("{");
            writer.PushIdent();
            writer.WriteLine("private const string SERVICE_URL = \"\";");
            writer.WriteLine("private const int BUFFER_SIZE = 4096;");
            writer.WriteLine();
            writer.WriteLine(LOAD_METHOD);
            writer.WriteLine();
            foreach (Method method in intr.Methods)
            {
                writer.WriteLine(GenerateMethod(intr, method));
                writer.WriteLine();
            }
            writer.PopIdent();
            writer.WriteLine("}");
            writer.PopIdent();
            writer.WriteLine("}");
            return writer.Code;
        }

        private string generateMethodHeader(Interface intr, Method method)
        {
            StringBuilder sb = new StringBuilder();
            List<string> paramDefs = new List<string>();
            string methodName = method.Name;
            foreach (Parameter p in method.Parameters)
            {
                string type = TypeMap == null ? p.Type : TypeMap.MapDataType(p.Type);
                string def = string.Format("{0} {1}", type, p.Name);
                paramDefs.Add(def);
            }
            string paramDefString = StringUtils.GenerateCommaSeparatedString(paramDefs, "", "");
            string returnType = "JObject";
            string header = string.Format("public {0} {1}({2})", returnType, methodName, paramDefString.Trim());
            return header;
        }

        private string generateMethodBody(Interface intr, Method method)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine("JObject result = null;");
            writer.WriteLine("JObject o = new JObject();");
            writer.WriteLine("JObject p = new JObject();");
            writer.WriteLineFormat("o[\"interface\"] = \"{0}\";", intr.Name);
            writer.WriteLineFormat("o[\"method\"]= \"{0}\";", method.Name);
            foreach (Parameter p in method.Parameters) {
                writer.WriteLineFormat("p[\"{0}\"]= JToken.FromObject({0});", p.Name);
            }
            writer.WriteLine("o[\"parameters\"] = p;");
            writer.WriteLine("string s = JsonConvert.SerializeObject(o);");
            writer.WriteLine("string r = Load(s);");
            writer.WriteLine("result = JObject.Parse(r);");
            writer.WriteLine("return result;");
            return writer.Code;
        }

        public string GenerateMethod(Interface intr, Method method)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine(generateMethodHeader(intr, method));
            writer.WriteLine("{");
            writer.PushIdent();
            writer.WriteLine(generateMethodBody(intr, method));
            writer.PopIdent();
            writer.WriteLine("}");
            return writer.Code;
        }


        public string GetPlatform()
        {
            return "C#";
        }

        public string GetName()
        {
            return "C# Standard Generator";
        }
    }
}
