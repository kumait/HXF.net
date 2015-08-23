using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Common
{
    public static class StringUtils
    {
        public static string GenerateCommaSeparatedString(List<string> values, string surround1, string surround2)
        {
            return GenerateSeparatedString(values, ", ", surround1, surround2);
        }

        public static string GenerateSeparatedString(List<string> values, string separator, string surround1, string surround2)
        {
            if (values.Count == 0)
                return "";

            StringBuilder sb = new StringBuilder();
            string val = "";
            int c = values.Count;
            for (int i = 0; i < c - 1; i++)
            {
                val = string.Format("{0}{1}{2}", surround1, values.ElementAt(i), surround2);
                sb.Append(val);
                sb.Append(separator);
            }
            val = string.Format("{0}{1}{2}", surround1, values.ElementAt(c - 1), surround2);
            sb.Append(val);
            string result = sb.ToString();
            return result;
        }
    }
}
