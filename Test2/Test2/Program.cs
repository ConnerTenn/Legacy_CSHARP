using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        static void Main()
        {
            string Int;
            Console.Write("Input:");
            Int = Console.ReadLine();
            switch(Int)
            {
                case "1":
                    Console.WriteLine("Choice 1");
                    break;
                case "2":
                    Console.WriteLine("Choice 2");
                    break;
                case "3":
                    Console.WriteLine("Choice 3");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    Test2.Program.Main();
                    break;
            }
            Console.WriteLine();
            Console.Write("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}
