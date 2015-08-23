using HXF.Persistence;
using HXF.Persistence.Conf;
using HXF.Persistence.Descriptors;
using HXF.Persistence.Generators.Sql;
using Microsoft.SqlServer.Management.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Util.Operations
{
    public class UpdateDatabaseOperation: Operation
    {
        private readonly string schemaName;

        public UpdateDatabaseOperation(string schemaName)
        {
            this.schemaName = schemaName;
            this.Status = OperationStatus.WAITING;
            this.Name = "Updating Database";
        }

        public override void Execute(IDictionary<string, object> scope)
        {
            try
            {
                this.Status = OperationStatus.RUNNING;
                SqlConnection conn = scope["CONNECTION"] as SqlConnection;
                DatabaseExplorer exp = new DatabaseExplorer(conn, new SQLServerDefaultConf());
                Schema schema = scope["SCHEMA"] as Schema;
                SqlServerCrudGenerator gen = new SqlServerCrudGenerator(null);
                string script = gen.Generate(schema);
                Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(script);
                Status = OperationStatus.COMPLETED;
            }
            catch (Exception ex)
            {
                this.Exception = ex;
                this.Status = OperationStatus.FAILED;
                throw ex;
            }
        }

        public override void Clean(IDictionary<string, object> scope)
        {
            // nothing to do
        }
    }
}
