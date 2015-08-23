using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices
{
    public class InterfaceConfiguration
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RuntimeInfo RuntimeInfo { get; set; }

        public InterfaceConfiguration(string name, string description, RuntimeInfo runtimeInfo)
        {
            this.Name = name;
            this.Description = description;
            this.RuntimeInfo = runtimeInfo;
        }

        public InterfaceConfiguration(string name, RuntimeInfo runtimeInfo) : this(name, "", runtimeInfo) { }

        public InterfaceConfiguration() : this(null, null, null) { }
    }
}
