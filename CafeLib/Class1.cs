using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLib
{
    // Author: Brandon Cole
    public abstract class HotDrink : Customer
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public virtual void AddSugar(byte amount)
        {
            Console.WriteLine("Added sugar!");
        }

        public abstract void Steam();

        public HotDrink()
        {

        }

        public HotDrink(string brand)
        {

        }
    }

    public interface IMood
    {
        string Mood { get; }
    }

    public interface ITakeOrder
    {
        void TakeOrder();
    }

    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;

        public string Mood { get; }
    }

    public class Waiter : IMood
    {
        public string name;
        public string Mood { get; }
        public void ServeCustomer(HotDrink cup)
        {
            Console.WriteLine("The customer has been served " + cup.name);
        }
    }
    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;
        
        public override void Steam()
        {
            Console.WriteLine("The coffee is steaming hot");
        }

        public void TakeOrder()
        {
            Console.WriteLine("Order of coffee");
        }

        public CupOfCoffee(string brand) : base(brand)
        {

        }
    }

    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;

        public override void Steam()
        {
            Console.WriteLine("The tea is steaming!");
        }

        public void TakeOrder()
        {
            Console.WriteLine("Order of tea");
        }
        
        public CupOfTea(bool customerIsWealthy)
        {

        }
    }

    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public int numCups { set { } }
        public bool marshmallows;
        private string source;

        public string Source { get; }
        public override void Steam()
        {
            Console.WriteLine("The cocoa is steaming!");
        }

        public override void AddSugar(byte amount)
        {
            base.AddSugar(amount);
        }

        public void TakeOrder()
        {
            Console.WriteLine("Order of cocoa!");
        }

        public CupOfCocoa() : this(false)
        {

        }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand")
        {

        }
    }
}
