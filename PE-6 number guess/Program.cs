using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_6_number_guess
{
    // Class: Program
    // Author: Brandon Cole
    // Purpose: Develop random number guessing game
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Generate random number then give user 8 tries to guess it
        // Restrictions: None
        static void Main(string[] args)
        {
            Random rand = new Random();

            // generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(0, 101);
            
            Console.WriteLine("Random Number: " + randomNumber); // print random number so it is easier to test

            int i = 1; // set counter

            bool correct = false; // variable to track if user guessed correctly

            while (i < 9) // while loop for 8 guesses
            {
                Console.WriteLine("Guess a number from 0 to 100 (Guess " + i + "): "); // displays the number of guesses and asks for guess
                string guess = Console.ReadLine(); // assigns guess to string

                if (Int32.TryParse(guess, out int iGuess)) // parse string to int
                {
                    if (iGuess == randomNumber) // if guess was correct
                    {
                        Console.WriteLine("Your guess was correct! \nIt took " + i + " guess(es)!");
                        correct = true; // set correct to true
                        break; // break out of loop because user got it correct
                    }
                    else if ((iGuess < 0) || (iGuess > 100)) // if guess is outside of the range
                    {
                        Console.WriteLine("Error: Your guess was outside the range!"); // error message, do not increase counter
                    }
                    else if (iGuess < randomNumber) // if guess was lower than number
                    {
                        Console.WriteLine("Your guess was low!"); // tell user guess was low
                        i += 1; // counter + 1
                    }
                    else // if guess was higher than number
                    {
                        Console.WriteLine("Your guess was high!"); // tell user guess was high
                        i += 1; // counter + 1
                    }
                    
                }

                else //if input is invalid 
                {
                    Console.WriteLine("Error: Please enter an integer"); // return error
                }

            }
            if (!correct) // if user did not correctly guess the number
            {
                Console.WriteLine("You failed to guess the number in 8 guesses \nThe number was " + randomNumber);
            }
            
        }
    }
}
