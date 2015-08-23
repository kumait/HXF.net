using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Descriptors
{
    public class Method
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Parameter> Parameters { get; set; }
        public string ReturnType { get; set; }
    }
}
