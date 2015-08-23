using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.Sql
{
    public abstract class CrudGenerator: ICrudGenerator
    {
        public TypeMap TypeMap { get; set; }

        public CrudGenerator(TypeMap typeMap)
        {
            this.TypeMap = typeMap;
        }

        public abstract string Generate(Schema schema);
        public abstract string GenerateInsert(Table table);
        public abstract string GenerateGetAll(Table table);
        public abstract string GenerateGet(Table table);
        public abstract string GenerateUpdate(Table table);
        public abstract string GenerateDelete(Table table);
        public abstract string GetPlatform();
        public abstract string GetName();
    }
}
