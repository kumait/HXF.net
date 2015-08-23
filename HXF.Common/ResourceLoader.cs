using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Common
{
    public class ResourceLoader
    {
        private Assembly assembly;

        public ResourceLoader(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public string[] GetResourceNames(string folder)
        {
            string path = assembly.GetName().Name + ".Res." + folder;
            string[] resNames = assembly.GetManifestResourceNames().Where<string>(s => s.StartsWith(path)).ToArray<string>();
            return resNames;
        }

        public string LoadResource(string resourceName)
        {
            string res = null;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                StreamReader reader = new StreamReader(stream);
                res = reader.ReadToEnd();
            }
            return res;
        }
    }
}
