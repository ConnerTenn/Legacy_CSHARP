using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class Form1 : Form
    {
        public static Thread oTimmer;
        public static System.Diagnostics.Stopwatch watch;

        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            watch = System.Diagnostics.Stopwatch.StartNew();
            oTimmer = new Thread(new ThreadStart(Timmer.main));
            if (!oTimmer.IsAlive) { oTimmer.Start(); }
            //Display.Text = string.Concat(string.Concat(((8 % 3).ToString()), ","), ((Math.Round((double)8 / 3)).ToString()));
        }

        private void Stop_Click(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            oTimmer.Abort();
        }
    }
}
