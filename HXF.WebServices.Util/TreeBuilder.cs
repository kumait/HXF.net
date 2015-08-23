using HXF.WebServices.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HXF.WebServices.Util
{
    public class TreeBuilder
    {
        private Service service;

        public TreeBuilder(Service service)
        {
            this.service = service;
        }

        public TreeNode Build()
        {
            TreeNode rootNode = new TreeNode(service.Name + " [" + service.Platform + "]", 0, 0);
            rootNode.Tag = service;
            TreeNode interfacesNode = new TreeNode("Interfaces", 1, 1);
            buildInterfacesNode(interfacesNode);
            rootNode.Nodes.Add(interfacesNode);
            return rootNode;

        }

        private void buildInterfacesNode(TreeNode parentNode)
        {
            foreach (Interface intr in service.Interfaces)
            {
                TreeNode interfaceNode = new TreeNode(intr.Name, 2, 2);
                TreeNode methodsNode = new TreeNode("Methods", 1, 1);
                buildMethodsNode(intr, methodsNode);
                interfaceNode.Nodes.Add(methodsNode);
                parentNode.Nodes.Add(interfaceNode);
            }
        }

        private void buildMethodsNode(Interface intr, TreeNode parentNode)
        {
            foreach (Method method in intr.Methods)
            {
                TreeNode methodNode = new TreeNode(method.Name, 3, 3);
                methodNode.Tag = method;
                TreeNode parametersNode = new TreeNode("Parameters", 1, 1);
                buildParametersNode(method, parametersNode);
                methodNode.Nodes.Add(parametersNode);
                parentNode.Nodes.Add(methodNode);
            }
        }

        private void buildParametersNode(Method method, TreeNode parentNode)
        {
            foreach (Parameter p in method.Parameters)
            {
                TreeNode parameterNode = new TreeNode(p.Name + " [" + p.Type + "]", 4, 4);
                parameterNode.Tag = p;
                parentNode.Nodes.Add(parameterNode);
            }
        }


    }
}
