using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.DataAccess
{
    public abstract class DataAccessGenerator: IDataAccessGenerator
    {
        public TypeMap TypeMap { get; set; }

        public abstract string GenerateInterface(Schema schema);
        public abstract string GenerateClass(Schema schema);
        public abstract string GenerateEntities(Schema schema);
        public abstract string GetName();
        public abstract string GetPlatform();
    }
}
