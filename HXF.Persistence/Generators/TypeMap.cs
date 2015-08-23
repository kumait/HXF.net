using HXF.Persistence.Descriptors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Generators
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
                rule.FromPrecision = a[1] != null ? a[1].ToString() : null;
                rule.FromScale = a[2] != null ? a[2].ToString() : null;
                rule.ToType = a[3] != null ? a[3].ToString() : null;
                rule.ToPrecision = a[4] != null ? a[4].ToString() : null;
                rule.ToScale = a[5] != null ? a[5].ToString() : null;
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

        private TypeMapRule getRule(DataType dataType)
        {
            foreach(TypeMapRule rule in rules) {
                bool match =
                    (rule.FromType == dataType.Name) &&
                    (rule.FromPrecision == dataType.Precision.ToString() || rule.FromPrecision == "*") &&
                    (rule.FromScale == dataType.Scale.ToString() || rule.FromScale == "*");
                if (match)
                {
                    return rule;
                }
            }
            return null;
        }

        public DataType MapDataType(DataType fromDataType)
        {
            TypeMapRule rule = getRule(fromDataType);
            if (rule == null)
            {
                return fromDataType.Clone();
            }

            DataType dt = new DataType();
            dt.Name = rule.ToType;

            if (string.IsNullOrEmpty(rule.ToPrecision))
            {
                dt.Precision = null;
            }
            else if (rule.ToPrecision == "=")
            {
                dt.Precision = fromDataType.Precision;
            }
            else
            {
                dt.Precision = long.Parse(rule.ToPrecision);
            }

            if (string.IsNullOrEmpty(rule.ToScale))
            {
                dt.Scale = null;
            }
            else if (rule.ToScale == "=")
            {
                dt.Scale = fromDataType.Scale;
            }
            else
            {
                dt.Scale = long.Parse(rule.ToScale);
            }
            return dt;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
