using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text___Code_V2
{
    class Code_To_Text
    {
        public static bool Invalid = false;
        public static TextBox t = Application.OpenForms["Form1"].Controls["OutputBox"] as TextBox;

        public static void Convert(string Text_Input)
        {
            Text_Input = Text_Input.Replace(" ", "");
            string Build_Code = "";
            string Final_Code = "";
            foreach (char Number in Text_Input)
            {
                switch (Number)
                {
                    case '0':
                        Build_Code = string.Concat(Build_Code, Number.ToString());
                        Final_Code = string.Concat(Final_Code, string.Join("", (Code_To_Text.Add_To_Code(Build_Code, Text_Input)).ToArray()));
                        Build_Code = "";
                        break;
                    default:
                        Build_Code = string.Concat(Build_Code, Number.ToString());
                        break;
                }
            }
            t.Text = Final_Code;
            List<char> abc2 = new List<char>{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            List<char> Num = new List<char> { '1', '2', '4', '8', '0', '5' };
            /*foreach (char X in Final_Code) 
            {
                Console.WriteLine(X);
                if ((abc2).Contains(X))
                {
                    t.Text = "*Invalid Number Input*";
                }
            }*/
            foreach (char X in Text_Input)
            {
                Console.WriteLine(X);
                if ((Num).Contains(char.Parse((X.ToString()).ToUpper())) == false)
                {
                    Invalid = true;
                }
            }
            if (Invalid == true) { t.Text = "*Invalid Number Input*"; }
        }
        public static string Add_To_Code(string Build_Code, string Text_Input)
        {
            string New_Code = "";
            switch (Build_Code)
            {
                case "10":
                    New_Code = string.Concat(New_Code, "A");
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
                    Invalid = true;
                    break;
            }
            return New_Code;
        }
    }
}
