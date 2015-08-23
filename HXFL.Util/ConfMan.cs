using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HXF.Util
{
    public static class ConfMan
    {
        public static Conf Load(string file)
        {
            string json = File.ReadAllText(file);
            Conf conf = JsonConvert.DeserializeObject<Conf>(json);
            return conf;
        }

        public static void Save(Conf conf, string file)
        {
            string json = JsonConvert.SerializeObject(conf);
            File.WriteAllText(file, json);
        }
    }
}
