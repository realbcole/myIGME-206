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

namespace DontDie
{
    //Class: Program
    //Author: Brandon Cole
    //Purpose: Adjacency matrix and adjacency list to represent a graph
    //Restrictions: None
    class Program
    {
        static (int, string)[,] mGraph = new (int, string)[,] // (weight, direction)
        {
                       //A//           //B//          //C//        //D//        //E//           //F//      //G//        //H//
             /*A*/ {  (0, "NE"),     (2, "S"),     (-1, null),  (-1, null),  (-1, null),  (-1, null),  (-1, null),    (-1, null) },
             /*B*/ {  (-1, null),    (-1, null),   (2, "S"),    (3, "E"),    (-1, null),  (-1, null),  (-1, null),    (-1, null)  },
             /*C*/ {  (-1, null),    (2, "N"),     (-1, null),  (-1, null),  (-1, null),  (-1, null),  (-1, null),    (20, "E")   },
             /*D*/ {  (-1, null),    (3, "W"),     (5, "S"),    (-1, null),  (2, "N"),    (4, "E"),    (-1, null),    (-1, null)  },
             /*E*/ {  (-1, null),    (-1, null),   (-1, null),  (-1, null),  (-1, null),  (3, "S"),    (-1, null),    (-1, null)  },
             /*F*/ {  (-1, null),    (-1, null),   (-1, null),  (-1, null),  (-1, null),  (-1, null),  (1, "E"),      (-1, null)  },
             /*G*/ {  (-1, null),    (-1, null),   (-1, null),  (-1, null),  (0, "N"),    (1, "E"),    (-1, null),    (2, "S")    },
             /*H*/ {  (-1, null),    (-1, null),   (-1, null),  (-1, null),  (-1, null),  (-1, null),  (-1, null),    (-1, null)  },
        };

        static (int, int, string)[][] lGraph = new (int, int, string)[][] // (neighbor, weight, direction)
        {
           /*A*/ new (int, int,string)[] { (0, 0, "North"), (0, 0, "East"), (1, 2, "South") }, // A, A, B
           /*B*/ new (int, int,string)[] { (3, 3, "East"), (2, 2, "South")  }, // C, D
           /*C*/ new (int, int,string)[] { (1, 2, "North"), (7, 20, "South") }, //B, H
           /*D*/ new (int, int,string)[] { (4, 2, "North"), (5, 4, "East"), (2, 5, "South"), (1, 3, "West")   }, //B, C, F, E
           /*E*/ new (int, int,string)[] { (5, 3, "South")}, //F,
           /*F*/ new (int, int,string)[] { (6, 1, "East") }, //G
           /*G*/ new (int, int,string)[] { (4, 0, "North"), (7, 2, "South") }, //E, H
        };

        static bool bTimeOut = false;
        static Timer timeOutTimer;

        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            int currentRoom = 0;
            int hp = 1;
            EnterRoom(currentRoom, hp);
        }

        static void EnterRoom(int currentRoom, int hp)
        {
            if (currentRoom != 0)
            {
                RandomEvent(hp);
            }
            (int, int, string)[] roomList = lGraph[currentRoom];
            if (currentRoom == 0)//A
            {
                Console.WriteLine("You enter a bright and welcoming room");
            }
            else if (currentRoom == 1)//B
            {
                Console.WriteLine("You enter a dim and ominous room. You can hear water dripping");
            }
            else if (currentRoom == 2)//C
            {
                Console.WriteLine("You enter a dark room. Bats fly out as you walk in");
            }
            else if (currentRoom == 3)//D
            {
                Console.WriteLine("You enter a room covered in spider webs");
            }
            else if (currentRoom == 4)//E
            {
                Console.WriteLine("You enter a shallowly flooded room. The water is green");
            }
            else if (currentRoom == 5)//F
            {
                Console.WriteLine("You enter a brighter room with light shining through the ceiling");
            }
            else if (currentRoom == 6)//G
            {
                Console.WriteLine("You enter a empty room with signs of other people");
            }
            else if (currentRoom == 7)//H
            {
                Console.WriteLine("You enter a room with a large golden treasure chest in the center with skeletons around it. Congratulations, you made it!");
                GameOver();
            }
            
            if (roomList != null)
            {
                foreach ((int, int, string) n in roomList)
                {
                    if (n.Item2 <= (hp - 1))
                    {
                        Console.WriteLine("There is a door to the " + n.Item3 + " that costs " + n.Item2 + " health");

                    }
                }
            }
            question1:
            Console.WriteLine("Would you like to wager your health against a trivia question? (Y/N) ");
            string sTriv = Console.ReadLine();
            if (sTriv.ToLower() == "y")
            {
                Console.Write("How much of your health would you like to wager? (You have " + hp + " health) ");
                string sWager = Console.ReadLine();
                int nWager;
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
                for(int i = 0; i < trivia.results[0].incorrect_answers.Count; i++)
                {
                    trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
                }
                Console.WriteLine(trivia.results[0].question);
                List<string> answers = new List<string>();
                answers.Add(trivia.results[0].correct_answer);
                foreach(string answer in trivia.results[0].incorrect_answers)
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
                        Console.WriteLine("Correct! Your health has been increased by your wager");
                        hp += nWager;
                        Console.WriteLine("Your health is now " + hp);
                    }
                    else
                    {
                        Console.WriteLine("Wrong! Your health has been decreased by your wager");
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
                        Console.WriteLine("Correct! Your health has been increased by your wager");
                        hp += nWager;
                        Console.WriteLine("Your health is now " + hp);
                    }
                    else
                    {
                        Console.WriteLine("Wrong! Your health has been decreased by your wager");
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
                        Console.WriteLine("Correct! Your health has been increased by your wager");
                        hp += nWager;
                        Console.WriteLine("Your health is now " + hp);
                    }
                    else
                    {
                        Console.WriteLine("Wrong! Your health has been decreased by your wager");
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
                        Console.WriteLine("Correct! Your health has been increased by your wager");
                        hp += nWager;
                        Console.WriteLine("Your health is now " + hp);
                    }
                    else
                    {
                        Console.WriteLine("Wrong! Your health has been decreased by your wager");
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
                    Console.WriteLine("You ran out of time! Your health has been decreased by your wager");
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
                foreach ((int, int, string) n in roomList)
                {
                    if (n.Item2 <= (hp - 1))
                    {
                        Console.WriteLine("There is a door to the " + n.Item3 + " that costs " + n.Item2 + " health");

                    }
                }
            }
            Console.Write("Which way would you like to go (N/S/E/W)? ");
            string sAnswer = Console.ReadLine();
            if (sAnswer.ToLower() != "n" && sAnswer.ToLower() != "e" && sAnswer.ToLower() != "s" && sAnswer.ToLower() != "w")
            {
                Console.WriteLine("Please enter a valid response");
                goto question2;
            }
            if (roomList != null)
            {
                foreach ((int, int, string) n in roomList)
                {
                    if (sAnswer.ToLower() == "n" && n.Item3 == "North" && hp > n.Item2)
                    {
                        currentRoom = n.Item1;
                        hp -= n.Item2;
                        Console.WriteLine();
                        Console.WriteLine("You give up " + n.Item2 + " health to enter the door to the " + n.Item3);
                        Console.WriteLine();

                        EnterRoom(currentRoom, hp);
                    }

                    if (sAnswer.ToLower() == "e" && n.Item3 == "East" && hp > n.Item2)
                    {
                        currentRoom = n.Item1;
                        hp -= n.Item2;
                        Console.WriteLine();
                        Console.WriteLine("You give up " + n.Item2 + " health to enter the door to the " + n.Item3);
                        Console.WriteLine();
                        EnterRoom(currentRoom, hp);
                    }

                    if (sAnswer.ToLower() == "s" && n.Item3 == "South" && hp > n.Item2)
                    {
                        currentRoom = n.Item1;
                        hp -= n.Item2;
                        Console.WriteLine();
                        Console.WriteLine("You give up " + n.Item2 + " health to enter the door to the " + n.Item3);
                        Console.WriteLine();

                        EnterRoom(currentRoom, hp);
                    }

                    if (sAnswer.ToLower() == "w" && n.Item3 == "West" && hp > n.Item2)
                    {
                        currentRoom = n.Item1;
                        hp -= n.Item2;
                        Console.WriteLine();
                        Console.WriteLine("You give up " + n.Item2 + " health to enter the door to the " + n.Item3);
                        Console.WriteLine();
                        EnterRoom(currentRoom, hp);
                    }

                }
                Console.WriteLine("You cannot go that way!");
                goto question2;
            }
               
        }


        static void RandomEvent(int hp)
        {
            Random rand = new Random();
            int damage = rand.Next(0, hp);
            hp -= damage;
            int x = rand.Next(1, 6);
            if (x == 1)
            {
                Console.WriteLine("You tripped on a rock! You lost " + damage + " health! \nYour health is now " + hp);
            }
            else if (x == 2)
            {
                Console.WriteLine("You were attacked by a bat! You lost " + damage + " health! \nYour health is now " + hp);
            }
            else if (x == 3)
            {
                Console.WriteLine("A rock fell on your head! You lost " + damage + " health! \nYour health is now " + hp);
            }
            else if (x == 4)
            {
                Console.WriteLine("You cut your hand on a nail sticking out of the wall! You lost " + damage + " health! \nYour health is now " + hp);
            }
            else if (x == 5)
            {
                Console.WriteLine("You walked into a wall! You lost " + damage + " health! \nYour health is now " + hp);
            }

        }

        static void GameOver()
        {
            playagain:
            Console.Write("Game Over! Would you like to play again? (Y/N) ");
            string sQuit = Console.ReadLine();
            if (sQuit.ToLower() == "y")
            {
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
