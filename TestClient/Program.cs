using Newtonsoft.Json.Linq;
using sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleServiceClient client = new SampleServiceClient();
            JObject j1 = client.SayHello("HXF");
            Console.WriteLine(j1["Value"]);

            JObject j2 = client.Sum(5, 3);
            Console.WriteLine(j2["Value"]);
        }
    }
}
