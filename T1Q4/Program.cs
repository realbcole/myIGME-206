using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace T1Q4
{
    class Program
    {
        static bool bTimesUp = false;
        static Timer timeOut;
        static void Main(string[] args)
        {
            start:
            int nQuestions = 0;
            string sQuestions;
            bool bValid = false;
            string sResponse;
            string sAnswer;



            Console.Write("Choose your question (1-3): ");

            sQuestions = Console.ReadLine();
            do
            {
                try
                {
                    nQuestions = int.Parse(sQuestions);
                    bValid = true;
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    bValid = false;
                }
            } while (!bValid);

            if (nQuestions == 1)
            {
                Console.WriteLine("You have 5 seconds to answer the following question:");
                Console.WriteLine("What is your favorite color? ");
                timeOut = new Timer(5000);
                ElapsedEventHandler elapsedEventHandler;
                elapsedEventHandler = new ElapsedEventHandler(TimesUp);
                timeOut.Elapsed += elapsedEventHandler;
                timeOut.Start();
                sResponse = Console.ReadLine();
                timeOut.Stop();
                sAnswer = "black";
                if (sResponse == sAnswer && !bTimesUp)
                {
                    Console.WriteLine("Well done!");
                    goto playagain;

                }
                else
                {
                    if (bTimesUp)
                    {
                        Console.WriteLine("The answer is: " + sAnswer);
                        goto playagain;
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The answer is: " + sAnswer);
                        goto playagain;
                    }
                    
                }

            }
            if (nQuestions == 2)
            {
                Console.WriteLine("You have 5 seconds to answer the following question:");
                Console.WriteLine("What is the answer to life, the universe and everything? ");
                timeOut = new Timer(5000);
                ElapsedEventHandler elapsedEventHandler;
                elapsedEventHandler = new ElapsedEventHandler(TimesUp);
                timeOut.Elapsed += elapsedEventHandler;
                timeOut.Start();
                sResponse = Console.ReadLine();
                timeOut.Stop();
                sAnswer = "42";
                if (sResponse == sAnswer)
                {
                    Console.WriteLine("Well done!");
                    goto playagain;

                }
                else
                {
                    if (bTimesUp)
                    {
                        Console.WriteLine("The answer is: " + sAnswer);
                        goto playagain;
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The answer is: " + sAnswer);
                        goto playagain;
                    }
                }
            }

            if (nQuestions == 3)
            {
                Console.WriteLine("You have 5 seconds to answer the following question:");
                Console.WriteLine("What is the airspeed velocity of an unladen swallow? ");
                timeOut = new Timer(5000);
                ElapsedEventHandler elapsedEventHandler;
                elapsedEventHandler = new ElapsedEventHandler(TimesUp);
                timeOut.Elapsed += elapsedEventHandler;
                timeOut.Start();
                sResponse = Console.ReadLine();
                timeOut.Stop();
                sAnswer = "What do you mean? African or European swallow?";
                if (sResponse == sAnswer)
                {
                    Console.WriteLine("Well done!");
                    goto playagain;

                }
                else
                {
                    if (bTimesUp)
                    {
                        Console.WriteLine("The answer is: " + sAnswer);
                        goto playagain;
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The answer is: " + sAnswer);
                        goto playagain;
                    }
                }
            }


        playagain:
            Console.Write("Play again? ");
            string sPlayAgain = Console.ReadLine();
            if (sPlayAgain.StartsWith("y"))
            {
                Console.WriteLine();
                goto start;
            }
        }

        static void TimesUp(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Time's up!");
            Console.Write("Please press enter.");
            bTimesUp = true;
            timeOut.Stop();
        }
    }
}
