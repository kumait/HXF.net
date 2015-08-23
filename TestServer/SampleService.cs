using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestServer
{
    public class SampleService: ISampleService
    {
        public string SayHello(string name)
        {
            return "Hello, " + name;
        }
    }
}