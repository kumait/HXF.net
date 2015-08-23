using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Util.Operations
{
    public class ConnectOperation: Operation
    {
        private readonly string connectionString;
 
        public ConnectOperation(string connectionString)
        {
            this.connectionString = connectionString;
            this.Status = OperationStatus.WAITING;
            this.Name = "Connecting to Database";
        }

        public override void Execute(IDictionary<string, object> scope)
        {
            try
            {
                this.Status = OperationStatus.RUNNING;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                scope["CONNECTION"] = conn;
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
            SqlConnection conn = (SqlConnection)scope["CONNECTION"];
            conn.Close();
            conn.Dispose();
        }
    }
}
