using HXF.Common;
using HXF.WebServices.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Generators
{
    public class FlexGenerator: IProxyGenerator
    {
        private const string HEADER = @"
// HXF.WebServices Generated Code";
        private const string IMPORT = @"
import flash.events.Event;
import flash.net.URLLoader;
import flash.net.URLLoaderDataFormat;
import flash.net.URLRequest;
import flash.net.URLRequestMethod;";
        
        private const string LOAD = @"
public function load(data: String, completeFunction: Function): void
{
	var urlLoader: URLLoader = new URLLoader();
	urlLoader.dataFormat = URLLoaderDataFormat.TEXT;
	var request: URLRequest = new URLRequest(url);
	urlLoader.addEventListener(Event.COMPLETE, function(evt: Event): void {
		var jobject: Object = JSON.parse(urlLoader.data);
		completeFunction(jobject);
	});
	request.data = data;
	request.method = URLRequestMethod.POST
	urlLoader.load(request);
}";

        public FlexGenerator(TypeMap typeMap)
        {
            this.TypeMap = typeMap;
        }

        public FlexGenerator() : this(null) { }


        public IDictionary<string, string> Generate(Service service)
        {
            IDictionary<string, string> files = new Dictionary<string, string>();
            foreach (Interface intr in service.Interfaces)
            {
                string fileName = intr.Name + ".as";
                string code = GenerateClass(service, intr);
                files[fileName] = code;
            }

            return files;
        }

        public string GenerateClass(Service service, Interface intr)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine(HEADER);
            writer.WriteLineFormat("package {0}", service.Name);
            writer.WriteLine("{");
            writer.PushIdent();
            writer.WriteLine(IMPORT);
            writer.WriteLine();
            writer.WriteLineFormat("public class {0}Client", intr.Name);
            writer.WriteLine("{");
            writer.PushIdent();
            writer.WriteLine("public var url: String = \"\";");
            writer.WriteLine(LOAD);
            writer.WriteLine();

            foreach(Method method in intr.Methods)
            {
                writer.WriteLine(GenerateMethodHeader(intr, method));
                writer.WriteLine("{"); 
                writer.PushIdent();
                writer.WriteLine(GenerateMethodBody(intr, method));
                writer.PopIdent();
                writer.WriteLine("}");
                writer.WriteLine();
            }
            writer.PopIdent();
            writer.WriteLine("}");
            writer.PopIdent();
            writer.WriteLine("}");
            return writer.Code;
        }

        public string GenerateMethodHeader(Interface intr, Method method)
        {
            List<string> paramDefs = new List<string>();
            string methodName = method.Name;
            foreach (Parameter p in method.Parameters)
            {
                string type = TypeMap == null ? p.Type : TypeMap.MapDataType(p.Type);
                string def = string.Format("{0}: {1}", p.Name, type);
                paramDefs.Add(def);
            }
            paramDefs.Add("completeFunction: Function");
            string paramDefString = StringUtils.GenerateCommaSeparatedString(paramDefs, "", "");
            string methodHeader = string.Format("public function {0} ({1}) : {2}", methodName, paramDefString, "void");
            return methodHeader;
        }

        public string GenerateMethodBody(Interface intr, Method method)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine("var o: Object = new Object();");
            writer.WriteLine("var p: Object = new Object();");
            writer.WriteLineFormat("o[\"interface\"] = \"{0}\"", intr.Name);
            writer.WriteLineFormat("o[\"method\"] = \"{0}\"", method.Name);
            foreach (Parameter p in method.Parameters)
            {
                writer.WriteLineFormat("p[\"{0}\"]={0};", p.Name);
            }
            writer.WriteLine("o[\"parameters\"] = p;");
            writer.WriteLine("var data: String = JSON.stringify(o);");
            writer.WriteLine("load(data, completeFunction);");
            return writer.Code;
        }

        public string GetPlatform()
        {
            return "FLEX";
        }

        public string GetName()
        {
            return "Flex Standard Generator";
        }

        public TypeMap TypeMap { get; set; }
    }
}
