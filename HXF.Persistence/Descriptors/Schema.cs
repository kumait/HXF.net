using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Descriptors
{
    public class Schema
    {
        public string Name { get; set; }
        public string CatalogName { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public List<Table> Tables { get; set; }
        public List<StoredProcedure> StoredProcedures { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static Schema CreateFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Schema>(json);
        }
    }
}
