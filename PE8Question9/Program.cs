using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Question9
{
    // Class Program
    // Author: Brandon Cole
    // Purpose: place double quotes around each word in a string
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: get string from user and return it with quotes around each word
        // Restrictions: None
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string response = Console.ReadLine();

            string[] words = response.Split(' ');

            string final = "";

            for (int i = 0; i < words.Length; i++)
            {
                final += '"';
                final += words[i];
                final += '"';

            }

            Console.WriteLine(final);

        }
    }
}
