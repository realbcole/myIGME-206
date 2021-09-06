using System;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            Start:
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;
            double imagCoordStart, imagCoordEnd, realCoordStart, realCoordEnd;

            while (true)
            {
                Console.WriteLine("Enter a start value for the imaginary coords (default value: 1.2): ");
                string response = Console.ReadLine();

                if (Double.TryParse(response, out double num)) // if input is valid
                {
                    imagCoordStart = num;
                    break; // break out of loop
                }

                else //if input is invalid 
                {
                    Console.WriteLine("Error: Please enter a number"); //give error and restart loop
                }
            }

            while (true)
            {
                Console.WriteLine("Enter an end value for the imaginary coords (must be less than the start value, default: -1.2): ");
                string response = Console.ReadLine();

                if (Double.TryParse(response, out double num)) // if input is valid
                {
                    imagCoordEnd = num;
                    break; // break out of loop
                }

                else //if input is invalid 
                {
                    Console.WriteLine("Error: Please enter a number"); //give error and restart loop
                }
            }

            if (imagCoordEnd > imagCoordStart)
            {
                Console.WriteLine("Error: end value is greater than start value");
                goto Start;
            }

            Start2:
            while (true)
            {
                Console.WriteLine("Enter a start value for the real coords (default: -0.6): ");
                string response = Console.ReadLine();

                if (Double.TryParse(response, out double num)) // if input is valid
                {
                    realCoordStart = num;
                    break; // break out of loop
                }

                else //if input is invalid 
                {
                    Console.WriteLine("Error: Please enter a number"); //give error and restart loop
                }
            }

            while (true)
            {
                Console.WriteLine("Enter an end value for the real coords (must be greater than the start, default: 1.77): ");
                string response = Console.ReadLine();

                if (Double.TryParse(response, out double num)) // if input is valid
                {
                    realCoordEnd = num;
                    break; // break out of loop
                }

                else //if input is invalid 
                {
                    Console.WriteLine("Error: Please enter a number"); //give error and restart loop
                }
            }
            if (realCoordStart > realCoordEnd)
            {
                Console.WriteLine("Error: start value is greater than end value");
                goto Start2;
            }

            for (imagCoord = imagCoordStart; imagCoord >= imagCoordEnd; imagCoord -= 0.05)
            {
                for (realCoord = realCoordStart; realCoord <= realCoordEnd; realCoord += 0.03)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}
