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
    class Text_To_Code
    {
        public static bool Invalid = false;

        public static TextBox t = Application.OpenForms["Form1"].Controls["OutputBox"] as TextBox;

        public static void Convert(string Text_Input)
        {
            Text_Input = Text_Input.ToUpper();
            List<string> New_Code = new List<string>();
            foreach (char Letter in Text_Input)
            {
                switch (Letter)
                {
                    case 'A':
                        New_Code.Add("10");
                        break;
                    case 'B':
                        New_Code.Add("20");
                        break;
                    case 'C':
                        New_Code.Add("210");
                        break;
                    case 'D':
                        New_Code.Add("40");
                        break;
                    case 'E':
                        New_Code.Add("410");
                        break;
                    case 'F':
                        New_Code.Add("420");
                        break;
                    case 'G':
                        New_Code.Add("4210");
                        break;
                    case 'H':
                        New_Code.Add("80");
                        break;
                    case 'I':
                        New_Code.Add("810");
                        break;
                    case 'J':
                        New_Code.Add("820");
                        break;
                    case 'K':
                        New_Code.Add("8210");
                        break;
                    case 'L':
                        New_Code.Add("840");
                        break;
                    case 'M':
                        New_Code.Add("8410");
                        break;
                    case 'N':
                        New_Code.Add("8420");
                        break;
                    case 'O':
                        New_Code.Add("84210");
                        break;
                    case 'P':
                        New_Code.Add("880");
                        break;
                    case 'Q':
                        New_Code.Add("8810");
                        break;
                    case 'R':
                        New_Code.Add("8820");
                        break;
                    case 'S':
                        New_Code.Add("88210");
                        break;
                    case 'T':
                        New_Code.Add("8840");
                        break;
                    case 'U':
                        New_Code.Add("88410");
                        break;
                    case 'V':
                        New_Code.Add("88420");
                        break;
                    case 'W':
                        New_Code.Add("884210");
                        break;
                    case 'X':
                        New_Code.Add("8880");
                        break;
                    case 'Y':
                        New_Code.Add("88810");
                        break;
                    case 'Z':
                        New_Code.Add("88820");
                        break;
                    case '.':
                        New_Code.Add("550");
                        break;
                    case ' ':
                        New_Code.Add("50");
                        break;
                    default:
                        Invalid = true;
                        break;
                }
                if (Invalid == true) { break; }
            }
            string OutText = "";
            foreach (string Item in New_Code)
            {
                OutText = string.Concat(OutText, Item.ToString());
            }
            Console.WriteLine(Invalid);
            t.Text = OutText;
            if (Invalid == true) { t.Text = "*Invalid Text Input*"; }
        }
    }
}
