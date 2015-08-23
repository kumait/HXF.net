using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace sample
{
    public class SampleServiceClient
    {
        private const string SERVICE_URL = "http://localhost:53144/Service.ashx";
        private const int BUFFER_SIZE = 4096;
        
        private string Load(string contents)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(SERVICE_URL);
            req.AllowWriteStreamBuffering = true;
            req.Method = "POST";
            req.Timeout = 60000;
            Stream outStream = req.GetRequestStream();
            StreamWriter outStreamWriter = new StreamWriter(outStream);
            outStreamWriter.Write(contents);
            outStreamWriter.Flush();
            outStream.Close();
            WebResponse res = req.GetResponse();
            Stream httpStream = res.GetResponseStream();
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                byte[] buff = new byte[BUFFER_SIZE];
                int readedBytes = httpStream.Read(buff, 0, buff.Length);
                while (readedBytes > 0)
                {
                    memoryStream.Write(buff, 0, readedBytes);
                    readedBytes = httpStream.Read(buff, 0, buff.Length);
                }
            }
            finally
            {
                if (httpStream != null)
                {
                    httpStream.Close();
                }
        
                if (memoryStream != null)
                {
                    memoryStream.Close();
                }
            }
            byte[] data = memoryStream.ToArray();
            string result = Encoding.UTF8.GetString(data, 0, data.Length);
            return result;
        }
        
        
        public JObject SayHello(string name)
        {
            JObject result = null;
            JObject o = new JObject();
            JObject p = new JObject();
            o["interface"] = "SampleService";
            o["method"]= "SayHello";
            p["name"]= JToken.FromObject(name);
            o["parameters"] = p;
            string s = JsonConvert.SerializeObject(o);
            string r = Load(s);
            result = JObject.Parse(r);
            return result;
            
        }
        
        
        public JObject Sum(int x, int y)
        {
            JObject result = null;
            JObject o = new JObject();
            JObject p = new JObject();
            o["interface"] = "SampleService";
            o["method"]= "Sum";
            p["x"]= JToken.FromObject(x);
            p["y"]= JToken.FromObject(y);
            o["parameters"] = p;
            string s = JsonConvert.SerializeObject(o);
            string r = Load(s);
            result = JObject.Parse(r);
            return result;
            
        }
        
        
    }
}
