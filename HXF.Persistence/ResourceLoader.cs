using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public static class ResourceLoader
    {
        public static string LoadResource(string resourceName) {
            string template = null;
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] ss = assembly.GetManifestResourceNames();
            string[] ssq = GetResourceNames("tm");
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                StreamReader reader = new StreamReader(stream);
                template = reader.ReadToEnd();
            }
            return template;
        }

        public static string[] GetResourceNames(string folder)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceNames().Where<string>(s => s.StartsWith("HXF.Persistence.Res." + folder)).ToArray<string>();
        }
    }
}
