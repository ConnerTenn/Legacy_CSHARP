using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Code
{
    class Code_To_Text
    {
        public static void Convert()
        {
            Console.Clear();
            Console.Write("Enter Code To Be Converted: ");
            string Text_Input = Console.ReadLine();
            string Build_Code = "";
            string Final_Code = "";
            foreach (char Number in Text_Input)
            {
                switch(Number) 
                {
                    case '0':
                        Build_Code= string.Concat(Build_Code, Number.ToString());
                        Final_Code = string.Concat(Final_Code, string.Join("", (Code_To_Text.Add_To_Code(Build_Code)).ToArray()));
                        Build_Code = "";
                        break;
                    default:
                        Build_Code = string.Concat(Build_Code, Number.ToString());
                        break;
                }
            }
            Console.Write("Code \"{0}\" = {1}", Text_Input, Final_Code);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press Enter To Continue ");
            Console.ReadLine();
            Text_Code.Program.Main();
        }
        public static string Add_To_Code(string Build_Code)
        {
            string New_Code = "";
            switch(Build_Code)
            {
                case "10":
                    New_Code= string.Concat(New_Code, "A");
                    break;
                case "20":
                    New_Code = string.Concat(New_Code, "B");
                    break;
                case "210":
                    New_Code = string.Concat(New_Code, "C");
                    break;
                case "40":
                    New_Code = string.Concat(New_Code, "D");
                    break;
                case "410":
                    New_Code = string.Concat(New_Code, "E");
                    break;
                case "420":
                    New_Code = string.Concat(New_Code, "F");
                    break;
                case "4210":
                    New_Code = string.Concat(New_Code, "G");
                    break;
                case "80":
                    New_Code = string.Concat(New_Code, "H");
                    break;
                case "810":
                    New_Code = string.Concat(New_Code, "I");
                    break;
                case "820":
                    New_Code = string.Concat(New_Code, "J");
                    break;
                case "8210":
                    New_Code = string.Concat(New_Code, "K");
                    break;
                case "840":
                    New_Code = string.Concat(New_Code, "L");
                    break;
                case "8410":
                    New_Code = string.Concat(New_Code, "M");
                    break;
                case "8420":
                    New_Code = string.Concat(New_Code, "N");
                    break;
                case "84210":
                    New_Code = string.Concat(New_Code, "O");
                    break;
                case "880":
                    New_Code = string.Concat(New_Code, "P");
                    break;
                case "8810":
                    New_Code = string.Concat(New_Code, "Q");
                    break;
                case "8820":
                    New_Code = string.Concat(New_Code, "R");
                    break;
                case "88210":
                    New_Code = string.Concat(New_Code, "S");
                    break;
                case "8840":
                    New_Code = string.Concat(New_Code, "T");
                    break;
                case "88410":
                    New_Code = string.Concat(New_Code, "U");
                    break;
                case "88420":
                    New_Code = string.Concat(New_Code, "V");
                    break;
                case "884210":
                    New_Code = string.Concat(New_Code, "W");
                    break;
                case "8880":
                    New_Code = string.Concat(New_Code, "X");
                    break;
                case "88810":
                    New_Code = string.Concat(New_Code, "Y");
                    break;
                case "88820":
                    New_Code = string.Concat(New_Code, "Z");
                    break;
                case "550":
                    New_Code = string.Concat(New_Code, ".");
                    break;
                case "50":
                    New_Code = string.Concat(New_Code, " ");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Numbers");
                    Console.WriteLine();
                    Text_Code.Code_To_Text.Convert();
                    break;
            }
            return New_Code;
        }
    }
}
