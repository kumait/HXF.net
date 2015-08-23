using HXF.WebServices.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Util
{
    public class GeneratorItem
    {
        public IProxyGenerator Generator {get; set;}
        public string Name { get; set; }

        public GeneratorItem(string Name, IProxyGenerator Generator)
        {
            this.Name = Name;
            this.Generator = Generator;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
