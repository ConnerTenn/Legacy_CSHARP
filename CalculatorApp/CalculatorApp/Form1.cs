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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }//end Form1()

        public void button0_Click(object sender, EventArgs e)
        {
            string value = "0";
            //string[] values = {screen.Text, value.ToString()};
            CalculatorApp.Calc.NumInput(value);
        }//end button0_Click

        public void button1_Click(object sender, EventArgs e)
        {
            string value = "1";
            CalculatorApp.Calc.NumInput(value);
        }//end button1_Click

        private void button2_Click(object sender, EventArgs e)
        {
            string value = "2";
            CalculatorApp.Calc.NumInput(value);
        }//end button2_Click

        private void button3_Click(object sender, EventArgs e)
        {
            string value = "3";
            CalculatorApp.Calc.NumInput(value);
        }//end button3_Click

        private void button4_Click(object sender, EventArgs e)
        {
            string value = "4";
            CalculatorApp.Calc.NumInput(value);
        }//end button4_Click

        private void button5_Click(object sender, EventArgs e)
        {
            string value = "5";
            CalculatorApp.Calc.NumInput(value);
        }//end button5_Click

        private void button6_Click(object sender, EventArgs e)
        {
            string value = "6";
            CalculatorApp.Calc.NumInput(value);
        }//end button6_Click

        private void button7_Click(object sender, EventArgs e)
        {
            string value = "7";
            CalculatorApp.Calc.NumInput(value);
        }//end button7_Click

        private void button8_Click(object sender, EventArgs e)
        {
            string value = "8";
            CalculatorApp.Calc.NumInput(value);
        }//end button8_Click

        private void button9_Click(object sender, EventArgs e)
        {
            string value = "9";
            CalculatorApp.Calc.NumInput(value);
        }//end button9_Click

        private void period_Click(object sender, EventArgs e)
        {
            string value = ".";
            CalculatorApp.Calc.NumInput(value);
        }//end period_Click

        private void clear_Click(object sender, EventArgs e)
        {
            screen.Text = "0";
            Calc.Decimal = true;
            Calc.Positive = true;
            Calc.Ans = "";
            Calc.enterfunc = false;
            Calc.equalfunc = false;
            Calc.FirstNum = "";
        }//end clear_Click

        private void invert_Click(object sender, EventArgs e)
        {
            string Function = "+/-";
            CalculatorApp.Calc.FuncInput(Function);
        }

        private void add_Click(object sender, EventArgs e)
        {
            string Function = "+";
            CalculatorApp.Calc.FuncInput(Function);
        }

        private void enter_Click(object sender, EventArgs e)
        {
            string Function = "=";
            //CalculatorApp.Calc.FuncInput(Function);
            CalculatorApp.Calc.FuncInput(Function);
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            string Function = "-";
            CalculatorApp.Calc.FuncInput(Function);
        }//end invert_Click
    }//end partial class
}//end namespace
