using HXF.Persistence.Conf;
using HXF.Persistence.Descriptors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public class SchemaBuilder
    {
        public static Schema CreateFromConnection(ConnectionInfo conInfo)
        {
            Schema schema = new Schema();
            schema.CatalogName = conInfo.Catalog;
            schema.Name = conInfo.Schema;
            
            IConnectionFactory fac = null;
            ISqlConf sqlConf = null;
            if (conInfo.Type == ConnectionType.SqlServer)
            {
                fac = new SqlServerConnectionFactory();
                sqlConf = new SQLServerDefaultConf();
                schema.Platform = "SQLSERVER";
            }
            else if (conInfo.Type == ConnectionType.MySql)
            {
                fac = new MySqlConnectionFactory();
                sqlConf = new MySqlDefaultConf();
                schema.Platform = "MYSQL";
            }

            using (IDbConnection conn = fac.CreateConnection(conInfo))
            {
                conn.Open();
                IDatabaseExplorer dbExplorer = new DatabaseExplorer(conn, sqlConf);
                schema.Tables = dbExplorer.GetTables(schema).ToList<Table>();
                schema.StoredProcedures = dbExplorer.GetStoredProcedures(schema).ToList<StoredProcedure>();   
            }
            return schema;
        }
    }
}
