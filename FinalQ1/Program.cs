using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FianlQ1
{
    //Class: Program
    //Author: Brandon Cole
    //Purpose: prompt for string, print how many of each letter is in it
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: prompt for string, print how many of each letter is in it
        //Restrictions: None
        static void Main(string[] args)
        {

            ////////////FIRST WAY///////////////////////////////
           /*
            Console.WriteLine("Please enter a string: ");
            string initialString = Console.ReadLine();
            char[] initialArray = initialString.ToLower().ToCharArray();

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            Dictionary<char, int> letterCount = new Dictionary<char, int>();

            foreach (char letter in alphabet)
            {
                foreach (char c in initialArray)
                {
                    if (c == letter)
                    {
                        if (letterCount.ContainsKey(c))
                        {
                            letterCount[c] = letterCount[c] + 1;
                        }
                        else
                        {
                            letterCount[c] = 1;
                        }
                    }
                }
            }
            string output = "";
            foreach (KeyValuePair<char, int> kvp in letterCount)
            {
                output += kvp.Key + ": " + kvp.Value + "\n";
            }

            Console.WriteLine(output);
           */

            /////MORE DATA ORIENTED/////////////////

            Console.WriteLine("Please enter a string: ");
            string initialString = Console.ReadLine();

            char[] initialArray = initialString.ToLower().ToCharArray();
            Dictionary<char, int> letterCount = new Dictionary<char, int>();

            foreach (char c in initialArray)
            {
                if (letterCount.ContainsKey(c))
                {
                    letterCount[c]++;
                }
                else
                {
                    letterCount[c] = 1;
                }
            }
            string output = "";
            foreach (KeyValuePair<char, int> kvp in letterCount)
            {
                output += kvp.Key + ": " + kvp.Value + "\n";
            }
            Console.WriteLine(output);

            //Not entirely sure how to prove via the profiler that it is faster but it is faster
        }
    }
}