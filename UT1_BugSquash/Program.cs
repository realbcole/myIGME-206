using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //int nY
            // Compile-time error - missing semicolon
            int nY;
            int nAnswer;

            //Console.WriteLine(This program calculates x ^ y.);
            //Compile-time error - missing quotation marks
            Console.WriteLine("This program calculates x ^ y.");
            do
            {
                Console.Write("Enter a whole number for x: ");
                //Console.ReadLine();
                // Logic error: didnt store answer in a variable
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));
            y:
            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } //while (int.TryParse(sNumber, out nX));
              // logic error - output should be nY, and should have ! in front
            while (!int.TryParse(sNumber, out nY));
            //need to check if y is positive
            if(nY < 0)
            {
                Console.WriteLine("Number must be positive");
                goto y;
            }

            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);

            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            //logic error- didnt give the variables to fill in with
            Console.WriteLine(nX + "^" + nY + "=" + nAnswer);
        }


         //int Power(int nBase, int nExponent)
         //logic error - should be static
         static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //returnVal = 0;
                //logic error - should return because this is base case, also it should return 1 not 0
                return returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //nextVal = Power(nBase, nExponent + 1);
                // logic error - should do exponent - 1 not +1 ... causes stack overflow
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //returnVal;
            //compile-time error - need to put return in front
            return returnVal;
        }
    }
}
