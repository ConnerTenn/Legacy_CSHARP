using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicGraphics2
{
    public partial class Form1 : Form
    {
        static Graphics graphics = null;
        static Pen blackPen = new Pen(Color.Black, 3);

        static int a = 100;

        public Form1()
        {
            InitializeComponent();
        }

        public void canvas_Paint(object sender, PaintEventArgs e)
        {
            graphics = canvas.CreateGraphics();
            Draw();
            if (a == 100) { a = 200; } else { a = 100; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                canvas.Refresh();
            }
        }

        public static void Draw()
        {
            
            graphics.DrawLine(blackPen, 100, a, 200, 100);
        }
    }
}
