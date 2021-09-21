using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1Q12
{

    // Struct: Employee
    // Purpose: Hold salary and name of employee
    // Restrictions: None
    struct employee
    {
        public string sName;
        public double dSalary;
    }

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
            Console.WriteLine("Please enter your name: ");
            employee brandon = new employee();
            brandon.sName = Console.ReadLine();
            if (GiveRaise(ref brandon))
            {
                Console.WriteLine("Congratulations! You got a raise!");
                Console.WriteLine("Your new salary is " + brandon.dSalary);
            }
            else
            {
                Console.WriteLine("Sorry! You did not get a raise");
            }

        }
        // Method: GiveRaise
        // Purpose: Give raise if name == my name and return true, else return false
        // Restrictions: None
        static bool GiveRaise(ref employee employee)
        {
            if (employee.sName.ToLower() == "brandon")
            {
                employee.dSalary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
