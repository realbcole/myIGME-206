using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE12Q3
{
    // Class Program
    // Author: Brandon Cole
    // Purpose: derive class from other class
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: instantiate a myderivedclass object and call getstring
        // Restrictions: None
        static void Main(string[] args)
        {
            MyDerivedClass brandon = new MyDerivedClass();
            Console.WriteLine(brandon.GetString(brandon));
        }
    }
    // Class: MyClass
    // Author: Brandon Cole
    // Purpose: parent class
    // Restrictions: None
    public class MyClass
    {
        private string myString = "brandon";
        public string MyString { set { MyString = value; } }
        public virtual string GetString(MyClass obj)
        {
            return obj.myString;
        }
    }
    // Class: MyDerivedClass
    // Author: Brandon Cole
    // Purpose: derived class, append something to string returned by GetString
    // Restrictions: None
    public class MyDerivedClass : MyClass
    {
        public override string GetString(MyClass obj)
        {
            return base.GetString(obj) + "(output from the derived class)";
        }
    }
}
