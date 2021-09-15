using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE9Question3
{
    // Class: Program
    // Author: Brandon Cole
    // Purpose: Create delegate function to impersonate the console.readline() function when asking for user input
    // Restrictions: None
    class Program
    {

        delegate string ReadLine();

        // Method: Main
        // Purpose: Create delegate function to impersonate console.readline()
        // Restrictions: None
        static void Main(string[] args)
        {
            ReadLine readline;

            readline = new ReadLine(Console.ReadLine);

            Console.WriteLine("enter your name: ");
            string response = readline();

            Console.WriteLine(response);
        }
    }
}
