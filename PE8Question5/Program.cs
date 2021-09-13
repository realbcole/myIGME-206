using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Question5
{
    // Class Program
    // Author: Brandon Cole
    // Purpose: calaculate values of x, y, and z based on equation
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: increment x and y to get values of z and store them in 3d array
        // Restrictions: None
        static void Main(string[] args)
        {
            double x = -1
                , y = 1
                , z;
            double[,,] values3D;

            while (x < 1)
            {
                z = 3 * (y * y) + 2 * x - 1;

                x += .1;

            }

            //very lost on this one
        }
    }
}
