using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.Sql
{
    public interface IDatabaseGenerator: ISqlGenerator
    {
        string GenerateTables(Schema schema);
        string GenerateStoredProcedures(Schema schema);
        string GenerateSqlCreate(Table table);
        string GenerateStoredProcedureCreate(StoredProcedure storedProcedure);
    }
}
