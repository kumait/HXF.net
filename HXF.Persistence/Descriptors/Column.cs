using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Descriptors
{
    public class Column
    {
        [JsonIgnore]
        public Entity Entity { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public DataType DataType { get; set; }
        public bool IsNullable { get; set; }
        public bool IsAutoIncremented { get; set; }
        public bool IsComputed { get; set; }
    }
}
