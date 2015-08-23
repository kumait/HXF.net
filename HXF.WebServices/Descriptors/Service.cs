using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Descriptors
{
    public class Service
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public List<Interface> Interfaces { get; set; }

        public Service(string name)
        {
            this.Name = name;
            this.Platform = "DOTNET";
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static Service CreateFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Service>(json);    
        }
    }
}
