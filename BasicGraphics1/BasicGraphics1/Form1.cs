using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicGraphics1
{
    public partial class Form1 : Form
    {
        Pen myPen = new Pen(Color.Black);
        Graphics graphics = null;

        static int Center_X, Center_Y;
        static int Start_X, Start_Y;
        static int End_X, End_Y;
        static int Angle = 0;
        static int Length = 0;
        static int Increment = 0;
        static int Num_Lines = 0;

        public Form1()
        {
            InitializeComponent();
            Start_X = canvas.Width / 2;
            Start_Y = canvas.Height / 2;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            myPen.Width = 1;
            //Length = Length + Int32.Parse(Length_In.Text);
            graphics = canvas.CreateGraphics();
            for(int i = 0; i < Num_Lines; i++)
            {
                Draw();
            }
        }

        private void Draw()
        {
            Angle = Angle + Int32.Parse(Angle_In.Text);
            Length = Length + Int32.Parse(Increment_In.Text);

            End_X = (int)(Start_X + Math.Cos(Angle * 0.017453292519) * Length);
            End_Y = (int)(Start_Y + Math.Sin(Angle * 0.017453292519) * Length);
            Point[] points={
                               new Point(Start_X, Start_Y),
                               new Point(End_X, End_Y)
                           };

            Start_X = End_X;
            Start_Y = End_Y;

            graphics.DrawLines(myPen, points);
        }//end Draw()

        private void Go_Button_Click(object sender, EventArgs e)
        {
            Angle = Int32.Parse(Angle_In.Text);
            Length = Int32.Parse(Length_In.Text);
            Increment = Int32.Parse(Increment_In.Text);
            Num_Lines = Int32.Parse(Number_Line_In.Text);

            Start_X = canvas.Width / 2;
            Start_Y = canvas.Height / 2;

            canvas.Refresh();
        }
    }
}
