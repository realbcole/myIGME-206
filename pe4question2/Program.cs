using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe4question2
{
    // Class: Program
    // Author: Brandon Cole
    // Purpose: Develop program to take 2 integers and return them, unless both are greater than 10
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Ask for an integer twice and check for valid input, then check if both are over 10, if so, start over
        // Restrictions: None
        static void Main(string[] args)
        {
            Start: // goto to start over
            int num1 = 0;
            int num2 = 0;
            while (true)
            {
                Console.WriteLine("Enter an integer: ");
                string response = Console.ReadLine();

                if (Int32.TryParse(response, out int num)) // if input is valid
                {
                    num1 = num; 
                    break; // break out of loop
                }

                else //if input is invalid 
                {
                    Console.WriteLine("Error: Please enter an integer"); //give error and restart loop
                }
            }


            while (true)
            {
                Console.WriteLine("Enter an integer: ");
                string response = Console.ReadLine();

                if (Int32.TryParse(response, out int num))
                {
                    num2 = num;
                    break;
                }

                else
                {
                    Console.WriteLine("Error: Please enter an integer");
                }
            }

            if ((num1 > 10) && (num2 > 10)) // if both numbers are greater than 10
            {
                Console.WriteLine("Both numbers are greater than 10, enter new numbers"); 
                goto Start; // start over
            }
            else // if only one is greater than 10 or neither
            {
                Console.WriteLine("Here are your numbers: " + num1 + " " + num2); // print numbers
            }
        }
    }
}
