using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    // Class: Program
    // Author: Brandon Cole
    // Purpose: Pet application
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: instantiate objects and loop 50 times to either buy a new pet or have one do a random action
        // Restrictions: None
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();

            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("You bought a dog!");
                    DogInput:
                        Console.Write("Name => ");
                        string name = Console.ReadLine();
                        Console.Write("Age => ");
                        string sAge = Console.ReadLine();
                        int age;
                        try
                        {
                            age = Int32.Parse(sAge);
                        }
                        catch
                        {
                            Console.WriteLine("Please enter an integer");
                            goto DogInput;
                        }
                        Console.Write("License => ");
                        string license = Console.ReadLine();
                        dog = new Dog(license, name, age);
                        thisPet = dog;
                        pets.Add(thisPet);
                    }
                    else
                    {
                        Console.WriteLine("You bought a cat!");
                        CatInput:
                        Console.Write("Name => ");
                        string name = Console.ReadLine();
                        Console.Write("Age => ");
                        string sAge = Console.ReadLine();
                        int age;
                        try
                        {
                            age = Int32.Parse(sAge);
                        }
                        catch
                        {
                            Console.WriteLine("Please enter an integer");
                            goto CatInput;
                        }
                        cat = new Cat();
                        cat.Name = name;
                        cat.age = age;
                        thisPet = cat;
                        pets.Add(thisPet);
                    }
                }
                else
                {
                    if (pets.Count > 0)
                    {
                        int randomPet = rand.Next(0, (pets.Count));
                        thisPet = pets.petList[randomPet];
                    }
                    else
                    {
                        continue;
                    }
                        
                    if (thisPet != null)
                    {
                        Type type = thisPet.GetType();
                        if (type == typeof(Dog))
                        {
                            iDog = (Dog)thisPet;
                            int action = rand.Next(1, 6);
                            if (action == 1)
                            {
                                iDog.Eat();
                            }
                            else if (action == 2)
                            {
                                iDog.Play();
                            }
                            else if (action == 3)
                            {
                                iDog.Bark();
                            }
                            else if (action == 4)
                            {
                                iDog.NeedWalk();
                            }
                            else
                            {
                                iDog.GotoVet();
                            }
                        }
                        else
                        {
                            iCat = (Cat)thisPet;
                            int action = rand.Next(1, 5);
                            if (action == 1)
                            {
                                iCat.Eat();
                            }
                            else if (action == 2)
                            {
                                iCat.Play();
                            }
                            else if (action == 3)
                            {
                                iCat.Scratch();
                            }
                            else if (action == 4)
                            {
                                iCat.Purr();
                            }

                        }
                    }
                }
            }
        }

        public class Pets
        {
            public List<Pet> petList = new List<Pet>();
            
            public Pet this[int nPetEl]
            {
                get
                {
                    Pet returnVal;
                    try
                    {
                        returnVal = (Pet)petList[nPetEl];
                    }
                    catch
                    {
                        returnVal = null;
                    }
                    return (returnVal);
                }
                set
                {
                    if (nPetEl < petList.Count)
                    {
                        petList[nPetEl] = value;
                    }
                    else
                    {
                        petList.Add(value);
                    }
                }
            }
            public int Count
            {
                get
                {
                    int returnVal;
                    try
                    {
                        returnVal = petList.Count;
                    }
                    catch
                    {
                        returnVal = 0;
                    }
                    return returnVal;
                }
            }
            public void Add(Pet pet)
            {
                petList.Add(pet);
            }
            public void Remove(Pet pet)
            {
                petList.Remove(pet);
            }
            public void RemoveAt(int petEl)
            {
                petList.RemoveAt(petEl);
            }
            
        }

        public abstract class Pet
        {
            private string name;
            public int age;
            public string Name;
            public abstract void Eat();
            public abstract void Play();
            public abstract void GotoVet();

            public Pet() { }
            public Pet(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }

        public interface ICat
        {
            void Eat();
            void Play();
            void Scratch();
            void Purr();

        }

        public interface IDog
        {
            void Eat();
            void Play();
            void Bark();
            void NeedWalk();
            void GotoVet();
        }

        public class Cat : Pet, ICat
        {
            public override void Eat()
            {
                Console.WriteLine(this.Name + " is eating!");
            }
            public override void Play()
            {
                Console.WriteLine(this.Name + " is playing!");
            }
            public void Purr()
            {
                Console.WriteLine(this.Name + " is purring!");
            }

            public void Scratch()
            {
                Console.WriteLine(this.Name + " is getting scratches!");
            }

            public override void GotoVet()
            {
                Console.WriteLine(this.Name + " is going to the vet!");
            }
            public Cat()
            {

            }
        }

        public class Dog : Pet, IDog
        {
            public string license;

            public override void Eat()
            {
                Console.WriteLine(this.Name + " is eating!");
            }

            public override void Play()
            {
                Console.WriteLine(this.Name + " is playing!");
            }
            public void Bark()
            {
                Console.WriteLine(this.Name + " is barking!");
            }
            public void NeedWalk()
            {
                Console.WriteLine(this.Name + " needs a walk!");
            }
            public override void GotoVet()
            {
                Console.WriteLine(this.Name + " is going to the vet!");
            }

            public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
            {
                this.license = szLicense;
                this.Name = szName;
                this.age = nAge;
            }
        }
    }
}
