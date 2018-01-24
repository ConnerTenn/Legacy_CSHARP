using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platformer_Game
{
    public partial class Form1 : Form
    {
        public static Pen myPen = new Pen(Color.Black);
        public static Graphics graphics = null;
        public static Panel Canvas;
        //public static Panel canvas = Application.OpenForms["Form1"].Controls["screen"] as Panel;

        public Form1()
        {
            Console.WriteLine("Hello1");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Hello2");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("Hello3");
            Canvas = canvas;
            myPen.Width = 1;
            graphics = canvas.CreateGraphics();
            //Level1.Startup();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Hello4");
        }
    }
}
