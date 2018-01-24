using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicGraphics3
{
    public partial class Form1 : Form
    {
        Pen myPen = new Pen(Color.Black);
        Graphics graphics = null;

        static int Xpos = 10;
        static int Ypos = 10;
        static int Xpos2 = Xpos + 20;
        static int Ypos2 = Ypos + 20;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            myPen.Width = 1;
            graphics = canvas.CreateGraphics();
            //string coords = string.Concat(Xpos.ToString(), Ypos.ToString());
            string coords = string.Concat(Xpos.ToString(), ",");
            coords = string.Concat(coords, Ypos.ToString());
            coords = string.Concat(coords, ",");
            coords = string.Concat(coords, Xpos2.ToString());
            coords = string.Concat(coords, ",");
            coords = string.Concat(coords, Ypos2.ToString());
            CoordsDisp.Text = coords;
            Draw();
        }

        private void Draw()
        {
            Rectangle rectangle = new Rectangle(Xpos, Ypos, 20, 20);
            graphics.DrawRectangle(myPen, rectangle);
            Console.WriteLine("HI");
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char a = e.KeyChar;
            switch (a)
            {
                case 'w':
                    Ypos--;
                    break;
                case 's':
                    Ypos++;
                    break;
                case 'a':
                    Xpos--;
                    break;
                case 'd':
                    Xpos++;
                    break;
            }
            Xpos2 = Xpos + 20;
            Ypos2 = Ypos + 20;
            canvas.Refresh();
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            string Mcoords = string.Concat(e.X.ToString(), ",");
            Mcoords = string.Concat(Mcoords, e.Y.ToString());
            MCoordsDisp.Text = Mcoords;
        }
    }
}
