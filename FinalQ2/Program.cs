using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;
using System.Timers;

namespace FinalQ2
{
    class Program
    {
        static int[,] mGraph = new int[,] // cost
        {
                        //A//    //B//    //C//      //D//     //E/    //F//   //G//   //H//
             /*A*/   {  (-1),     (1),     (5),      (-1),     (-1),   (-1),   (-1),   (-1)  },
             /*B*/   {  (-1),    (-1),    (-1),      (1),      (-1),    (7),   (-1),   (-1)  },
             /*C*/   {  (-1),    (-1),    (-1),      (0),      (2),   (-1),    (-1),   (-1) },
             /*D*/   {  (-1),    (1),     (0),       (-1),     (-1),   (-1),   (-1),   (-1)   },
             /*E*/   {  (-1),    (-1),    (2),      (-1),     (-1),   (-1),   (2),   (-1)    },
             /*F*/   {  (-1),    (-1),    (-1),      (-1),     (-1),   (-1),   (1),    (4)  },
             /*G*/   {  (-1),    (-1),    (-1),      (-1),     (2),    (1),   (-1),   (-1)   },
             /*H*/   {  (-1),    (-1),    (-1),      (-1),     (-1),   (-1),   (-1),   (-1)  },
        };

        static (string, int)[][] lGraph = new (string, int)[][] // (neighbor, cost)
        {
           /*A*/ new (string, int)[] { ("B", 1), ("C", 5) }, 
           /*B*/ new (string, int)[] { ("D", 1), ("F", 7) }, 
           /*C*/ new (string, int)[] { ("D", 0), ("E", 2) }, 
           /*D*/ new (string, int)[] { ("B", 1), ("C", 0) }, 
           /*E*/ new (string, int)[] { ("C", 2), ("G", 2) }, 
           /*F*/ new (string, int)[] { ("H", 4) }, 
           /*G*/ new (string, int)[] { ("F", 1), ("E", 2) }, 
           /*H*/ null
        };

        static bool bTimeOut = false;
        static Timer timeOutTimer;



        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            Console.WriteLine("You are in a labyrinth with 8 rooms.\nEach room has a state of ice, liquid, or gas\nYou may only enter a room if it is in the same state as you");

            int currentRoom = 0;
            int hp = 5;
            string[] rooms = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int[] roomStates = { 1, 2, 3, 1, 2, 3, 1, 2 };
            int myState = 1;
            int moves = 0;

            for (int i = 0; i < roomStates.Count(); i++)
            {
                Console.WriteLine("Room " + rooms[i] + " has an initial state of " + NState2SState( roomStates[i]));
            }

            Console.WriteLine("The state of each room changes everytime you enter a new room");
            Console.WriteLine();
            EnterRoom(currentRoom, hp, roomStates, myState, moves);

        }

        static void EnterRoom(int currentRoom, int hp, int[] roomStates, int myState, int moves)
        {
            if (currentRoom != 0)
            {
                ChangeState(roomStates);
                moves++;
            }
            

            (string, int)[] roomList = lGraph[currentRoom];
            if (currentRoom == 0)//A
            {
                Console.WriteLine("You enter room A");
            }
            else if (currentRoom == 1)//B
            {
                Console.WriteLine("You enter room B");
            }
            else if (currentRoom == 2)//C
            {
                Console.WriteLine("You enter room C");
            }
            else if (currentRoom == 3)//D
            {
                Console.WriteLine("You enter room D");
            }
            else if (currentRoom == 4)//E
            {
                Console.WriteLine("You enter room E");
            }
            else if (currentRoom == 5)//F
            {
                Console.WriteLine("You enter room F");
            }
            else if (currentRoom == 6)//G
            {
                Console.WriteLine("You enter room G");
            }
            else if (currentRoom == 7)//H
            {
                Console.WriteLine("You enter room H. Congratulations, you made it!\nIt took you " + moves + " moves to win!");
                GameOver();
            }
            
            Console.WriteLine("This room is now in a state of " + NState2SState(roomStates[currentRoom]));
            Console.WriteLine("Your current state is " + NState2SState(myState));

            if (roomList != null)
            {
                foreach ((string, int) n in roomList)
                {
                    if (n.Item2 <= (hp - 1) && myState == roomStates[SRoom2NRoom(n.Item1)])
                    {
                        Console.WriteLine("You may enter room " + n.Item1 + " for " + n.Item2 + " health");

                    }
                    else if (n.Item2 <= (hp - 1))
                    {
                        Console.WriteLine("You could enter room " + n.Item1 + " if you had a state of " + NState2SState( roomStates[SRoom2NRoom(n.Item1)]));
                    }
                }
            }
        question1:

            Console.WriteLine("You have " + hp + " health");

            if (myState == 1 || myState == 3)
            {
                Console.WriteLine("You may change your state to liquid");
            }
            else if (myState == 2)
            {
                Console.WriteLine("You may change your state to gas or ice");
            }
            Console.Write("Would you like to change your state for 1 health? (Y/N) ");
            string sChangeState = Console.ReadLine();
            if (sChangeState.ToLower() == "y")
            {
                if (myState == 1 || myState == 3)
                {
                    Console.Write("Would you like to change your state to liquid? (Y/N) ");
                    string sYesNo = Console.ReadLine();

                    if (sYesNo.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine("Your state is now liquid");
                        hp -= 1;
                        myState = 2;
                    }
                    else if (sYesNo.ToLower().StartsWith("n"))
                    {
                        
                    }
                    else
                    {
                        Console.Write("Pleae enter a valid response");
                        goto question1;
                    }
                }
                else if (myState == 2)
                {
                    Console.Write("Would you like to change to gas or ice? (gas/ice) ");
                    string gasOrIce = Console.ReadLine();
                    if (gasOrIce.ToLower().StartsWith("g"))
                    {
                        Console.WriteLine("Your state is now gas");
                        hp -= 1;
                        myState += 1;
                    }
                    else if (gasOrIce.ToLower().StartsWith("i"))
                    {
                        Console.WriteLine("Your state is now ice");
                        hp -= 1;
                        myState -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response");
                        goto question1;
                    }
                }
                
            }

            Console.Write("Would you like to wager your health against a trivia question? (Y/N) ");
            string sTriv = Console.ReadLine();
            if (sTriv.ToLower() == "y")
            {
                Console.Write("How much of your health would you like to wager? (You have " + hp + " health) (r to return) ");
                string sWager = Console.ReadLine();
                int nWager;
                if (sWager.ToLower() == "r")
                {
                    goto question1;
                }
                try
                {
                    nWager = Int32.Parse(sWager);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer");
                    goto question1;
                }
                if (nWager > hp)
                {
                    Console.WriteLine("You cannot wager more health than you have");
                    goto question1;
                }
                string url = null;
                string s = null;
                HttpWebRequest request;
                HttpWebResponse response;
                StreamReader reader;
                url = "https://opentdb.com/api.php?amount=1&type=multiple";
                request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                s = reader.ReadToEnd();
                reader.Close();

                Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

                trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
                trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
                for (int i = 0; i < trivia.results[0].incorrect_answers.Count; i++)
                {
                    trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
                }
                Console.WriteLine();
                Console.WriteLine(trivia.results[0].question);
                List<string> answers = new List<string>();
                answers.Add(trivia.results[0].correct_answer);
                foreach (string answer in trivia.results[0].incorrect_answers)
                {
                    answers.Add(answer);
                }
                Random rand = new Random();
                int choice = 1;
                List<string> options = new List<string>();

                while (answers.Count != 0)
                {
                    int x = rand.Next(0, answers.Count);
                    Console.WriteLine("(" + choice + ")" + answers[x]);
                    options.Add(answers[x]);
                    choice++;
                    answers.RemoveAt(x);
                }

                Console.Write("You have 15 seconds to answer. Enter your answer here: ");
                bTimeOut = false;
                string sResponse = null;
                while (!bTimeOut && sResponse == null)
                {
                    timeOutTimer = new Timer(15000);
                    ElapsedEventHandler elapsedEventHandler;
                    elapsedEventHandler = new ElapsedEventHandler(TimesUp);
                    timeOutTimer.Elapsed += elapsedEventHandler;

                    timeOutTimer.Start();

                    sResponse = Console.ReadLine();

                    timeOutTimer.Stop();
                }


                if (sResponse == "1")
                {
                    if (options[0] == trivia.results[0].correct_answer && !bTimeOut)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Correct! Your health has been increased by your wager");
                        hp += nWager;
                        Console.WriteLine("Your health is now " + hp);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wrong! The correct answer was " + trivia.results[0].correct_answer + "\nYour health has been decreased by your wager");
                        hp -= nWager;
                        if (hp <= 0)
                        {
                            Console.WriteLine("You died!");
                            GameOver();
                        }
                        else
                        {
                            Console.WriteLine("Your health is now " + hp);
                        }
                    }
                }
                else if (sResponse == "2")
                {
                    if (options[1] == trivia.results[0].correct_answer && !bTimeOut)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Correct! Your health has been increased by your wager");
                        hp += nWager;
                        Console.WriteLine("Your health is now " + hp);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wrong! The correct answer was " + trivia.results[0].correct_answer + "\nYour health has been decreased by your wager");
                        hp -= nWager;
                        if (hp <= 0)
                        {
                            Console.WriteLine("You died!");
                            GameOver();
                        }
                        else
                        {
                            Console.WriteLine("Your health is now " + hp);
                        }
                    }
                }
                else if (sResponse == "3")
                {
                    if (options[2] == trivia.results[0].correct_answer && !bTimeOut)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Correct! Your health has been increased by your wager");
                        hp += nWager;
                        Console.WriteLine("Your health is now " + hp);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wrong! The correct answer was " + trivia.results[0].correct_answer + "\nYour health has been decreased by your wager");
                        hp -= nWager;
                        if (hp <= 0)
                        {
                            Console.WriteLine("You died!");
                            GameOver();
                        }
                        else
                        {
                            Console.WriteLine("Your health is now " + hp);
                        }
                    }
                }
                else if (sResponse == "4")
                {
                    if (options[3] == trivia.results[0].correct_answer && !bTimeOut)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Correct! Your health has been increased by your wager");
                        hp += nWager;
                        Console.WriteLine("Your health is now " + hp);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wrong! The correct answer was " + trivia.results[0].correct_answer + "\nYour health has been decreased by your wager");
                        hp -= nWager;
                        if (hp <= 0)
                        {
                            Console.WriteLine("You died!");
                            GameOver();
                        }
                        else
                        {
                            Console.WriteLine("Your health is now " + hp);
                        }
                    }
                }
                else if (bTimeOut)
                {
                    Console.WriteLine();
                    Console.WriteLine("You ran out of time! The correct answer was " + trivia.results[0].correct_answer + "\nYour health has been decreased by your wager");
                    hp -= nWager;
                    if (hp <= 0)
                    {
                        Console.WriteLine("You died!");
                        GameOver();
                    }
                    else
                    {
                        Console.WriteLine("Your health is now " + hp);
                    }
                }
                goto question1;

            }
            else if (sTriv.ToLower() == "n")
            {
                Console.Write("Would you like to leave this room via an available exit? (Y/N) ");
                string sExit = Console.ReadLine();
                if (sExit.ToLower() == "n")
                {
                    goto question1;
                }
                else if (sExit.ToLower() != "y")
                {
                    Console.WriteLine("Please enter a valid response");
                    goto question1;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid response");
                goto question1;
            }
        question2:
            if (roomList != null)
            {
                foreach ((string, int) n in roomList)
                {
                    if (n.Item2 <= (hp - 1) && myState == roomStates[SRoom2NRoom(n.Item1)])
                    {
                        Console.WriteLine("You may enter room " + n.Item1 + " for " + n.Item2 + " health");

                    }
                    else if (n.Item2 <= (hp - 1))
                    {
                        Console.WriteLine("You could enter room " + n.Item1 + " if you had a state of " + NState2SState(roomStates[SRoom2NRoom(n.Item1)]));
                    }
                }
            }
            Console.Write("Which room would you like to enter?  (r to return) ");
            string sAnswer = Console.ReadLine();
            if (sAnswer.ToLower() == "r")
            {
                goto question1;
            }

            string[] possibleRooms = { };
            if (roomList != null)
            {
                foreach ((string, int) n in roomList)
                {
                    possibleRooms.Append(n.Item1);
                    if (sAnswer.ToLower() == n.Item1.ToLower() && hp > n.Item2 && myState == roomStates[SRoom2NRoom(n.Item1)])
                    {
                        currentRoom = SRoom2NRoom(n.Item1);
                        hp -= n.Item2;
                        Console.WriteLine();
                        Console.WriteLine("You give up " + n.Item2 + " health to enter room " + n.Item1);
                        Console.WriteLine();

                        EnterRoom(currentRoom, hp, roomStates, myState, moves);
                    }
                    else if (sAnswer.ToLower() == n.Item1.ToLower() && myState != roomStates[SRoom2NRoom(n.Item1)])
                    {
                        Console.WriteLine();
                        Console.WriteLine("You cannot enter room " + n.Item1 + " because you are not in the same state");
                        Console.WriteLine();
                    }
                }
            }

                Console.WriteLine("You cannot go that way!");
                goto question1;
        }

        static void GameOver()
        {
        playagain:
            Console.Write("Game Over! Would you like to play again? (Y/N) ");
            string sQuit = Console.ReadLine();
            if (sQuit.ToLower() == "y")
            {
                Console.WriteLine();
                StartGame();
            }
            else if (sQuit.ToLower() == "n")
            {
                System.Environment.Exit(0);
            }
            else
            {
                goto playagain;
            }
        }

        static void TimesUp(object source, ElapsedEventArgs e)
        {
            Console.WriteLine();
            Console.Write("Time's up! Press enter");
            bTimeOut = true;
            timeOutTimer.Stop();
        }

        static int SRoom2NRoom(string s)
        {
            if (s.ToLower() == "a")
            {
                return 0;
            }
            else if (s.ToLower() == "b")
            {
                return 1;
            }
            else if (s.ToLower() == "c")
            {
                return 2;
            }
            else if (s.ToLower() == "d")
            {
                return 3;
            }
            else if (s.ToLower() == "e")
            {
                return 4;
            }
            else if (s.ToLower() == "f")
            {
                return 5;
            }
            else if (s.ToLower() == "g")
            {
                return 6;
            }
            else if (s.ToLower() == "h")
            {
                return 7;
            }
            else
            {
                return -1;
            }
        }

        static void ChangeState(int[] roomStates)
        {
            for (int i = 0; i < roomStates.Count(); i++)
            {
                if (roomStates[i] == 3)
                {
                    roomStates[i] = 1;
                }
                else if (roomStates[i] == 2)
                {
                    roomStates[i]++;
                }
                else if (roomStates[i] == 1)
                {
                    roomStates[i]++;
                }
            }
        }

        static string NState2SState(int n)
        {
            if (n == 1)
            {
                return "ice";
            }
            if (n == 2)
            {
                return "liquid";
            }
            if (n == 3)
            {
                return "gas";
            }
            else
            {
                return null;
            }
        }

    }

    

    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }
 
}
