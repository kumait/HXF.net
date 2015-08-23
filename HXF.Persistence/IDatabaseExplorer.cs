using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public interface IDatabaseExplorer
    {
        IEnumerable<Catalog> GetCatalogs();
        IEnumerable<Schema> GetSchemas();
        IEnumerable<Table> GetTables(Schema schema);
        IEnumerable<Column> GetTableColumns(Table table);
        IEnumerable<TableConstraint> GetTableConstraints(Table table);
        IEnumerable<StoredProcedure> GetStoredProcedures(Schema schema);
        IEnumerable<Parameter> GetStoredProcedureParameters(StoredProcedure storedProcedure);
    }
}
