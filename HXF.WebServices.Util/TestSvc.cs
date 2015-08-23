using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.WebServices.Util
{
    public interface ISimpleInterface
    {
        string Ping();
        string SayHello(string name);
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public interface ITestInterface
    {
        int Sum(int x, int y);
        Student[] GetStudents();
    }

    public class SimpleInterfaceImpl: ISimpleInterface
    {
        public string Ping()
        {
            return "SERVICE_ONLINE";
        }

        public string SayHello(string name)
        {
            return string.Format("Hello, {0}", name);
        }
    }

    public class TestInterfaceImpl: ITestInterface
    {

        public int Sum(int x, int y)
        {
            int z = x + y;
            return z;
        }

        public Student[] GetStudents()
        {
            Student[] students = { new Student() { Name = "Kumait", Age = 33 }, new Student() { Name = "Maram", Age = 30 } };
            return students;
        }
    }
}
