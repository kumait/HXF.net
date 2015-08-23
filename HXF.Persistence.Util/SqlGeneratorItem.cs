using HXF.Persistence.Generators;
using HXF.Persistence.Generators.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Util
{
    public class SqlGeneratorItem
    {
        public ISqlGenerator Generator {get; set;}
        public string Name { get; set; }

        public SqlGeneratorItem(string Name, ISqlGenerator Generator)
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
