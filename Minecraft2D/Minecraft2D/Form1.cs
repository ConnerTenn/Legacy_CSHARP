using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Minecraft2D
{
    public partial class GameWindow : Form
    {
        

        //Main game object for managing things like graphics, ect.
        private Game game = new Game();

        public GameWindow()
        {
            InitializeComponent();
        }

        //Canvas paint function - launches paint functionality
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            game.loadLevel();
            Graphics g = canvas.CreateGraphics();
            game.startGraphics(g);
            
        }

        //Stops the game before the form is closed,and therefore before any exceptions can occur.
        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.stopGame();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        // Allows the cammand line to be seen during normal execution
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Key = {0}", e.KeyData);
            string Key = e.KeyData.ToString();
            InputHandle.KeyHandle(Key);
        }
    }
}
