using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3Q1
{
    //Class: Program
    //Author: Brandon Cole
    //Purpose: prompt for string, print how many of each letter is in it, reverse it, test if its a palindrome
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: prompt for string, print how many of each letter is in it, reverse it, test if its a palindrome
        //Restrictions: None
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string: ");
            string initialString = Console.ReadLine();
            char[] initialArray = initialString.ToLower().ToCharArray();

            char[] caseSensArray = initialString.ToCharArray();

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

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
            foreach ( KeyValuePair<char, int> kvp in letterCount )
            {
                output += kvp.Key + ": " + kvp.Value + "\n";
            }

            char[] reversedArray = new char[caseSensArray.Length];
            int j = 0;
            for (int i = caseSensArray.Length - 1; i >= 0; i--)
            {
                reversedArray[j] = caseSensArray[i];
                j++;
            }

            string reversedString = new string(reversedArray);

            Console.WriteLine(output);

            Console.WriteLine(reversedString);

            if (reversedString == initialString)
            {
                Console.WriteLine("Your string was a palindrome!");
            }
            else
            {
                Console.WriteLine("Your string was not a palindrome");
            }
        }
    }
}
