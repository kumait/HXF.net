using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HXF.Persistence.Conf
{
    public abstract class SQLConf: ISqlConf
    {
        private IDictionary<string, string> dic;
        
        protected SQLConf()
        {
            dic = new Dictionary<string, string>();
            loadXML(getXML());
        }

        protected abstract string getXML();

        private void loadXML(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            IEnumerable<XElement> statements = doc.Elements();

            foreach (var statement in statements.Elements())
            {
                string id = statement.Element("id").Value.Trim();
                string content = statement.Element("content").Value.Trim();
                dic[id] = content;
            }
        }

        public string GetSql(Statement statement)
        {
            return dic[statement.ToString()];
        }
    }
}
