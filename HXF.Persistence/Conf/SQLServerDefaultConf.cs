using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HXF.Persistence.Conf
{
    public class SQLServerDefaultConf: SQLConf
    {
        protected override string getXML()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var resourceName = "HXF.Persistence.Res.sqlserver.xml";
            string[] names = assembly.GetManifestResourceNames();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                StreamReader reader = new StreamReader(stream);
                string xml = reader.ReadToEnd();
                return xml;
            }
        }
    }
}
