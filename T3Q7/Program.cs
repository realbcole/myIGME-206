using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3Q7
{
    //Class: Wizard
    //Author: Brandon Cole
    //Purpose: Wizard class to hold name and age
    //Restrictions: None
    public class Wizard : IComparable<Wizard>
    {
        public string name;
        public int age;
        //Method: Wizard
        //Purpose: Contructor
        //Restrictions: None
        public Wizard(string s, int n)
        {
            this.age = n;
            this.name = s;
        }
        public int CompareTo(Wizard other)
        {
            return this.age.CompareTo(other.age);
        }
    }

    //Class: Program
    //Author: Brandon Cole
    //Purpose: Make 10 wizards and sort them based on age
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Make 10 wizards with random ages and sort them and print to console
        //Restrictions: None
        static void Main(string[] args)
        {
            List <Wizard> wizardList = new List<Wizard>();
            Random rand = new Random();
            wizardList.Add(new Wizard("Magnus", rand.Next(1, 1001))); //wizards live up to 1000 obviously
            wizardList.Add(new Wizard("Orion", rand.Next(1, 1001)));
            wizardList.Add(new Wizard("Oedipus", rand.Next(1, 1001)));
            wizardList.Add(new Wizard("Maxwell", rand.Next(1, 1001)));
            wizardList.Add(new Wizard("Guillermo", rand.Next(1, 1001)));
            wizardList.Add(new Wizard("Percy", rand.Next(1, 1001)));
            wizardList.Add(new Wizard("Felix", rand.Next(1, 1001)));
            wizardList.Add(new Wizard("Kyra", rand.Next(1, 1001)));
            wizardList.Add(new Wizard("Farah", rand.Next(1, 1001)));
            wizardList.Add(new Wizard("Brando", rand.Next(1, 1001)));

            wizardList.Sort(); //list.sort
            wizardList = wizardList.OrderBy(delegate (Wizard w) { return w.age; }).ToList(); //delegate
            wizardList = wizardList.OrderBy(w => w.age).ToList(); //lambda

            foreach(Wizard w in wizardList)
            {
                Console.WriteLine("{0} the wizard is {1} years old", w.name, w.age);
            }
        }
    }
}
