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
    class Calc
    {
        public static string function = null;
        public static bool Decimal = true;
        public static bool Positive = true;
        public static TextBox t = Application.OpenForms["Form1"].Controls["screen"] as TextBox;
        public static string FirstNum = "";
        public static string SecondNum = "";
        public static string CurrentValue = "0";
        public static string Ans = "0";
        public static bool enterfunc = false;
        public static bool equalfunc = false;
        public static string LastButton = "";

        public static void NumInput(string value)
        {
            CurrentValue = t.Text;
            if ((t.Text).Length < 19)//if StringIn.Length < Length
            {
                switch (value)
                {
                    case "0":
                        if (CurrentValue == "0" || CurrentValue == "-0" || LastButton == "+" || LastButton == "=")
                        {
                            CurrentValue = value;
                        }
                        else
                        {
                            CurrentValue = string.Concat(CurrentValue, value);
                        }
                        break;
                    case ".":
                        if (Decimal == true) { CurrentValue = string.Concat(CurrentValue, "."); Decimal = false; }
                        else { }
                        break;
                    default:
                        if (CurrentValue == "0" || CurrentValue == "-0" || LastButton == "+" || LastButton == "=")
                        {
                            CurrentValue = value;
                        }
                        else
                        {
                            CurrentValue = string.Concat(CurrentValue, value);
                        }
                        break;
                }
                LastButton = value;
                t.Text = CurrentValue;
            }
        }
        public static void FuncInput(string Function)
        {
            Console.WriteLine(); 
            Console.Write(1);
            if (equalfunc == false)
            {
                Console.Write(2);
                if (FirstNum == "") { FirstNum = t.Text; }
                else { SecondNum = t.Text; }
            }
            switch (Function)
            {
                case "+":
                    equalfunc = false;
                    Console.Write(3);
                    function = "+";
                    if (enterfunc == true)
                    {
                        Console.Write(4);
                        LastButton = Function;
                        FuncInput("=");
                    }
                    enterfunc = true;
                    Decimal = true;
                    break; 
                case "=":
                    Console.Write(5);
                    //if (equalfunc == true) { SecondNum = Ans; }
                    Func();
                    if (enterfunc == true && equalfunc == false) { FirstNum = Ans; }
                    else if (equalfunc == true) { }
                    else { Ans = FirstNum; }
                    //enterfunc = true;
                    //if (LastButton != "+" && enterfunc == true) { equalfunc = true; Console.Write(6); }
                    //if ( enterfunc == true) { equalfunc = true; Console.Write(7); }
                    if (LastButton != "+") { equalfunc = true; Console.Write(8); }
                    //if (equalfunc == true || enterfunc == true) { enterfunc = false; Console.Write(7); }
                    //if (LastButton == "+") { enterfunc = false; }
                    enterfunc = false;
                    t.Text = Ans;
                    Decimal = true;
                    LastButton = Function;
                    break;
            }
            LastButton = Function;
        }

        public static void Func()
        {
            switch (function)
            {
                case "+":
                    if (equalfunc == true) { Ans = (double.Parse(SecondNum) + double.Parse(Ans)).ToString(); }
                    else { Ans = (double.Parse(FirstNum) + double.Parse(SecondNum)).ToString(); }
                    break;
            }
            return;
        }
    }
}
