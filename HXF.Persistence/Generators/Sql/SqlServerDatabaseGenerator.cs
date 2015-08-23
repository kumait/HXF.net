using HXF.Common;
using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.Sql
{
    public class SqlServerDatabaseGenerator: DatabaseGenerator
    {
        private const string DUMMY_BODY = "declare @__x__ int = 1;";

        public SqlServerDatabaseGenerator(TypeMap TypeMap) : base(TypeMap) { }

        public override string Generate(Schema schema)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine("----- TABLES -----");
            writer.Write(GenerateTables(schema));
            writer.WriteLine("----- STORED PROCEDURES -----");
            writer.Write(GenerateStoredProcedures(schema));
            return writer.Code;
        }

        public override string GenerateTables(Schema schema)
        {
            CodeWriter writer = new CodeWriter();
            foreach(Table table in schema.Tables)
            {
                writer.WriteLineFormat("-- {0} --", table.Name);
                writer.WriteLine(GenerateSqlCreate(table));
                writer.WriteLine("go");
                writer.WriteLine();
            }
            return writer.Code;
        }

        public override string GenerateStoredProcedures(Schema schema)
        {
            CodeWriter writer = new CodeWriter();
            foreach (StoredProcedure sp in schema.StoredProcedures)
            {
                writer.WriteLineFormat("-- {0} --", sp.Name);
                sp.Definition = DUMMY_BODY;
                writer.WriteLine(GenerateStoredProcedureCreate(sp));
                writer.WriteLine("go");
                writer.WriteLine();
            }
            return writer.Code;
        }
        
        
        public override string GenerateSqlCreate(Table table)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLineFormat("create table [{0}].[{1}](", table.Schema.Name, table.Name);
            writer.PushIdent();
            int colCount = table.Columns.Count;
            int conCount = table.Constraints.Count;
            for (int i = 0; i < colCount; i++)
            {
                Column col = table.Columns[i];
                DataType dt = TypeMap == null ? col.DataType : TypeMap.MapDataType(col.DataType);
                string nullDef = col.IsNullable? "null": "not null";
                string autoIncrementDef = col.IsAutoIncremented ? "identity(1, 1)" : "";
                string colDef = string.Format("[{0}] {1} {2} {3}", col.Name, dt.FullName, nullDef, autoIncrementDef).Trim();
                string comma = (i < colCount - 1 || conCount > 0) ? "," : "";
                writer.WriteLineFormat("{0}{1}", colDef, comma);
            }

            
            for (int i = 0; i < conCount; i++)
            {
                TableConstraint con = table.Constraints[i];
                string conDef = null;
                if (con.Type == ConstraintType.PrimaryKey)
                {
                    string colDef = StringUtils.GenerateCommaSeparatedString(con.Columns, "[", "]");
                    conDef = string.Format("constraint [{0}] primary key({1})", con.Name, colDef);
                }
                else if (con.Type == ConstraintType.Unique)
                {
                    string colDef = StringUtils.GenerateCommaSeparatedString(con.Columns, "[", "]");
                    conDef = string.Format("constraint [{0}] unique({1})", con.Name, colDef);
                }
                else if (con.Type == ConstraintType.Check)
                {
                    CheckConstraint chk = (CheckConstraint)con;
                    conDef = string.Format("constraint [{0}] check {1}", chk.Name, chk.Clause);
                }
                else if (con.Type == ConstraintType.ForeignKey)
                {
                    ForeignKeyConstraint fk = (ForeignKeyConstraint)con;
                    string colDef = StringUtils.GenerateCommaSeparatedString(fk.Columns, "[", "]");
                    string refColDef = StringUtils.GenerateCommaSeparatedString(fk.ReferencedColumns, "[", "]");
                    conDef = string.Format("constraint [{0}] foreign key({1}) references [{2}].[{3}]({4}) on update {5} on delete {6}", 
                        fk.Name, colDef, con.Table.Schema.Name, fk.ReferencedTable, refColDef, fk.UpdateRule, fk.DeleteRule);
                }
                string comma = i < conCount - 1 ? "," : "";
                writer.WriteLineFormat("{0}{1}", conDef, comma);
            }

            writer.PopIdent();
            writer.Write(")");
            return writer.Code;
        }

        public override string GenerateStoredProcedureCreate(StoredProcedure storedProcedure)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLineFormat("CREATE PROCEDURE [{0}].[{1}]", storedProcedure.Schema.Name, storedProcedure.Name);
            int paramCount = storedProcedure.Parameters.Count;
            if (paramCount > 0)
            {
                writer.WriteLine("(");
            }
            writer.PushIdent();
            for (int i = 0; i < paramCount; i++)
            {
                Parameter parameter = storedProcedure.Parameters[i];
                DataType dt = TypeMap == null ? parameter.DataType : TypeMap.MapDataType(parameter.DataType);
                string modeDef = parameter.Mode == "OUT" ? parameter.Mode : "";
                string paramName = parameter.Name.StartsWith("@") ? parameter.Name : "@" + parameter.Name;
                string pDef = string.Format("{0} {1} {2}", paramName, dt.FullName, modeDef).Trim();
                string comma = i < paramCount - 1 ? "," : "";
                writer.WriteLineFormat("{0}{1}", pDef, comma);
            }
            writer.PopIdent();
            if (paramCount > 0)
            {
                writer.WriteLine(")");
            }
            writer.WriteLine("as");
            writer.WriteLine("begin");
            writer.PushIdent();
            writer.WriteLine(storedProcedure.Definition);
            writer.PopIdent();
            writer.Write("end");
            return writer.Code;
        }

        public override string GetPlatform()
        {
            return "SQLSERVER";
        }

        public override string GetName()
        {
            return "SqlServer Satandard Database Generator";
        }
    }
}
