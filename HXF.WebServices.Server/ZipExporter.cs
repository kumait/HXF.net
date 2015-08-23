using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;
using System.IO.Packaging;

namespace HXF.WebServices.Server
{
    public class ZipExporter
    {
        public static byte[] Export(IDictionary<string, string> code)
        {
            MemoryStream mem = new MemoryStream();
            
            using (Package pkg = ZipPackage.Open(mem, FileMode.OpenOrCreate))
            {
                foreach (string key in code.Keys)
                {
                    Uri uri = PackUriHelper.CreatePartUri(new Uri(key, UriKind.Relative));
                    PackagePart part = pkg.CreatePart(uri, "text/plain");
                    Stream strm = part.GetStream();
                    byte[] buffer = Encoding.UTF8.GetBytes(code[key]);

                    strm.Write(buffer, 0, buffer.Length);
                    strm.Flush();
                    strm.Close();
                }
            }

            return mem.GetBuffer();
        }
    }
}
