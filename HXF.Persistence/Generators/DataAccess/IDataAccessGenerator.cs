using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.DataAccess
{
    public interface IDataAccessGenerator
    {
        string GenerateInterface(Schema schema);
        string GenerateClass(Schema schema);
        string GenerateEntities(Schema schema);
        string GetName();
        string GetPlatform();
        TypeMap TypeMap { get; set; }
    }
}
