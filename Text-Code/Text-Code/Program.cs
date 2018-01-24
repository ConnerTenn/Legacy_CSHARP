using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace Text_Code
{
    class Program
    {
        public static void Main()
        {
            Console.Clear();
            bool Loop = true;
            do
            {
                Console.WriteLine("1: Convert Text to Code");
                Console.WriteLine("2: Convert Code to Text");
                Console.WriteLine("3: Quit Program");
                Console.Write("Enter Choice (1,2,3): ");
                string Choice = "";
                Choice = Console.ReadLine();
                switch (Choice)
                {
                    case "1":
                        Console.Clear();
                        Text_Code.Text_To_Code.Convert();
                        break;
                    case "2":
                        Console.Clear();
                        Text_Code.Code_To_Text.Convert();
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.Write("Press Enter To Exit");
                        Console.ReadLine();
                        Console.WriteLine();
                        Loop = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Selection");
                        Console.WriteLine();
                        break;
                }
            } while(Loop==true);
        }
    }
}
