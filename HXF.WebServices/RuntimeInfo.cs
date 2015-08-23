using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices
{
    public class RuntimeInfo
    {
        private Type interfaceType;
        private Type classType;

        public RuntimeInfo(Type interfaceType, Type classType)
        {
            this.validate(interfaceType, classType);
            this.interfaceType = interfaceType;
            this.classType = classType;
        }

        private void validate(Type interfaceType, Type classType)
        {
            if (interfaceType == null)
            {
                throw new ArgumentNullException("interfaceType");
            }

            if (classType == null)
            {
                throw new ArgumentNullException("classType");
            }

            if (!interfaceType.IsInterface)
            {
                throw new Exception("invalid interface type, type is not an interface");
            }

            if (!classType.IsClass)
            {
                throw new Exception("invalid class type, type is not a class");
            }

            if (classType.IsAbstract)
            {
                throw new Exception("invalid class type, type is abstract");
            }

            bool b = classType.GetInterfaces().Contains<Type>(interfaceType);
            if (!b)
            {
                throw new Exception("invalid types, provided class type doens't implement the provided interface type");
            }
        }

        public Type InterfaceType
        {
            get
            {
                return this.interfaceType;
            }
        }

        public Type ClassType
        {
            get
            {
                return this.classType;
            }
        }
    }
}
