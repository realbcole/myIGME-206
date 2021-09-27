using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    // Class: program
    // Author: Brandon Cole
    // Purpose: Reference vehicles.dll and make functions
    // Restrictions: None
    class Program
    {
        static void Main(string[] args)
        {

        }

        void AddPassenger(IPassengerCarrier obj)
        {
            obj.LoadPassenger();
            Console.WriteLine(obj.ToString());
        }
    }
}
