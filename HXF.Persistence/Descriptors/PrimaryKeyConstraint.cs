using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Descriptors
{
    public class PrimaryKeyConstraint: TableConstraint
    {
        public PrimaryKeyConstraint()
        {
            this.Type = ConstraintType.PrimaryKey;
        }
    }
}
