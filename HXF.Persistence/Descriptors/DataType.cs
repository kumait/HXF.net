using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Descriptors
{
    public class DataType
    {
        public string Name { get; set; }
        public long? Precision { get; set; }
        public long? Scale { get; set; }

        public DataType(string Name, long? Precision, long? Scale)
        {
            this.Name = Name;
            this.Precision = Precision;
            this.Scale = Scale;
        }

        public DataType() : this(null, null, null) { }
        
        public string FullName
        {
            get
            {
                return DataType.GetFullName(this.Name, this.Precision, this.Scale);
            }
        }

        public static string GetFullName(string name, long? precision, long? scale)
        {
            string s1 = precision == null? "" : precision == -1? "(max" : "(" + precision;
            string s2 = scale == null ? "" : ", " + scale;
            string s = precision == null ? "" : s1 + s2 + ")";
            return name + s;
        }

        public DataType Clone()
        {
            DataType dt = new DataType(this.Name, this.Precision, this.Scale);
            return dt;
        }
    }
}
