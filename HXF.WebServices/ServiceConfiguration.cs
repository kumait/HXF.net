using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices
{
    public class ServiceConfiguration
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<InterfaceConfiguration> InterfaceConfigs { get; set; }

        public ServiceConfiguration(string name, string description = "")
        {
            this.Name = name;
            this.Description = description;
            this.InterfaceConfigs = new List<InterfaceConfiguration>();
        }

        public ServiceConfiguration() : this(null, null) { }

        public InterfaceConfiguration GetInterfaceConfiguration(string name)
        {
            InterfaceConfiguration conf = InterfaceConfigs.Where<InterfaceConfiguration>(i => i.Name == name).FirstOrDefault<InterfaceConfiguration>();
            return conf;
        }

        public void AddInterfaceConfig(string name, string description, Type interfaceType, Type classType)
        {
            InterfaceConfiguration iconf = new InterfaceConfiguration(name, description, new RuntimeInfo(interfaceType, classType));
            InterfaceConfigs.Add(iconf);
        }
    }
}
