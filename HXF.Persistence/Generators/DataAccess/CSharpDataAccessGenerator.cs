using HXF.Common;
using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.DataAccess
{
    public class CSharpDataAccessGenerator: DataAccessGenerator
    {
        public GeneratorOptions Options { get; set; }
        private const string USING_STRING =
@"using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using HXF.Persistence;
using HXF.Persistence.Naming;";


        public CSharpDataAccessGenerator(TypeMap typeMap, GeneratorOptions options)
        {
            this.TypeMap = typeMap;
            this.Options = options;
        }

        public CSharpDataAccessGenerator() : this(null, null) { }

        public override string GenerateInterface(Schema schema)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine(USING_STRING);
            writer.WriteLine();
            writer.WriteLine("namespace DataAccess");
            writer.WriteLine("{");
            writer.PushIdent();
            writer.WriteLine("public interface IDataStore");
            writer.WriteLine("{");
            writer.PushIdent();
            foreach (StoredProcedure sp in schema.StoredProcedures)
            {
                string methodHeader = generateMethodHeader(sp) + ";";
                writer.WriteLine(methodHeader);
            }
            writer.PopIdent();
            writer.WriteLine("}");
            writer.PopIdent();
            writer.WriteLine("}");
            return writer.Code;
        }

        public override string GenerateClass(Schema schema)
        {
            CodeWriter writer = new CodeWriter();
            string className = "DataStore";
            writer.WriteLine(USING_STRING);
            writer.WriteLine();
            writer.WriteLine("namespace DataAccess");
            writer.WriteLine("{");
            writer.PushIdent();
            writer.WriteLineFormat("public class {0}: DatabaseContext, IDataStore", className);
            writer.WriteLine("{");
            writer.PushIdent();
            writer.WriteLineFormat("public {0}(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction) {{ }}", className);
            writer.WriteLineFormat("public {0}(IDbConnection connection) : base(connection, null) {{ }}", className);
            writer.WriteLine();
            
            foreach (StoredProcedure sp in schema.StoredProcedures)
            {
                string methodHeader = "public " + generateMethodHeader(sp);
                string methodBody = GenerateMethodBody(sp);
                writer.WriteLine(methodHeader);
                writer.WriteLine(methodBody);
                writer.WriteLine();
            }
            writer.PopIdent();
            writer.WriteLine("}");
            writer.PopIdent();
            writer.WriteLine("}");
            return writer.Code;
        }

        public override string GetName()
        {
            return "C# Standard Data Access Generator";
        }

        public override string GetPlatform()
        {
            return "C#";
        }

        private bool hasNamingAdapter
        {
            get
            {
                return (Options != null && Options.NamingAdapter != null);
            }
        }


        private string generateMethodHeader(StoredProcedure sp)
        {
            StringBuilder sb = new StringBuilder();
            List<string> paramDefs = new List<string>();
            string methodName = hasNamingAdapter? Options.NamingAdapter.GetMethodName(sp.Name): sp.Name;
            foreach (Parameter p in sp.Parameters)
            {
                string mode = p.Mode.ToLower();
                string prefix = mode == "inout" ? "ref" : mode == "out" ? "out" : "";
                string type = TypeMap == null ? p.DataType.Name : TypeMap.MapDataType(p.DataType).Name;
                string name = p.Name.Replace("@", "");
                if (hasNamingAdapter)
                {
                    name = Options.NamingAdapter.GetParameterName(name);
                }
                string def = string.Format("{0} {1} {2}", prefix, type, name);
                paramDefs.Add(def);
            }
            paramDefs.Add("params Type[] resultTypes");
            string paramDefString = StringUtils.GenerateCommaSeparatedString(paramDefs, "", "");
            string header = string.Format("StoredProcResult {0}({1})", methodName, paramDefString.Trim());
            return header;
        }

        private string GenerateMethodBody(StoredProcedure sp)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine("{");
            writer.PushIdent();
            writer.WriteLine("List<IDbDataParameter> parameters = null;");
            if (sp.Parameters.Count > 0)
            {
                writer.WriteLine("parameters = new List<IDbDataParameter>();");
                writer.WriteLine("IDbCommand cmd = connection.CreateCommand();");
                writer.WriteLine("if (this.transaction != null)");
                writer.WriteLine("{");
                writer.PushIdent();
                writer.WriteLine("cmd.Transaction = this.transaction;");
                writer.PopIdent();
                writer.WriteLine("}");
            }

            IEnumerable<Parameter> inParameters = sp.Parameters.Where<Parameter>(p => p.Mode.ToLower() == "in" || p.Mode.ToLower() == "inout");

            foreach (Parameter p in sp.Parameters)
            {
                string pname = p.Name.Replace("@", "");
                if (hasNamingAdapter)
                {
                    pname = Options.NamingAdapter.GetParameterName(pname);
                }
                writer.WriteLineFormat("IDbDataParameter p{0} = cmd.CreateParameter();", pname);
                writer.WriteLineFormat("p{0}.ParameterName = \"{1}\";", pname, p.Name);
                if (p.Mode.ToLower() == "in" || p.Mode.ToLower() == "inout")
                {
                    writer.WriteLineFormat("p{0}.Value = ({0} == null)? (object)DBNull.Value : {0};", pname);
                }
                string mode = p.Mode.ToLower();
                string pDirection = mode == "in" ? "ParameterDirection.Input" : mode == "out" ? "ParameterDirection.Output" : "ParameterDirection.InputOutput";
                writer.WriteLineFormat("p{0}.Direction = {1};", pname, pDirection);
                writer.WriteLineFormat("parameters.Add(p{0});", pname);
                writer.WriteLine();
            }

            string namingAdapterName = "";
            if (Options != null && Options.NamingAdapter != null)
            {
                namingAdapterName = this.Options.NamingAdapter.GetType().Name;
            }
            else
            {
                namingAdapterName = "SameNamingAdapter";
            }
            writer.WriteLineFormat("StoredProcResult result = ExecProc(\"{0}\", parameters, new {1}(), {2}, resultTypes);", sp.Name, namingAdapterName, Options.SupportsReturnValue.ToString().ToLower() );

            IEnumerable<Parameter> outParameters = sp.Parameters.Where<Parameter>(p => p.Mode.ToLower() == "out" || p.Mode.ToLower() == "inout");

            int index = 0;
            foreach (Parameter p in outParameters)
            {
                string pname = p.Name.Replace("@", "");
                if (hasNamingAdapter)
                {
                    pname = Options.NamingAdapter.GetParameterName(pname);
                }
                string ptype = TypeMap == null ? p.DataType.Name : TypeMap.MapDataType(p.DataType).Name;
                writer.WriteLineFormat("{0} = ({1})result.OutPramaters.ElementAt<IDbDataParameter>({2}).Value;", pname, ptype, index);
                index++;
            }
            writer.WriteLine();
            
            writer.WriteLine("return result;");
            writer.PopIdent();
            writer.WriteLine("}");
            return writer.Code;
        }

        public string GenerateEntity(Entity entity)
        {
            CodeWriter writer = new CodeWriter();
            string className = hasNamingAdapter? Options.NamingAdapter.GetClassName(entity.Name): entity.Name;
            writer.WriteLineFormat("public class {0}", className);
            writer.WriteLine("{");
            writer.PushIdent();

            foreach (Column column in entity.Columns)
            {
                string name = hasNamingAdapter? Options.NamingAdapter.GetPropertyName(column.Name): column.Name;
                string type = TypeMap == null ? column.DataType.Name : TypeMap.MapDataType(column.DataType).Name;
                string propertyDef = string.Format("public {0} {1} {{ get; set; }}", type, name);
                writer.WriteLine(propertyDef);
            }

            writer.PopIdent();
            writer.WriteLine("}");

            return writer.Code;
        }

        public override string GenerateEntities(Schema schema)
        {
            CodeWriter writer = new CodeWriter();
            writer.WriteLine(USING_STRING);
            writer.WriteLine();
            writer.WriteLine("namespace DataAccess");
            writer.WriteLine("{");
            writer.PushIdent();
            foreach (Table table in schema.Tables)
            {
                writer.WriteLine(GenerateEntity(table));
                writer.WriteLine();
            }
            writer.PopIdent();
            writer.WriteLine("}");
            return writer.Code;
        }
    }
}
