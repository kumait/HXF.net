using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators.Sql
{
    public interface ICrudGenerator: ISqlGenerator
    {
        string GenerateInsert(Table table);
        string GenerateGetAll(Table table);
        string GenerateGet(Table table);
        string GenerateUpdate(Table table);
        string GenerateDelete(Table table);
    }
}
