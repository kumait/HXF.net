using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public class ConnectionTester
    {
        public static bool TestConnection(ConnectionInfo conInfo, out Exception exception)
        {
            bool succ = false;

            IConnectionFactory fac = null;
            if (conInfo.Type == ConnectionType.SqlServer)
            {
                fac = new SqlServerConnectionFactory();
            }
            else if (conInfo.Type == ConnectionType.MySql)
            {
                fac = new MySqlConnectionFactory();
            }

            using (IDbConnection con = fac.CreateConnection(conInfo))
            {
                try
                {
                    con.Open();
                    exception = null;
                    succ = true;
                }
                catch (Exception ex)
                {
                    exception = ex;
                    succ = false;
                }
            }
            return succ;
        }
    }
}
