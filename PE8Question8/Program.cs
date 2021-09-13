using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Question8
{
    // Class Program
    // Author: Brandon Cole
    // Purpose: replace all "no"s in a string with "yes"
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: get string from user, replace all no's with yes and return
        // Restrictions: None
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string response = Console.ReadLine();
            string[] result = response.Split(' ');
            string final = "";

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].ToLower() == "no")
                {
                    if (result[i].StartsWith("N"))
                    {
                        final += "Yes";
                    }
                    else
                    {
                        final += "yes";
                    }
                }
                else
                {
                    final += result[i];
                }
                final += " ";
            }
            
            Console.WriteLine(final);
            
            // couldn't figure out how to make it work with punctuation after the no
        }
    }
}
