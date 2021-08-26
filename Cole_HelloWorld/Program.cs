using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cole_HelloWorld  
{
    //Class: Program
    //Author: Brandon Cole
    //Purpose: Print my name and ask for users name and then print it
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Print my name and ask for users name and then print it
        //Restrictions: None
        static void Main(string[] args)
        {
            Console.WriteLine("Brandon Cole");
            string sName = null;
            Console.Write("Enter your name: ");
            sName = Console.ReadLine();
            Console.WriteLine("Your name is " + sName);
        }
    }
}
