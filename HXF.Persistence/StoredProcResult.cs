using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public class StoredProcResult
    {
        public int AffectedRows { get; set; }
        public object ReturnedValue { get; set; }
        public List<List<object>> ResultSets { get; set; }
        public List<object> FirstResultSet
        {
            get
            {
                return ResultSets != null ? ResultSets[0] : null;
            }
        }

        public object SingleResult
        {
            get
            {
                return FirstResultSet != null ? FirstResultSet.FirstOrDefault<object>() : null;
            }
        }
        public List<IDbDataParameter> OutPramaters { get; set; }
    }
}
