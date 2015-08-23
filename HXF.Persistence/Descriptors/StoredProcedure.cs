using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Descriptors
{
    public class StoredProcedure
    {
        [JsonIgnore]
        public Schema Schema { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public List<Parameter> Parameters { get; set; }
        //public List<ReturnValue> ReturnValues { get; set; }
    }
}
