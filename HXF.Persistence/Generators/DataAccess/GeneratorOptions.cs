using HXF.Persistence.Naming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.DataAccess
{
    public class GeneratorOptions
    {
        public bool SupportsReturnValue { get; set; }
        public INamingAdapter NamingAdapter { get; set; }
    }
}
