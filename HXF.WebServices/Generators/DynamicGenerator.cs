using HXF.WebServices.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Generators
{
    public class DynamicGenerator: IProxyGenerator
    {
        private IProxyGenerator generator;

        public DynamicGenerator(IProxyGenerator generator)
        {
            this.generator = generator;
        }

        public DynamicGenerator(Type type)
        {
            if (!typeof(IProxyGenerator).IsAssignableFrom(type))
            {
                throw new Exception();
            }
            this.generator = (IProxyGenerator)Activator.CreateInstance(type);
        }

        public IDictionary<string, string> Generate(Service service)
        {
            return generator.Generate(service);
        }


        public string GetPlatform()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public TypeMap TypeMap
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
