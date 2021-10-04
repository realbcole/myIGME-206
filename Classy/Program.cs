using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classy
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            Class2 class2 = new Class2();
            MyMethod(class1);
            MyMethod(class2);
        }

        public static void MyMethod(object myObject)
        {
            IInterface test = (IInterface)myObject;
            test.DoSomething();
        }

        public class Class1 : IInterface
        {
            public void DoSomething()
            {
                Console.WriteLine("Did something!");
            }
        }

        public class Class2 : IInterface
        {
            public void DoSomething()
            {
                Console.WriteLine("Did something else!");
            }
        }

        public interface IInterface
        {
            void DoSomething();
        }
    }
}

