using HXF.Persistence.Generators;
using HXF.Persistence.Generators.DataAccess;
using HXF.Persistence.Generators.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Util
{
    public class DalGeneratorItem
    {
        public IDataAccessGenerator Generator {get; set;}
        public string Name { get; set; }

        public DalGeneratorItem(string Name, IDataAccessGenerator Generator)
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
