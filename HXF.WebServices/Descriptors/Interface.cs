using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Descriptors
{
    public class Interface
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Method> Methods { get; set; }
        public Interface(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public Interface(string name) : this(name, null) { }
        public Interface() : this(null, null) { }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static Interface CreateFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Interface>(json);
        }

    }
}
