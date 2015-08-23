using HXF.Common;
using HXF.WebServices.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Generators
{
    public class JavaGenerator: IProxyGenerator
    {
        private const string HEADER = @"
// HXF.WebServices Generated Code
";
        private const string IMPORT = @"
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.text.SimpleDateFormat;
import java.util.Collection;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.net.HttpURLConnection;
import java.net.URL;
import org.json.JSONObject;
import org.json.JSONArray;";

        private const string CONVERT_METHOD = @"
private static String convertStreamToUTF8String(InputStream stream) throws IOException {
	String result = """";
	StringBuilder sb = new StringBuilder();
	try {
        InputStreamReader reader = new InputStreamReader(stream, ""UTF-8"");
        char[] buffer = new char[BUFFER_SIZE];
        int readedChars = 0;
        while (readedChars != -1) {
            readedChars = reader.read(buffer);
            if (readedChars > 0)
                sb.append(buffer, 0, readedChars);
        }
        result = sb.toString();
	} catch (UnsupportedEncodingException e) {
        e.printStackTrace();
    }
    return result;
}
";
        private const string LOAD_METHOD = @"
private String load(String contents) throws IOException {
    URL url = new URL(SERVICE_URL);
    HttpURLConnection conn = (HttpURLConnection)url.openConnection();
    conn.setRequestMethod(""POST"");
    conn.setConnectTimeout(60000);
    conn.setDoOutput(true);
    conn.setDoInput(true);
    OutputStreamWriter w = new OutputStreamWriter(conn.getOutputStream());
    w.write(contents);
    w.flush();
    InputStream istream = conn.getInputStream();
    String result = convertStreamToUTF8String(istream);
    return result;
}
";
        private const string MAP_OBJECT_METHOD = @"
private Object mapObject(Object o) {
	Object finalValue = null;
	if (o.getClass() == String.class) {
		finalValue = o;
	}
	else if (Number.class.isInstance(o)) {
		finalValue = String.valueOf(o);
	} else if (Date.class.isInstance(o)) {
		SimpleDateFormat sdf = new SimpleDateFormat(""MM/dd/yyyy hh:mm:ss"", new Locale(""en"", ""USA""));
		finalValue = sdf.format((Date)o);
	}
	else if (Collection.class.isInstance(o)) {
		Collection<?> col = (Collection<?>) o;
		JSONArray jarray = new JSONArray();
		for (Object item : col) {
			jarray.put(mapObject(item));
		}
		finalValue = jarray;
	} else {
		Map<String, Object> map = new HashMap<String, Object>();
		Method[] methods = o.getClass().getMethods();
		for (Method method : methods) {
			if (method.getDeclaringClass() == o.getClass()
					&& method.getModifiers() == Modifier.PUBLIC
					&& method.getName().startsWith(""get"")) {
				String key = method.getName().substring(3);
				try {
					Object obj = method.invoke(o, null);
					Object value = mapObject(obj);
					map.put(key, value);
					finalValue = new JSONObject(map);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		}

	}
	return finalValue;
}
";

        public JavaGenerator(TypeMap typeMap)
        {
            this.TypeMap = typeMap;
        }

        public JavaGenerator() : this(null) { }
        
        public IDictionary<string, string> Generate(Service service)
        {
            IDictionary<string, string> files = new Dictionary<string, string>();
            foreach (Interface intr in service.Interfaces)
            {
                string fileName = intr.Name + "Client" + ".java";
                string code = GenerateClientClass(service, intr);
                files[fileName] = code;
            }

            return files;
        }

        public string GenerateClientClass(Service service, Interface intr)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine(HEADER);
            writer.WriteLineFormat("package {0};", service.Name);
            writer.WriteLine(IMPORT);
            writer.WriteLine();
            string className = intr.Name + "Client";
            writer.WriteLineFormat("public class {0}", className);
            writer.WriteLine("{");
            writer.PushIdent();
            writer.WriteLine("private static final String SERVICE_URL = \"\";");
            writer.WriteLine("private static final int BUFFER_SIZE = 4096;");
            writer.WriteLine();
            writer.WriteLine(LOAD_METHOD);
            writer.WriteLine();
            writer.WriteLine(MAP_OBJECT_METHOD);
            writer.WriteLine();
            writer.WriteLine(CONVERT_METHOD);
            writer.WriteLine();

            foreach (Method method in intr.Methods)
            {
                writer.WriteLine(GenerateMethod(intr, method));
                writer.WriteLine();
            }
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
            string returnType = "JSONObject";
            string header = string.Format("public {0} {1}({2}) throws Exception", returnType, methodName, paramDefString.Trim());
            return header;
        }

        private string generateMethodBody(Interface intr, Method method)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine("JSONObject result = null;");
            writer.WriteLine("JSONObject o = new JSONObject();");
            writer.WriteLine("JSONObject p = new JSONObject();");
            writer.WriteLineFormat("o.put(\"interface\", \"{0}\");", intr.Name);
            writer.WriteLineFormat("o.put(\"method\", \"{0}\");", method.Name);
            foreach (Parameter p in method.Parameters)
            {
                writer.WriteLineFormat("p.put(\"{0}\",mapObject({0}));", p.Name);
            }
            writer.WriteLineFormat("o.put(\"parameters\", p);");
            writer.WriteLine(@"String s = o.toString();");
            writer.WriteLine(@"String r = load(s);");
            writer.WriteLine(@"result = new JSONObject(r);");
            writer.WriteLine(@"return result;");
            return writer.Code;
        }

        public string GenerateMethod(Interface intr, Method method)
        {
            CodeWriter writer = new CodeWriter();
            writer.Write(generateMethodHeader(intr, method));
            writer.WriteLine("{");
            writer.PushIdent();
            writer.WriteLine(generateMethodBody(intr, method));
            writer.PopIdent();
            writer.WriteLine("}");
            return writer.Code;
        }

        public string GetPlatform()
        {
            return "JAVA";
        }

        public string GetName()
        {
            return "Java Standard Generator";
        }

        public TypeMap TypeMap { get; set; }
    }
}
