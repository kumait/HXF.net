
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HXF.WebServices.Generators
{
    public class TypeMap
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SourcePlatform { get; set; }
        public string TargetPlatform { get; set; }
        public List<TypeMapRule> rules;

        public TypeMap(JObject jo)
        {
            parseJson(jo);
        }

        private void parseJson(JObject jo)
        {
            this.rules = new List<TypeMapRule>();
            this.Name = jo.GetValue("name").ToString();
            this.Description = jo.GetValue("description").ToString();
            this.SourcePlatform = jo.GetValue("source_platform").ToString();
            this.TargetPlatform = jo.GetValue("target_platform").ToString();
            JArray ja = (JArray)jo.GetValue("rules");
            foreach (JToken jt in ja)
            {
                JArray a = (JArray)jt;
                TypeMapRule rule = new TypeMapRule();
                rule.FromType = a[0] != null ? a[0].ToString() : null;
                rule.ToType = a[1] != null ? a[1].ToString() : null;
                rules.Add(rule);
            }
        }
        
        public static TypeMap FromJson(string json)
        {
            JObject jo = JObject.Parse(json);
            return new TypeMap(jo);
        }

        public static TypeMap FromFile(string file)
        {
            using (StreamReader reader = File.OpenText(file)) {
                JObject jo = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                return new TypeMap(jo);
            }
        }

        private TypeMapRule getRule(string from)
        {
            foreach(TypeMapRule rule in rules) {
                bool match = rule.FromType == from;
                if (match)
                {
                    return rule;
                }
            }
            return null;
        }

        private bool isGeneric(string type)
        {
            string pattern = "^[a-zA-Z]+<[a-zA-Z0-9]+>$";
            bool b = Regex.IsMatch(type, pattern);
            return b;
        }

        private bool isArray(string type)
        {
            //string pattern = @"^[a-zA-Z]+\[\]$";
            //bool b = Regex.IsMatch(type, pattern);
            bool b = type.EndsWith("[]");
            return b;
        }

        public string MapDataType(string type)
        {
            string mappedType = null;
            if (isGeneric(type))
            {
                int p = type.IndexOf("<");
                string outType = type.Substring(0, p) + "<>";
                string innerType = type.Substring(p + 1, type.Length - p - 2);
                mappedType = string.Format("{0}<{1}>", MapDataType(outType), MapDataType(innerType));
            }
            else if (isArray(type))
            {
                string tt = type.Replace("[]", "");
                mappedType = MapDataType(tt) + "[]";
            } 
            else
            {
                TypeMapRule rule = getRule(type);
                if (rule == null)
                {
                    throw new Exception("Type:" + type + " not supported");
                }
                else
                {
                    mappedType = rule.ToType;
                }
            }

            return mappedType;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
