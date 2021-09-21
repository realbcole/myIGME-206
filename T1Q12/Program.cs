using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1Q12
{
    // Class Program
    // Author: Brandon Cole
    // Purpose: Give raise to people named brandon
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Get users name and call giveraise
        // Restrictions: None
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;
            bool bValid = true;
            Console.WriteLine("Please enter your name: ");
            sName = Console.ReadLine();
            if (GiveRaise(sName, ref dSalary))
            {
                Console.WriteLine("Congratulations! You got a raise!");
                Console.WriteLine("Your new salary is " + dSalary);
            }
            else
            {
                Console.WriteLine("Sorry! You did not get a raise");
            }
            
        }
        // Method: GiveRaise
        // Purpose: Give raise if name == my name and return true, else return false
        // Restrictions: None
        static bool GiveRaise(string name, ref double salary)
        {
            if (name.ToLower() == "brandon")
            {
                salary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
