using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    public interface ISampleService
    {
        string SayHello(string name);
        int Sum(int x, int y);
    }
}
