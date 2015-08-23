using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Descriptors
{
    public class Entity
    {
        [JsonIgnore]
        public Schema Schema { get; set; }
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
    }
}
