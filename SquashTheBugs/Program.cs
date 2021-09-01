using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            // int i = 0
            // compile-time error: missing semicolon
            // int i = 0;
            // logic error: should declare float instead so we get more detailed answers
            float i = 0;

            // declare string to hold all numbers
            // had to move outside the for loop so it could be referenced outside
            string allNumbers = null;

            // loop through the numbers 1 through 10
            // for (i = 1; i < 10; ++i)
            // logic error: this only counts 1-9
            for (i = 1; i <= 10; ++i)
            {
                // output explanation of calculation
                // Console.Write(i + "/" + i - 1 + " = ");
                // run-time error: cannot subtract a number from a string
                Console.Write(i + "/" + (i - 1) + " = ");

                // output the calculation based on the numbers
                //Console.WriteLine(i / (i - 1));
                // run-time error: divide by 0
                if (i > 1)
                {
                    // Console.WriteLine(i / (i - 1));
                    // logic error: should return float
                    float f = (i / (i - 1));
                    Console.WriteLine(f);
                }
                else
                {
                    Console.WriteLine("Cannot divide by zero!");
                }


                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                // i = i + 1;
                // logic error: the loop already adds 1 to i in the for statement
            }

            // output all numbers which have been processed
            //Console.WriteLine("These numbers have been processed: " allNumbers);
            // compile-time error: missing +
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}
