using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.Sql
{
    public interface ISqlGenerator
    {
        string Generate(Schema schema);
        string GetName();
        string GetPlatform();
        TypeMap TypeMap { get; set; }
    }
}
