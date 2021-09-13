using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Question7
{
    // Class Program
    // Author: Brandon Cole
    // Purpose: reverse string from user
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: get string from user and output the string in reverse order
        // Restrictions: None
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string response = Console.ReadLine();
            char[] charResponse = response.ToCharArray();
            string reverse = "";

            for (int i = charResponse.Length - 1; i >= 0; i--)
            {
                reverse += charResponse[i];
            }
            
            Console.WriteLine(reverse);
        }
    }
}
