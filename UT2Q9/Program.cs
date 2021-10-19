using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2Q9
{
    //Class: Program
    //Author: Brandon Cole
    //Purpose: Create objects of each child class and demonstrate polymorphism
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Create the two objects and call the same method with each object
        //Restrictions: None
        static void Main(string[] args)
        {
            Speedboat speedboat = new Speedboat();
            Sailboat sailboat = new Sailboat();

            MyMethod(speedboat);

            MyMethod(sailboat);
        }
        //Method: MyMethod
        //Purpose: Call steer to show that there are different implementations of it for each object type
        //Restrictions: None
        static void MyMethod(Boat boat)
        {
            boat.Steer();
        }
    }

    public interface Drive
    {
        void StartEngine();
    }

    public interface Sail
    {
        void RaiseSail();
    }

    public abstract class Boat
    {
        public string brand;

        public virtual void Steer()
        {
            
        }

        public abstract void PutIntoWater();
        public abstract void TakeOutOfWater();

    }

    public class Speedboat : Boat, Drive
    {
        public int fuel;

        public void StartEngine()
        {

        }

        public override void Steer()
        {
            Console.WriteLine("Turning the wheel!");
        }

        public override void PutIntoWater()
        {
            
        }

        public override void TakeOutOfWater()
        {
            
        }

    }

    public class Sailboat : Boat, Sail
    {
        public bool sailsRaised;

        public void RaiseSail()
        {

        }

        public override void Steer()
        {
            Console.WriteLine("Turning the sails!");
        }

        public override void PutIntoWater()
        {

        }

        public override void TakeOutOfWater()
        {

        }

    }
}
