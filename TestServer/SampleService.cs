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

        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}