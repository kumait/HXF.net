using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Descriptors
{
    public class TableConstraint
    {
        [JsonIgnore]
        public Table Table { get; set; }
        public string Name { get; set; }
        public List<string> Columns { get; set; }
        public ConstraintType Type { get; set; }
        public static TableConstraint Create(string name)
        {
            TableConstraint constraint = null;
            if (name == "PRIMARY KEY")
                constraint = new PrimaryKeyConstraint();
            else if (name == "FOREIGN KEY")
                constraint = new ForeignKeyConstraint();
            else if (name == "UNIQUE")
                constraint = new UniqueConstraint();
            else if (name == "CHECK")
                constraint = new CheckConstraint();
            return constraint;
        }
    }
}
