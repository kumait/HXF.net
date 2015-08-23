using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators
{  
    public class TypeMapRule
    {
        public string FromType { get; set; }
        public string FromPrecision { get; set; }
        public string FromScale { get; set; }
        public string ToType { get; set; }
        public string ToPrecision { get; set; }
        public string ToScale { get; set; }
    }
}
