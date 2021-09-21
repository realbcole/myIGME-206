using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1Q3
{
    // Class: Program
    // Author: Brandon Cole
    // Purpose: Create delegate function to impersonate the console.readline() function when asking for user input
    // Restrictions: None
    class Program
    {
        delegate string Readline();

        // Method: Main
        // Purpose: Create delegate function to impersonate console.readline()
        // Restrictions: None
        static void Main(string[] args)
        {
            Readline readline;

            readline = new Readline(Console.ReadLine);

            Console.WriteLine("Please enter a string: ");
            string response = readline();

            Console.WriteLine(response);
        }
    }
}
