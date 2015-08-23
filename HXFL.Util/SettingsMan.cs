using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HXF.Util
{
    public static class SettingsMan
    {
        public static string getPath()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "settings.json");
            return path;

        }

        public static JObject Load()
        {
            JObject jo = null;
            if (File.Exists(getPath()))
            {
                string json = File.ReadAllText(getPath());
                jo = JObject.Parse(json);
            }
            return jo;
        }

        public static void Save(JObject settings)
        {
            File.WriteAllText(getPath(), JsonConvert.SerializeObject(settings));
        }
    }
}
