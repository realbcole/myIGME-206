using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe3question5
{
    
    // Class: Program
    // Author: Brandon Cole
    // Purpose: Develop program to take 4 integers and return the product
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Ask for an integer 4 times and then return the product
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare variables (product stores the product of the integers, i stores the counter for the loop)
            int product = 1;
            int i = 1;
            // loop 4 times
            while (i < 5)
            {
                // iAns = user's answer converted to an integer
                int iAns = 0;
                // ans = user's answer
                string ans = null;
                // ask for an integer
                Console.WriteLine("(" + i + "/4)Enter an integer: ");
                // store answer
                ans = Console.ReadLine();
                // convert answer to int
                iAns = Convert.ToInt32(ans);
                // multiply it to the other integers
                product *= iAns;
                // counter + 1
                i += 1;
            }
            // return product of integers
            Console.WriteLine("The product of your integers is: " + product);

        }
    }
}
