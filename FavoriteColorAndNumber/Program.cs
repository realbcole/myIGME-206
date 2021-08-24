using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavoriteColorAndNumber
{
    // Class: Program
    // Author: Brandon Cole
    // Purpose: Console read/write and exception-handling exercise
    // Restrictions: None
    static class Program
    {
        // Method: Main
        // Purpose: Prompt the user for their favorite color and number
        //          Output their favorite color (in limited text colors) their favorite number of times
        // Restrictions: none
        static void Main(string[] args)
        {
            // string to hold their favorite color
            // compile-time error: no semi-colon
            // string color = null
            string color = null;

            //int to hold their favorite number
            int favNum = 0;

            // flag to indicate if they entered a valid number string
            bool bValid = false;

            // loop counter
            int i = 0;

            // prompt for favorite color
            // demonstrate including the tab special character
            Console.Write("Enter your favorite color:\t");


            // read their favorite color from the keyboard
            // store it in color
            // logic error: wrong variable for what it is supposed to do
            // sNumber = Console.Readline();
            color = Console.ReadLine();

            // prompt for favorite number
            Console.Write("Enter your favorite number:\t");
            sNumber = Console.ReadLine();


            // this causes a run-time error with non-numeric string
            favNum = Convert.ToInt32(sNumber);


        }

    }
}
