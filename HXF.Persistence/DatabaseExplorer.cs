using HXF.Persistence.Conf;
using HXF.Persistence.Descriptors;
using HXF.Persistence.Naming;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public class DatabaseExplorer: IDatabaseExplorer
    {
        private IDbConnection connection;
        private ISqlConf sqlConf;

        public DatabaseExplorer(IDbConnection connection, ISqlConf sqlConf)
        {
            this.connection = connection;
            this.sqlConf = sqlConf;
        }

        private List<T> executeReader<T>(string sql)
        {
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                List<T> list = ReaderUtils.MapToList(rdr, typeof(T), new SameNamingAdapter()).OfType<T>().ToList<T>();
                return list;
            }
        }

        public IEnumerable<Catalog> GetCatalogs()
        {
            string sql = sqlConf.GetSql(Statement.GET_CATALOGS);
            List<Catalog> catalogs = executeReader<Catalog>(sql);
            return catalogs;
        }

        public IEnumerable<Schema> GetSchemas()
        {
            string sql = sqlConf.GetSql(Statement.GET_SCHEMAS);
            List<Schema> schemas = executeReader<Schema>(sql);
            foreach (Schema schema in schemas)
            {
                schema.Tables = GetTables(schema).ToList<Table>();
            }
            return schemas;
        }

        public IEnumerable<Table> GetTables(Schema schema)
        {
            string s = sqlConf.GetSql(Statement.GET_TABLES);
            string sql = string.Format(s, schema.Name);
            List<Table> tables = executeReader<Table>(sql);
            foreach(Table table in tables) {
                table.Schema = schema;
                table.Columns = GetTableColumns(table).ToList<Column>();
                table.Constraints = GetTableConstraints(table).ToList<TableConstraint>();
            }
            return tables;
        }

        public IEnumerable<Column> GetTableColumns(Table table)
        {
            string s = sqlConf.GetSql(Statement.GET_TABLE_COLUMNS);
            string sql = string.Format(s, table.Schema.Name, table.Name);
            List<Column> cols = new List<Column>();
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Column col = new Column();
                    col.Entity = table;
                    col.Name = rdr.GetString(0);
                    col.Position = rdr.GetInt32(1);
                    col.DataType = new DataType();
                    col.DataType.Name = rdr.GetString(2);
                    if (!rdr.IsDBNull(3))
                    {
                        col.DataType.Precision = rdr.GetInt64(3);
                    }

                    if (!rdr.IsDBNull(4))
                    {
                        col.DataType.Scale = rdr.GetInt64(4);
                    }
                    col.IsNullable = rdr.GetBoolean(5);
                    col.IsAutoIncremented = rdr.GetBoolean(6);
                    col.IsComputed = rdr.GetBoolean(7);
                    cols.Add(col);
                }
            }
            return cols;
        }

        public IEnumerable<TableConstraint> GetTableConstraints(Table table)
        {
            string s = sqlConf.GetSql(Statement.GET_TABLE_CONSTRAINTS);
            string sql = string.Format(s, table.Schema.Name, table.Name);
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            List<TableConstraint> constraints = new List<TableConstraint>();
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    string name = (string)rdr["Name"];
                    string type = (string)rdr["Type"];
                    TableConstraint con = TableConstraint.Create(type);
                    con.Table = table;
                    con.Name = name;
                    constraints.Add(con);
                }
            }

            foreach (TableConstraint con in constraints)
            {
                con.Columns = GetConstraintColumns(con);
                if (con is CheckConstraint)
                {
                    CheckConstraint chk = (CheckConstraint)con;
                    chk.Clause = GetCheckConstraintClause(chk);
                }
                
                if (con.Type == ConstraintType.ForeignKey)
                {
                    HXF.Persistence.Descriptors.ForeignKeyConstraint fk = (HXF.Persistence.Descriptors.ForeignKeyConstraint)con;
                    PopulateForeignKeyConstraint(fk);
                }                
            }


            return constraints;
        }

        private List<string> GetConstraintColumns(TableConstraint constraint)
        {
            return GetConstraintColumns(constraint.Table.Schema.Name, constraint.Table.Name, constraint.Name);
        }

        private List<string> GetConstraintColumns(string schema, string table, string constraint)
        {
            string s = sqlConf.GetSql(Statement.GET_CONSTRAINT_COLUMNS);
            string sql = string.Format(s, schema, table, constraint);
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            List<string> cols = new List<string>();
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    string col = (string)rdr["ColumnName"];
                    cols.Add(col);
                }

            }
            return cols;
        }

        private string GetCheckConstraintClause(CheckConstraint constraint)
        {
            string clause = null;
            string s = sqlConf.GetSql(Statement.GET_CHECK_CLAUSE);
            string sql = string.Format(s, constraint.Table.Schema.Name, constraint.Name);
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    clause = (string)rdr["Clause"];
                }
            }
            return clause;
        }

        private void PopulateForeignKeyConstraint(HXF.Persistence.Descriptors.ForeignKeyConstraint constraint)
        {
            string s = sqlConf.GetSql(Statement.GET_FK_CONSTRAINT);
            string sql = string.Format(s, constraint.Table.Schema.Name, constraint.Table.Name, constraint.Name);
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    constraint.UniqueConstraint = (string)rdr["UniqueConstraint"];
                    constraint.ReferencedTable = (string)rdr["ReferencedTable"];
                    constraint.UpdateRule = (string)rdr["UpdateRule"];
                    constraint.DeleteRule = (string)rdr["DeleteRule"];
                }
            }
            constraint.ReferencedColumns = GetConstraintColumns(constraint.Table.Schema.Name, constraint.ReferencedTable, constraint.UniqueConstraint);
        }

        public IEnumerable<StoredProcedure> GetStoredProcedures(Schema schema)
        {
            string s = sqlConf.GetSql(Statement.GET_STORED_PROCEDURES);
            string sql = string.Format(s, schema.Name);
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            List<StoredProcedure> sps = new List<StoredProcedure>();
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    string name = (string)rdr["Name"];
                    string def = (string)rdr["Definition"];
                    StoredProcedure sp = new StoredProcedure();
                    sp.Schema = schema;
                    sp.Name = name;
                    sp.Definition = def;
                    sps.Add(sp);
                }

            }

            foreach (StoredProcedure sp in sps)
            {
                sp.Parameters = GetStoredProcedureParameters(sp).ToList<Parameter>();
            }

            return sps;
        }

        public IEnumerable<Parameter> GetStoredProcedureParameters(StoredProcedure storedProcedure)
        {
            string s = sqlConf.GetSql(Statement.GET_STORED_PROCEDURE_PARAMETERS);
            string sql = string.Format(s, storedProcedure.Schema.Name, storedProcedure.Name);
            
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            List<Parameter> parameters = new List<Parameter>();
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Parameter p = new Parameter();
                    p.Name = rdr.GetString(0);
                    p.Position = rdr.GetInt32(1);
                    p.DataType = new DataType();
                    p.DataType.Name = rdr.GetString(2);
                    if (!rdr.IsDBNull(3))
                    {
                        p.DataType.Precision = rdr.GetInt64(3);
                    }
                    if (!rdr.IsDBNull(4))
                    {
                        p.DataType.Scale = rdr.GetInt64(4);
                    }
                    p.Mode = rdr.GetString(5);
                    parameters.Add(p);
                }

            }
            return parameters;
        }
    }
}
