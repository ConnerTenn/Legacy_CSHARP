using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public class Calc3
    {
        public static string function = null;
        public static bool Decimal = true;
        public static bool Positive = true;
        public static TextBox t = Application.OpenForms["Form1"].Controls["screen"] as TextBox;
        public static string FirstNum = "";
        public static string Ans = "";
        public static bool enterfunc = false;

        public static void NumInput(string value)
        {
            if (value == ".")//if the input is "."
            {
                enterfunc = false;
                if (Decimal == true)
                {
                    Decimal = false;
                    string CurrentDisp = (t.Text);
                    CurrentDisp = string.Concat(CurrentDisp, value.ToString());
                    t.Text = CurrentDisp;
                }
            }//end if the input is "."
            else//if the input is not "."
            {
                if (LengthTest(t.Text, 19) == false)//check if screen text is too long
                {
                    if (t.Text == "0" || (t.Text == "-0" && Positive == false) || enterfunc == true)//check if the screen is diplaying 0
                    {
                        if (value == "0")
                        {

                        }
                        else
                        {
                            t.Text = value.ToString();
                            if (Positive == false)
                            {
                                t.Text = string.Concat("-", t.Text);
                            }
                        }
                    }//end check if the screen is diplaying 0
                    else
                    {
                        string CurrentDisp = (t.Text);
                        CurrentDisp = string.Concat(CurrentDisp, value.ToString());
                        t.Text = CurrentDisp;
                    }//end check if the screen is diplaying 0
                }//end check if screen text is too long
            }//end if the input is not "."
            //Ans = t.Text;
        }//end NumInput()

        public static void FuncInput(string Function)
        {
            switch (Function)
            {
                case "+/-":
                    if (Positive == true)
                    {
                        t.Text = string.Concat("-", t.Text);
                        Positive = false;
                    }
                    else
                    {
                        string newtext = "";
                        foreach (char letter in t.Text)
                        {
                            if (letter == '-') { }
                            else
                            {
                                newtext = string.Concat(newtext, letter.ToString());
                            }
                        }
                        //t.Text = ((t.Text).ToArray<char>()).Where(val => val != '-').ToString();
                        t.Text = newtext;
                        Positive = true;
                        enterfunc = false;
                    }
                    break;

                case "+":
                    function = "+";
                    if (FirstNum != "") { Ans = (double.Parse(FirstNum) + double.Parse(t.Text)).ToString();}
                    else { Ans = double.Parse(t.Text).ToString();}
                    FirstNum = Ans;
                    if (Ans != "")
                    {
                        t.Text = Ans;
                    }
                    enterfunc = true;
                    Positive = true;
                    Decimal = true;
                    break;

                case "-":
                    function = "-";
                    if (FirstNum != "") { Ans = (double.Parse(FirstNum) - double.Parse(t.Text)).ToString();}
                    else { Ans = double.Parse(t.Text).ToString();}
                    FirstNum = Ans;
                    if (Ans != "")
                    {
                        t.Text = Ans;
                    }
                    enterfunc = true;
                    Positive = true;
                    Decimal = true;
                    break;

                case "=":
                    if (function == "+") {Ans = (double.Parse(FirstNum) + double.Parse(t.Text)).ToString();}
                    if (function == "-") { Ans = (double.Parse(FirstNum) - double.Parse(t.Text)).ToString(); }
                    t.Text = Ans;
                    FirstNum = "0";
                    break;
            }
        }//end FuncInput()

        public static bool LengthTest(string StringIn, int Length)
        {
            if (StringIn.Length < Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }//end LengthTest
    }//end Calc
}
