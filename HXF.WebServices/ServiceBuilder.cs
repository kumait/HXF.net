using HXF.WebServices.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices
{
    public class ServiceBuilder
    {
        public static Service BuildFromServiceConf(ServiceConfiguration serviceConf) {
            Service svc = new Service(serviceConf.Name);
            svc.Description = serviceConf.Description;
            svc.Interfaces = new List<Interface>();
            foreach (InterfaceConfiguration iconf in serviceConf.InterfaceConfigs)
            {
                Interface intr = InterfaceBuilder.BuildFromInterfaceType(iconf.RuntimeInfo.InterfaceType);
                intr.Name = iconf.Name;
                intr.Description = iconf.Description;
                svc.Interfaces.Add(intr);
            }
            return svc;
        }
    }
}
