using HXF.Persistence.Naming;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public class DatabaseContext
    {
        protected IDbConnection connection;
        protected IDbTransaction transaction;

        public DatabaseContext(IDbConnection connection, IDbTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }

        //public DatabaseContext(SqlConnection connection) : this(connection, null, new SameNamingAdapter()) { }


        private SqlParameter getReturnParameter()
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = "RETURN_VALUE";
            p.Direction = ParameterDirection.ReturnValue;
            return p;
        }

        public StoredProcResult ExecProc(string name, IEnumerable<IDbDataParameter> parameters, INamingAdapter namingAdapter, bool hasReturnValue, params Type[] resultTypes)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                StoredProcResult result = new StoredProcResult();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = name;
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                // add return parameter
                if (hasReturnValue)
                {
                    IDbDataParameter returnParameter = command.CreateParameter();
                    returnParameter.ParameterName = "RETURN_VALUE";
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnParameter);
                }
                
                if (parameters != null)
                {
                    foreach (IDbDataParameter p in parameters)
                    {
                        command.Parameters.Add(p);
                    }
                }

                if (resultTypes.Length == 0)
                {
                    result.AffectedRows = command.ExecuteNonQuery();
                    if (hasReturnValue)
                    {
                        result.ReturnedValue = ((IDbDataParameter)command.Parameters[0]).Value;
                    }
                }
                else
                {
                    IDataReader reader = null;
                    List<List<object>> lists = new List<List<object>>();
                    try
                    {
                        reader = command.ExecuteReader();
                        int i = 0;
                        do
                        {
                            Type itemType = resultTypes.ElementAtOrDefault<Type>(i);
                            if (itemType != null)
                            {
                                List<object> l = ReaderUtils.MapToList(reader, itemType, namingAdapter);
                                lists.Add(l);
                                i++;
                            }
                        } while (reader.NextResult());
                        result.ResultSets = lists;
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                            result.AffectedRows = reader.RecordsAffected;
                            if (hasReturnValue)
                            {
                                result.ReturnedValue = ((IDbDataParameter)command.Parameters[0]).Value;
                            }
                        }
                    }
                }

                // add out paramaters
                foreach (IDbDataParameter p in command.Parameters)
                {
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        if (result.OutPramaters == null)
                        {
                            result.OutPramaters = new List<IDbDataParameter>();
                        }
                        result.OutPramaters.Add(p);
                    }
                }


                return result;
            }
        }
    }
}
