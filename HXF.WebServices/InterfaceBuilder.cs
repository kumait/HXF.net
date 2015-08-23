using HXF.WebServices.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices
{
    public class InterfaceBuilder
    {
        public static Interface BuildFromInterfaceConf(InterfaceConfiguration interfaceConf)
        {
            validate(interfaceConf.RuntimeInfo.InterfaceType);
            Interface intr = new Interface();
            intr.Name = interfaceConf.Name;
            intr.Description = interfaceConf.Description;
            createMethods(intr, interfaceConf.RuntimeInfo.InterfaceType);
            return intr;
        }

        public static Interface BuildFromInterfaceType(Type interfaceType)
        {
            validate(interfaceType);
            Interface intr = new Interface();
            createMethods(intr, interfaceType);
            return intr;
        }

        private static void validate(Type interfaceType)
        {
            if (interfaceType == null)
            {
                throw new ArgumentNullException("interfaceType");
            }

            if (!interfaceType.IsInterface)
            {
                throw new Exception("invalid interface type, type is not an interface");
            }
        }

        private static void createMethods(Interface intr, Type interfaceType)
        {
            intr.Methods = new List<Method>();
            foreach (MethodInfo mi in interfaceType.GetMethods())
            {
                Method m = new Method();
                m.Name = mi.Name;
                m.Parameters = new List<Parameter>();
                foreach (ParameterInfo pi in mi.GetParameters())
                {
                    Parameter p = new Parameter();
                    p.Name = pi.Name;
                    p.Type = GetTypeName(pi.ParameterType);
                    m.Parameters.Add(p);
                }
                m.ReturnType = GetTypeName(mi.ReturnType);
                intr.Methods.Add(m);
            }
        }

        public static string GetTypeName(Type type)
        {
            string typeName = "";
            if (type == null)
            {
                typeName = "";
            }
            else if (type.FullName == "System.Void")
            {
                typeName = "Void";
            } 
            else if (type.IsValueType)
            {
                typeName = type.Name;
            }
            else if (type.IsArray)
            {
                typeName = type.Name;
            }
            else
            {
                if (type.Name == "String")
                {
                    typeName = "String";
                }
                else if (type.GetInterface("ICollection") != null)
                {
                    typeName = "List";
                    
                    string elementType = "";
                    if (type.IsGenericType)
                    {
                        Type[] args = type.GetGenericArguments();
                        if (args.Length > 0)
                        {
                            elementType = GetTypeName(args[0]);
                        }
                    }
                    else
                    {
                        Type tt = type.GetElementType();
                        elementType = GetTypeName(type.GetElementType());
                    }

                    if (!string.IsNullOrEmpty(elementType))
                    {
                        typeName += "<" + elementType + ">";
                    }
                }
                else
                {
                    typeName = "Object";
                }
            }
            return typeName;
        }
    }
}
