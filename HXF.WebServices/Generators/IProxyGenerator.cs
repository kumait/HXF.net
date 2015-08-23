using HXF.WebServices.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Generators
{
    public interface IProxyGenerator
    {
        IDictionary<string, string> Generate(Service service);
        string GetPlatform();
        string GetName();
        TypeMap TypeMap { get; set; }
    }
}
