using HXF.Common;
using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.Sql
{
    public class MySqlCrudGenerator: CrudGenerator
    {
        public MySqlCrudGenerator(TypeMap TypeMap) : base(TypeMap) { }


        public override string Generate(Schema schema)
        {
            CodeWriter writer = new CodeWriter();
            foreach (Table table in schema.Tables)
            {
                writer.WriteLineFormat("-- {0} --", table.Name);
                writer.WriteLine(GenerateInsert(table));
                writer.WriteLine(GenerateUpdate(table));
                writer.WriteLine(GenerateDelete(table));
                writer.WriteLine(GenerateGetAll(table));
                writer.WriteLine(GenerateGet(table));
                writer.WriteLine();
            }
            return writer.Code;
        }

        private string generateInsertBody(Table table, List<Column> insertableColumns)
        {
            List<string> colNames = new List<string>();
            foreach (Column col in insertableColumns)
            {
                colNames.Add(col.Name);
            }

            CodeWriter writer = new CodeWriter();
            writer.WriteLineFormat("insert into `{0}`.`{1}`", table.Schema.Name, table.Name);
            writer.WriteLineFormat("({0})", StringUtils.GenerateCommaSeparatedString(colNames, "`", "`"));
            writer.WriteLine("values");
            writer.WriteFormat("({0})", StringUtils.GenerateCommaSeparatedString(colNames, "", ""));
            writer.WriteNoIdent(";");
            return writer.Code;
        }

        private string generateUpdateBody(Table table, List<Column> keyColumns, List<Column> updateColumns)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLineFormat("update `{0}`.`{1}`", table.Schema.Name, table.Name);
            writer.WriteLine("set");
            writer.PushIdent();
            for (int i = 0; i < updateColumns.Count; i++)
            {
                Column column = updateColumns[i];
                string and = i < updateColumns.Count - 1 ? "," : "";
                string cond = string.Format("`{0}` = {0} {1}", column.Name, and).Trim();
                writer.WriteLine(cond);
            }
            writer.PopIdent();

            writer.WriteLine("where");
            writer.PushIdent();
            for (int i = 0; i < keyColumns.Count; i++)
            {
                Column column = keyColumns[i];
                string and = i < keyColumns.Count - 1 ? "and" : "";
                string cond = string.Format("`{0}` = {0} {1}", column.Name, and).Trim();
                writer.WriteLine(cond);
            }
            writer.WriteNoIdent(";");
            writer.PopIdent();
            return writer.Code;
        }

        public string generateDeleteBody(Table table, List<Column> keyColumns)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLineFormat("delete from `{0}`.`{1}`", table.Schema.Name, table.Name);
            writer.WriteLine("where");
            writer.PushIdent();
            for (int i = 0; i < keyColumns.Count; i++)
            {
                Column column = keyColumns[i];
                string and = i < keyColumns.Count - 1 ? "and" : "";
                string cond = string.Format("`{0}` = {0} {1}", column.Name, and).Trim();
                writer.WriteLine(cond);
            }
            writer.WriteNoIdent(";");
            writer.PopIdent();
            return writer.Code;
        }

        private string generateGetBody(Table table, List<Column> keyColumns)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine("select *");
            writer.WriteLineFormat("from `{0}`.`{1}`", table.Schema.Name, table.Name);
            writer.WriteLine("where");
            writer.PushIdent();
            for (int i = 0; i < keyColumns.Count; i++)
            {
                Column column = keyColumns[i];
                string and = i < keyColumns.Count - 1 ? "and" : "";
                string cond = string.Format("`{0}` = {0} {1}", column.Name, and).Trim();
                writer.WriteLine(cond);
            }
            writer.WriteNoIdent(";");
            writer.PopIdent();
            return writer.Code;
        }


        public override string GenerateInsert(Table table)
        {
            CodeWriter writer = new CodeWriter();
            StoredProcedure sp = new StoredProcedure();
            sp.Schema = table.Schema;
            sp.Name = string.Format("hxf_{0}_insert", table.Name);
            IEnumerable<Column> insertableColumns = table.Columns.Where<Column>(c => !(c.IsComputed || c.IsAutoIncremented));
            List<Parameter> parameters = new List<Parameter>();
            int i = 0;
            foreach (Column col in insertableColumns)
            {
                Parameter p = new Parameter();
                p.Name = col.Name;
                p.Position = i++;
                p.DataType = col.DataType.Clone();
                p.Mode = "IN";
                parameters.Add(p);
            }
            sp.Parameters = parameters;
            sp.Definition = generateInsertBody(table, insertableColumns.ToList<Column>());
            string s = new MySqlDatabaseGenerator(TypeMap).GenerateStoredProcedureCreate(sp).Trim();
            writer.WriteLineFormat("-- {0} --", sp.Name);
            writer.WriteLineFormat(s);
            return writer.Code;
        }

        public override string GenerateGetAll(Table table)
        {
            CodeWriter writer = new CodeWriter();
            StoredProcedure sp = new StoredProcedure();
            sp.Parameters = new List<Parameter>();
            sp.Schema = table.Schema;
            sp.Name = string.Format("hxf_{0}_get_all", table.Name);
            string body = string.Format("select * from `{0}`.`{1}`;", table.Schema.Name, table.Name);
            sp.Definition = body;
            string s = new MySqlDatabaseGenerator(this.TypeMap).GenerateStoredProcedureCreate(sp).Trim();
            writer.WriteLineFormat("-- {0} --", sp.Name);
            writer.WriteLine(s);
            return writer.Code;
        }

        public override string GenerateGet(Table table)
        {
            CodeWriter writer = new CodeWriter();
            foreach (TableConstraint constraint in table.Constraints)
            {
                if (constraint.Type == ConstraintType.PrimaryKey || constraint.Type == ConstraintType.Unique)
                {
                    StoredProcedure sp = new StoredProcedure();
                    sp.Parameters = new List<Parameter>();
                    sp.Schema = table.Schema;
                    List<string> colNames = constraint.Columns;
                    string sepStrings = StringUtils.GenerateSeparatedString(colNames, "_and_", "", "");
                    sp.Name = string.Format("hxf_{0}_get_by_{1}", table.Name, sepStrings);
                    IEnumerable<Column> keyColumns = table.Columns.Where<Column>(c => colNames.Contains(c.Name));
                    string body = generateGetBody(table, keyColumns.ToList<Column>());
                    foreach (Column column in keyColumns)
                    {
                        Parameter p = new Parameter();
                        p.StoredProcedure = sp;
                        p.Name = column.Name;
                        //p.Direction = ParameterDirection.In;
                        p.Mode = "IN";
                        p.DataType = TypeMap != null ? TypeMap.MapDataType(column.DataType) : column.DataType;
                        sp.Parameters.Add(p);
                        sp.Definition = body;
                    }
                    MySqlDatabaseGenerator gen = new MySqlDatabaseGenerator(TypeMap);
                    string s = gen.GenerateStoredProcedureCreate(sp).Trim();
                    writer.WriteLineFormat("-- {0} --", sp.Name);
                    writer.WriteLine(s);
                    writer.WriteLine();
                }
            }

            return writer.Code;
        }

        public override string GenerateUpdate(Table table)
        {
            CodeWriter writer = new CodeWriter();
            foreach (TableConstraint constraint in table.Constraints)
            {
                if (constraint.Type == ConstraintType.PrimaryKey || constraint.Type == ConstraintType.Unique)
                {
                    StoredProcedure sp = new StoredProcedure();
                    sp.Parameters = new List<Parameter>();
                    sp.Schema = table.Schema;
                    List<string> colNames = constraint.Columns;
                    string sepStrings = StringUtils.GenerateSeparatedString(colNames, "_and_", "", "");
                    sp.Name = string.Format("hxf_{0}_update_by_{1}", table.Name, sepStrings);
                    // columns that are part of key constraint is used in where clause
                    IEnumerable<Column> keyColumns = table.Columns.Where<Column>(c => colNames.Contains(c.Name));

                    // columns that can be updated
                    IEnumerable<Column> updatableColumns = table.Columns.Where<Column>(c => !(c.IsComputed || c.IsAutoIncremented));

                    // columns that will be part of update statement
                    IEnumerable<Column> updateColumns = updatableColumns.Except(keyColumns);

                    string body = generateUpdateBody(table, keyColumns.ToList<Column>(), updateColumns.ToList<Column>());

                    // create parameters for columns used in the stored procedure
                    foreach (Column column in keyColumns.Union(updatableColumns))
                    {
                        Parameter p = new Parameter();
                        p.StoredProcedure = sp;
                        p.Name = column.Name;
                        //p.Direction = ParameterDirection.In;
                        p.Mode = "IN";
                        p.DataType = TypeMap != null ? TypeMap.MapDataType(column.DataType) : column.DataType;
                        sp.Parameters.Add(p);
                        sp.Definition = body;
                    }
                    MySqlDatabaseGenerator gen = new MySqlDatabaseGenerator(TypeMap);
                    string s = gen.GenerateStoredProcedureCreate(sp).Trim();
                    writer.WriteLineFormat("-- {0} --", sp.Name);
                    writer.WriteLine(s);
                    writer.WriteLine();
                }
            }

            return writer.Code;
        }

        public override string GenerateDelete(Table table)
        {
            CodeWriter writer = new CodeWriter();
            foreach (TableConstraint constraint in table.Constraints)
            {
                if (constraint.Type == ConstraintType.PrimaryKey || constraint.Type == ConstraintType.Unique)
                {
                    StoredProcedure sp = new StoredProcedure();
                    sp.Parameters = new List<Parameter>();
                    sp.Schema = table.Schema;
                    List<string> colNames = constraint.Columns;
                    string sepStrings = StringUtils.GenerateSeparatedString(colNames, "_and_", "", "");
                    sp.Name = string.Format("hxf_{0}_delete_by_{1}", table.Name, sepStrings);
                    IEnumerable<Column> keyColumns = table.Columns.Where<Column>(c => colNames.Contains(c.Name));
                    string body = generateDeleteBody(table, keyColumns.ToList<Column>());
                    foreach (Column column in keyColumns)
                    {
                        Parameter p = new Parameter();
                        p.StoredProcedure = sp;
                        p.Name = column.Name;
                        //p.Direction = ParameterDirection.In;
                        p.Mode = "IN";
                        p.DataType = TypeMap != null ? TypeMap.MapDataType(column.DataType) : column.DataType;
                        sp.Parameters.Add(p);
                        sp.Definition = body;
                    }
                    MySqlDatabaseGenerator gen = new MySqlDatabaseGenerator(TypeMap);
                    string s = gen.GenerateStoredProcedureCreate(sp).Trim();
                    writer.WriteLineFormat("-- {0} --", sp.Name);
                    writer.WriteLine(s);
                    writer.WriteLine();
                }
            }

            return writer.Code;
        }

        public override string GetPlatform()
        {
            return "MYSQL";
        }

        public override string GetName()
        {
            return "MySql Satandard CRUD Generator";
        }
    }
}
