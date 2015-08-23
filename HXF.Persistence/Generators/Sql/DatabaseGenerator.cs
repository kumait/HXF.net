using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.Sql
{
    public abstract class DatabaseGenerator: IDatabaseGenerator
    {
        public TypeMap TypeMap { get; set; }

        public DatabaseGenerator(TypeMap typeMap)
        {
            this.TypeMap = typeMap;
        }

        public DatabaseGenerator() : this(null) { }

        public abstract string Generate(Schema schema);
        public abstract string GenerateTables(Schema schema);
        public abstract string GenerateStoredProcedures(Schema schema);
        public abstract string GenerateSqlCreate(Table table);
        public abstract string GenerateStoredProcedureCreate(StoredProcedure storedProcedure);
        public abstract string GetPlatform();
        public abstract string GetName();
    }
}
