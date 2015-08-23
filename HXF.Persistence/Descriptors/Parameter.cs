using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Descriptors
{
    public class Parameter
    {
        [JsonIgnore]
        public StoredProcedure StoredProcedure { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public DataType DataType { get; set; }
        public string Mode { get; set; }
        //public ParameterDirection Direction { get; set; }
    }
}
