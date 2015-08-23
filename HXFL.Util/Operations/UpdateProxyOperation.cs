using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Util.Operations
{
    public class UpdateProxyOperation: Operation
    {
        private string url;
        private string platform;
        private string proxyLocation;

        public UpdateProxyOperation(string url, string platform, string proxyLocation)
        {
            this.url = url;
            this.platform = platform;
            this.proxyLocation = proxyLocation;
            this.Name = "Generating Proxy Code";
        }

        public override void Execute(IDictionary<string, object> scope)
        {
            try
            {
                this.Status = OperationStatus.RUNNING;
                string fullUrl = string.Format("{0}?action=code&platform={1}&format=JSON", this.url, this.platform);
                WebClient client = new WebClient();
                byte[] data = client.DownloadData(fullUrl);
                string dataString = Encoding.UTF8.GetString(data);
                JObject jobject = JObject.Parse(dataString);
                foreach (JProperty p in jobject.Properties())
                {
                    string fileName = Path.Combine(this.proxyLocation, p.Name);
                    File.WriteAllText(fileName, jobject[p.Name].ToString(), Encoding.UTF8);
                }
                this.Status = OperationStatus.COMPLETED;
            }
            catch (Exception ex)
            {
                this.Exception = ex;
                this.Status = OperationStatus.FAILED;
                throw ex;
            }
        }

        public override void Clean(IDictionary<string, object> scope)
        {
            
        }
    }
}
