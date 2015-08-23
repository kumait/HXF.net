using HXF.Persistence.Descriptors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public class MySqlConnectionFactory: IConnectionFactory
    {
        public IDbConnection CreateConnection(ConnectionInfo conInfo)
        {
            IDbConnection conn = null;
            try
            {
                string cs = CreateConnectionString(conInfo);
                conn = new MySqlConnection(cs);
            }
            catch
            {
                // log exception
            }
            return conn;
        }


        public string CreateConnectionString(ConnectionInfo conInfo)
        {
            string cs = string.Format("server={0}; user id={1}; password={2}; database={3}", conInfo.Server, conInfo.User, conInfo.Password, conInfo.Catalog);
            return cs;
        }
    }
}
