using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXF.Persistence.Naming
{
    public interface INamingAdapter
    {
        string GetClassName(string tableName);
        string GetMethodName(string spName);
        string GetParameterName(string fieldName);
        string GetFieldName(string propertyName);
        string GetPropertyName(string fieldName);
    }
}
