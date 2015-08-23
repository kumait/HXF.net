using HXF.Common;
using HXF.WebServices.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Generators
{
    public class AngularGenerator: IProxyGenerator
    {
        private const string CALL_DEF =
@"
$http.post(serviceUrl, data)
        .success(function (data) {
            successFunction(data);
        })
        .error(function (error) {
            failFunction(error);
        });";


        public IDictionary<string, string> Generate(Service service)
        {
            IDictionary<string, string> files = new Dictionary<string, string>();

            CodeWriter writer = new CodeWriter();
            writer.WriteLineFormat("angular.module(\"{0}\", [])", service.Name);
            writer.PushIdent();
            writer.WriteLine(".constant('serviceUrl', 'http://localhost:8800/Server/handler.ashx')");
            writer.WriteLine();

            foreach (Interface intr in service.Interfaces)
            {
                string code = GenerateInterface(service, intr);
                writer.WriteLine(code);
            }
            string fileName = service.Name + ".js";
            files[fileName] = writer.Code;
            return files;
        }

        public string GenerateInterface(Service service, Interface intr)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteFormat(".factory(\"{0}Client\", function($http, serviceUrl)", intr.Name);
            writer.WriteLineNoIdent(" {");
            writer.PushIdent();
            writer.WriteLine("return {");

            int methodCount = intr.Methods.Count;
            for (int i = 0; i < methodCount; i++)
            {
                writer.PushIdent();
                Method method = intr.Methods[i];
                string comma = i < methodCount - 1 ? "," : "";
                writer.Write(GenerateMethod(intr, method).Trim());
                writer.WriteLineNoIdent(comma);
                writer.WriteLine();
                writer.PopIdent();
            }
 
            writer.WriteLine("}");
            writer.PopIdent();
            writer.WriteLine("})");
            return writer.Code;
        }

        public string GenerateMethod(Interface intr, Method method)
        {
            CodeWriter writer = new CodeWriter();
            writer.Write(generateMethodHeader(intr, method));
            writer.WriteLine(" {");
            writer.PushIdent();
            writer.WriteLine(generateMethodBody(intr, method));
            writer.PopIdent();
            writer.Write("}");
            return writer.Code;
        }

        private string generateMethodHeader(Interface intr, Method method)
        {
            StringBuilder sb = new StringBuilder();
            List<string> paramDefs = new List<string>();
            string methodName = method.Name;
            foreach (Parameter p in method.Parameters)
            {
                string def = p.Name;
                paramDefs.Add(def);
            }
            paramDefs.Add("successFunction");
            paramDefs.Add("failFunction");

            string paramDefString = StringUtils.GenerateCommaSeparatedString(paramDefs, "", "");
            string header = string.Format("{0}: function({1})", methodName, paramDefString.Trim());
            return header;
        }

        private string generateMethodBody(Interface intr, Method method)
        {
            CodeWriter writer = new CodeWriter();
            List<string> paramDefs = new List<string>();
            string methodName = method.Name;
            foreach (Parameter p in method.Parameters)
            {
                string def = string.Format("'{0}': {0}", p.Name);
                paramDefs.Add(def);
            }
            string paramDefString = "{" + StringUtils.GenerateCommaSeparatedString(paramDefs, "", "") + "}";
            string dataObjectDef = string.Format("var data = {{ 'interface': '{0}', 'method': '{1}', 'parameters': {2} }};", intr.Name, method.Name, paramDefString);
            writer.WriteLine(dataObjectDef);
            writer.WriteLine(CALL_DEF);
            return writer.Code;
        }

        public string GetPlatform()
        {
            return "JS";
        }

        public string GetName()
        {
            return "AngularJS Standard Generator";
        }

        public TypeMap TypeMap { get; set; }
    }
}
