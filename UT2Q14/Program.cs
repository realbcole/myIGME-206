using System;

namespace StructToClass
{

    /*
    struct Friend
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;
    }
    */

    //Class: Friend
    //Author: Brandon Cole
    //Purpose: Implement the friend struct as a class
    //Restrictions: None
    public class Friend
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;

        public Friend Clone(object obj)
        {
            return (Friend)this.MemberwiseClone();
        }
    }
    //Class: Program
    //Author: Brandon Cole
    //Purpose: Change friend struct to class and still have the same output
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: create friend and enemy, set values, clone friend into enemy, change some values, then print
        //Restrictions: None
        static void Main(string[] args)
        {
            Friend friend = new Friend();
            Friend enemy = new Friend();

            // create my friend Charlie Sheen
            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            // now he has become my enemy
            enemy.Clone(friend);

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }
}
