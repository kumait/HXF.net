using HXF.Persistence.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Util
{
    public class TypeMapItem
    {
        public TypeMap TypeMap {get; set;}
        public string Name { get; set; }

        public TypeMapItem(string Name, TypeMap TypeMap)
        {
            this.Name = Name;
            this.TypeMap = TypeMap;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
