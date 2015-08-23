using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Conf
{
    public class MySqlDefaultConf: SQLConf
    {
        protected override string getXML()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var resourceName = "HXF.Persistence.Res.mysql.xml";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                StreamReader reader = new StreamReader(stream);
                string xml = reader.ReadToEnd();
                return xml;
            }
        }
    }
}
