using HXF.Persistence.Naming;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public static class ReaderUtils
    {
        public static bool HasColumn(this IDataReader reader, string columnName)
        {
            bool found = false;

            int i = 0;
            while (!found && i < reader.FieldCount)
            {
                found = columnName.Equals(reader.GetName(i), StringComparison.OrdinalIgnoreCase);
                i++;
            }
            return found;
        }

        
        public static List<object> MapToList(IDataReader reader, Type itemType, INamingAdapter adapter)
        {
            List<object> list = new List<object>();
            while (reader.Read())
            {
                object item = Activator.CreateInstance(itemType);
                foreach (PropertyInfo pi in itemType.GetProperties())
                {
                    string dbField = adapter.GetFieldName(pi.Name);
                    if (reader.HasColumn(dbField))
                    {
                        if (reader[dbField].GetType() != typeof(DBNull))
                        {
                            pi.SetValue(item, reader[dbField], null);
                        }
                    }
                }
                list.Add(item);
            }
            return list;
        }
    }
}
