using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadLibs
{
    // Class Program
    // Author: Brandon Cole
    // Purpose: Mad Libs game
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Play mad libs based off text file
        // Restrictions: None
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\bcole\Documents\Fall 2021\IGME206\Templates\MadLibsTemplate.txt"); //Read txt file
            string[] stories = text.Split('\n'); // split the text file at every line into an array of lines

            Console.WriteLine("Please enter your name: "); 
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");
            Play:
            Console.WriteLine("Do you want to play Mad Libs? (yes/no): ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "yes" || answer.ToLower() == "no") //if they gave correct input
            {
                if (answer.ToLower() == "no") // if no
                {
                    goto End; // end
                }
            }
            else // if input is invalid
            {
                Console.WriteLine("Please try again");
                goto Play; // go back to ask again
            }
            Start:
            Console.WriteLine("Please enter a number (1-" + stories.Length + "): ");
            string sNum = Console.ReadLine();
            int num = 0;
            try
            {
                num = Int32.Parse(sNum);
            }
            catch
            {
                Console.WriteLine("Please enter an integer");
                goto Start;
            }

            string resultString = ""; // final string that will be printed to user

            string[] word = stories[num].Split(' ', ','); // split each word in the chosen story into an array to loop through

            for (int i = 0; i < word.Length; i++) // for every word in the story
            {
                if (word[i].Contains("\\n") || word[i].Contains("\n")) // if the word is \n 
                {
                    resultString = string.Concat(resultString, '\n'); // add \n to the final string
                }
                else if (word[i].StartsWith("{")) // if the word starts with { (if it is a prompt for user)
                {
                    string prompt = word[i].Trim( new Char[] {'{', '}'}); // trim the braces off
                    prompt = prompt.Replace('_', ' ');  // remove underscores and replace with spaces
                    Console.WriteLine(prompt + ": "); // get user input for the prompt
                    string response = Console.ReadLine(); 
                    resultString = string.Concat(resultString, response); // add input to final string
                }
                else if (word[i] != "") // if the word is not empty 
                {
                    resultString = string.Concat(resultString, word[i]); //then add it to the final string
                }
                resultString = string.Concat(resultString, " "); // add a space after each word

            }
            resultString = resultString.Replace(" . ", ". "); // fix the spacing
            Console.Write(resultString); // print final string

            Restart: 
            Console.WriteLine("\nWould you like to play again? (yes/no): "); 
            string playagain = Console.ReadLine();
            if (playagain.ToLower() == "yes" || playagain.ToLower() == "no")
            {
                if (playagain.ToLower() == "no")
                {
                    goto End;
                }
                else if (playagain.ToLower() == "yes")
                {
                    goto Start;
                }
            }
            else
            {
                Console.WriteLine("Please try again");
                goto Restart;
            }
            End:
            Console.WriteLine("Goodbye!");
        }
    }
}
