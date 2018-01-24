using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public static void Main()
        {
            Console.Write("Enter name: ");
            string Number = Console.ReadLine();
            Second.Print(Number);
        }
    }

    class Second
    {
        public static void Print(string args)
        {
            Console.WriteLine("Name: {0}", args);
            for (int LoopVal = 0; LoopVal <= 20; LoopVal++)
            {
                Console.WriteLine("");
            }
            Console.Write("Press Enter To Exit.");
            Console.ReadLine();
        }
    }
}