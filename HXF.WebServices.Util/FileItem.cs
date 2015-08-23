using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Util
{
    public class FileItem
    {
        public string FileName {get; set;}
        public string Code {get; set;}

        public FileItem(string fileName, string code)
        {
            this.FileName = fileName;
            this.Code = code;
        }

        public override string ToString()
        {
            return FileName;
        }
    }
}
