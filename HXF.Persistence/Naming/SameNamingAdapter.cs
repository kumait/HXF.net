using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXF.Persistence.Naming
{
    public class SameNamingAdapter: INamingAdapter
    {
        public string GetClassName(string tableName)
        {
            return tableName;
        }

        public string GetMethodName(string spName)
        {
            return spName;
        }

        public string GetParameterName(string fieldName)
        {
            return fieldName;
        }


        public string GetPropertyName(string fieldName)
        {
            return fieldName;
        }


        public string GetFieldName(string propertyName)
        {
            return propertyName;
        }
    }
}
