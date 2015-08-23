using HXF.Common;
using HXF.WebServices.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices
{
    public class ResourceManager
    {
        private ResourceLoader loader;

        public ResourceManager()
        {
            this.loader = new ResourceLoader(Assembly.GetExecutingAssembly());
        }

        private List<TypeMap> getTypeMaps(string folder)
        {
            List<TypeMap> typeMaps = new List<TypeMap>();
            string[] names = loader.GetResourceNames(folder);
            foreach (string s in names)
            {
                string json = loader.LoadResource(s);
                TypeMap tm = TypeMap.FromJson(json);
                typeMaps.Add(tm);
            }
            return typeMaps;
        }

        public TypeMap GetTypeMap(string name)
        {
            string json = loader.LoadResource("HXF.WebServices.Res.tm." + name);
            TypeMap tm = TypeMap.FromJson(json);
            return tm;
        }

        public List<TypeMap> GetTypeMaps()
        {
            return getTypeMaps("tm");
        }
    }
}
