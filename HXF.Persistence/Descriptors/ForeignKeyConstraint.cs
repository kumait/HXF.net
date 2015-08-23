using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Descriptors
{
    public class ForeignKeyConstraint: TableConstraint
    {
        public ForeignKeyConstraint()
        {
            this.Type = ConstraintType.ForeignKey;
        }

        public string UniqueConstraint { get; set; }
        public string ReferencedTable { get; set; }
        public List<string> ReferencedColumns { get; set; }
        public string UpdateRule { get; set; }
        public string DeleteRule { get; set; }
    }
}
