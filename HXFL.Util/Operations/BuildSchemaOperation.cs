using HXF.Persistence;
using HXF.Persistence.Conf;
using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Util.Operations
{
    public class BuildSchemaOperation: Operation
    {
        private string schemaName;

        public BuildSchemaOperation(string schemaName)
        {
            this.schemaName = schemaName;
            this.Status = OperationStatus.WAITING;
            this.Name = "Building Schema";
        }

        public override void Execute(IDictionary<string, object> scope)
        {
            try
            {
                this.Status = OperationStatus.RUNNING;
                SqlConnection conn = scope["CONNECTION"] as SqlConnection;
                DatabaseExplorer exp = new DatabaseExplorer(conn, new SQLServerDefaultConf());
                Schema schema = new Schema();
                schema.Name = this.schemaName;
                schema.Tables = exp.GetTables(schema).ToList<Table>();
                schema.StoredProcedures = exp.GetStoredProcedures(schema).ToList<StoredProcedure>();
                scope["SCHEMA"] = schema;
                this.Status = OperationStatus.COMPLETED;
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
            
        }
    }
}
