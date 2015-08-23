using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXF.Persistence.Naming
{
    public class CSNamingAdapter: INamingAdapter
    {
        private string convert(string value, bool pascalCase)
        {
            string s = value.ToLower();
            bool flag = false;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch == '_')
                {
                    flag = true;
                }
                else
                {
                    bool shouldCapitalize = flag || (pascalCase && i == 0);
                    if (shouldCapitalize)
                        sb.Append(ch.ToString().ToUpper());
                    else
                        sb.Append(ch);
                    flag = false;
                }
            }
            return sb.ToString();
        }



        public string GetClassName(string tableName)
        {
            return convert(tableName, true);
        }

        public string GetPropertyName(string fieldName)
        {
            return convert(fieldName, true);
        }

        public string GetMethodName(string spName)
        {
            return convert(spName, true);
        }

        public string GetParameterName(string fieldName)
        {
            return convert(fieldName, false);
        }

        public string GetFieldName(string propertyName)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < propertyName.Length; i++)
            {
                char ch = propertyName[i];
                if (char.IsUpper(ch) && i > 0)
                {
                    sb.Append("_");
                }
                sb.Append(ch.ToString().ToUpper());
            }
            return sb.ToString();
        }
    }
}
