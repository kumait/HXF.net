using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Conf
{
    public class CustomSqlConf: SQLConf
    {
        private readonly string filePath;

        public CustomSqlConf(string path)
        {
            this.filePath = path;
        }

        protected override string getXML()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string xml = reader.ReadToEnd();
                return xml;
            }
        }
    }
}
