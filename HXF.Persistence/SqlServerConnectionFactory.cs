using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public class SqlServerConnectionFactory: IConnectionFactory
    {
        public IDbConnection CreateConnection(ConnectionInfo conInfo)
        {
            string cs = CreateConnectionString(conInfo);
            SqlConnection conn = new SqlConnection(cs);
            return conn;
        }

        public string CreateConnectionString(ConnectionInfo conInfo)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(conInfo.Server))
            {
                sb.AppendFormat("Data Source={0};", conInfo.Server);
            }

            if (!string.IsNullOrEmpty(conInfo.Catalog))
            {
                sb.AppendFormat("initial catalog={0};", conInfo.Catalog);
            }

            if (!string.IsNullOrEmpty(conInfo.User))
            {
                sb.AppendFormat("User={0};", conInfo.User);
            }

            if (!string.IsNullOrEmpty(conInfo.Password))
            {
                sb.AppendFormat("Password={0};", conInfo.Password);
            }

            if (string.IsNullOrEmpty(conInfo.User) && (string.IsNullOrEmpty(conInfo.Password)))
            {
                sb.Append("Integrated Security=True;");
            }
            string cs = sb.ToString();
            return cs;
        }

        
    }
}
