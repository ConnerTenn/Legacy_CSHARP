using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Test5
{
    class Program
    {
        static void Main()
        {
            Program.Test2();
            Console.WriteLine();
            Console.WriteLine("Press [Enter] To Continue");
            Console.ReadLine();
        }

        static void Test1()
        {
            Cat cat = new Cat { Age = 10, Name = "Fluffy" };

            List<Cat> cats = new List<Cat>
            {
                new Cat(){ Name = "Sylvester", Age=8 },
                new Cat(){ Name = "Whiskers", Age=2 },
                new Cat(){ Name = "Sasha", Age=14 }
            };

            List<Cat> moreCats = new List<Cat>
            {
                new Cat(){ Name = "Furrytail", Age=5 },
                new Cat(){ Name = "Peaches", Age=4 },
                null
            };

            // Display results.
            System.Console.WriteLine(cat.Name);

            foreach (Cat c in cats)
                System.Console.WriteLine(c.Name);

            foreach (Cat c in moreCats)
                if (c != null)
                    System.Console.WriteLine(c.Name);
                else
                    System.Console.WriteLine("List element has null value.");
        }

        static void Test2()
        {
            Dog Dog1 = new Dog(10, "Fred");
            Dog Dog2 = new Dog(5, "Pancho");
            Dog Dog3 = new Dog(8, "Buck");
            Dog Dog4 = new Dog(12, "Spike");
            Dog Dog5 = new Dog(1, "Rex");
            List<Dog> DogList = new List<Dog>
            {
                Dog1, Dog2, Dog3, Dog4, Dog5
            };
            List<Cat> cats = new List<Cat>
            {
                new Cat(){ Name = "Sylvester", Age=8 },
                new Cat(){ Name = "Whiskers", Age=2 },
                new Cat(){ Name = "Sasha", Age=14 }
            };
            List<Animals> AnimalList = new List<Animals>
            {
                Dog1, Dog2, Dog3, Dog4, Dog5,

                new Cat(){ Name = "Sylvester", Age=8 },
                new Cat(){ Name = "Whiskers", Age=2 },
                new Cat(){ Name = "Sasha", Age=14 }
            };

            Console.WriteLine();
            Console.WriteLine("Dogs:");
            foreach (Dog Thing in DogList)
            {
                Console.WriteLine("{0} is {1} years old.     ({2})", Thing.Name, Thing.Age, Thing);
            }
            Console.WriteLine();
            Console.WriteLine("Cats:");
            foreach (Cat Thing in cats)
            {
                Console.WriteLine("{0} is {1} years old.     ({2})", Thing.Name, Thing.Age, Thing);
            }
            Console.WriteLine();
            Console.WriteLine("Animals:");
            foreach (Animals Thing in AnimalList)
            {
                Console.WriteLine(Thing);
                //Console.WriteLine("{0} is {1} years old.", Thing.Name, Thing.Age);
            }
        }
    }

    class Cat : Animals
    {
        // Auto-implemented properties. 
        public int Age { get; set; }
        public string Name { get; set; }
    }

    class Animals
    {
        public void Eat()
        {
            Console.WriteLine("Eating");
        }
    }

    class Dog : Animals
    {
        public int Age;
        public string Name;

        public Dog(int AgeIn, string NameIn)
        {
            Age = AgeIn;
            Name = NameIn;
        }

        public void Bark()
        {
            Console.WriteLine("Barking");
        }
    }
}
