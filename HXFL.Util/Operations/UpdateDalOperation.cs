using HXF.Persistence;
using HXF.Persistence.Conf;
using HXF.Persistence.Descriptors;
using HXF.Persistence.Generators;
using HXF.Persistence.Generators.DataAccess;
using HXF.Persistence.Naming;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Util.Operations
{
    public class UpdateDalOperation: Operation
    {
        private readonly string dalLocation;
        private readonly bool useCSNaming;

        public UpdateDalOperation(string dalLocation, bool useCSNaming)
        {
            this.dalLocation = dalLocation;
            this.useCSNaming = useCSNaming;
            this.Status = OperationStatus.WAITING;
            this.Name = "Updating DAL Files";
        }

        private void saveToFile(string file, string content)
        {
            FileStream fs = new FileStream(file, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            writer.Write(content);
            writer.Flush();
            writer.Close();
        }

        public override void Execute(IDictionary<string, object> scope)
        {
            try
            {
                this.Status = OperationStatus.RUNNING;
                SqlConnection conn = scope["CONNECTION"] as SqlConnection;
                Schema schema = scope["SCHEMA"] as Schema;
                DatabaseExplorer exp = new DatabaseExplorer(conn, new SQLServerDefaultConf());
               
                INamingAdapter adapter = null;
                if (useCSNaming)
                {
                    adapter = new CSNamingAdapter();
                }
                else
                {
                    adapter = new SameNamingAdapter();
                }

                GeneratorOptions options = new GeneratorOptions() { SupportsReturnValue = true, NamingAdapter = new CSNamingAdapter() };

                ResourceManager resMan = new ResourceManager();
                List<TypeMap> tts = resMan.GetDataAccessTypeMaps();
                TypeMap tm = resMan.GetDataAccessTypeMaps().Where<TypeMap>(t => t.Name == "SqlServer -> C# Standard Type Map").FirstOrDefault<TypeMap>();
                CSharpDataAccessGenerator gen = new CSharpDataAccessGenerator(tm, options);

                string entitiesCode = gen.GenerateEntities(schema);
                string entityFile = Path.Combine(dalLocation, "Entities.cs");
                saveToFile(entityFile, entitiesCode);

                string interfaceCode = gen.GenerateInterface(schema);
                string interfaceFile = Path.Combine(dalLocation, "IDataStore.cs");
                saveToFile(interfaceFile, interfaceCode);

                string storeCode = gen.GenerateClass(schema);
                string storeFile = Path.Combine(dalLocation, "DataStore.cs");
                saveToFile(storeFile, storeCode);
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
            throw new NotImplementedException();
        }
    }
}
