using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

using System.Drawing;

namespace Checkers
{
    class Game
    {
        /*-------------------Constants-----------------*/
        public const int CANVAS_Width = 1200;
        public const int CANVAS_HEIGHT = 700;
        public const int LEVEL_WIDTH = 24;
        public const int LEVEL_HEIGHT = 14;
        public const int TILE_SIDE_LENGTH = 50;

        /*---------------Game Vars---------------------*/
        public static int[,] GameGrid = new int[8, 8];
        public static bool Play = true;
        public static int Player1Count = 0;
        public static int Player2Count = 0;
        public static int SelectedX, SelectedY;
        public static int DoubleX, DoubleY;
        public static bool Doubles = false;
        public static bool MovePiece = false;
        public static int CurrentPlayer = 2;
        public static int ClickPiece = -1;
        public static bool PlacedPiece = false;
        public static bool JumpPiece = false;
        public static bool EndGame = false;
        public static string Winner = "";
        public static bool Running = false;

        /*-------------------Members-------------------*/
        public GEngine gEngine;
        private Thread UpdateThread;
        //public static TextBox Count1;
        //public static TextBox Count2;
        //public static TextBox Count1 = Application.OpenForms["GameWindow"].Controls["Player1CountText"] as TextBox;
        //public static TextBox Count2 = Application.OpenForms["GameWindow"].Controls["Player2CountText"] as TextBox;

        //Load the level
        public void loadLevel()
        {
            //Level.initLevel();
            GameGrid = new int[8, 8];
            Play = true;
            Player1Count = 0;
            Player2Count = 0;
            MovePiece = false;
            CurrentPlayer = 2;
            ClickPiece = -1;
            PlacedPiece = false;
            JumpPiece = false;
            EndGame = false;
            Winner = "";

            //1: Player1,   2: Player1 King,   3: Player2,   4: Player2 King
            bool XSwitxh = true;
            bool YSwitxh = true;
            //bool YSwitxh = true;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    GameGrid[x, y] = 0;
                }
            }
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (XSwitxh && YSwitxh)
                    {
                        if (y <= 2) {GameGrid[x, y] = 1;}
                        else if (y >= 5) { GameGrid[x, y] = 3; }
                    }
                    if (!XSwitxh && !YSwitxh)
                    {
                        if (y <= 2) { GameGrid[x, y] = 1; }
                        else if (y >= 5) { GameGrid[x, y] = 3; }
                    }

                    switch (XSwitxh)
                    {
                        case true: XSwitxh = false; break;
                        case false: XSwitxh = true; break;
                    }
                }
                switch (YSwitxh)
                {
                    case true: YSwitxh = false; break;
                    case false: YSwitxh = true; break;
                }
            }

            if (!Running)
            {
                UpdateThread = new Thread(new ThreadStart(Game.Update));
                UpdateThread.Start();
            }
            Running = true;
        }

        // Launches the graphics engine
        public void startGraphics(Graphics g)
        {
            
            gEngine = new GEngine(g);
            gEngine.init();
        }

        // closes all extra threads when the window closes
        public void stopGame()
        {
            gEngine.stop();
            UpdateThread.Abort();
        }

        public static void Update()
        {
            while (Game.Play)
            {
                /*
                Player1Count = 0;
                Player2Count = 0;
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if (Game.GameGrid[x, y] == 1 || Game.GameGrid[x, y] == 2) { Game.Player1Count++; } // count Player1
                        if (Game.GameGrid[x, y] == 3 || Game.GameGrid[x, y] == 4) { Game.Player2Count++; } // count Player1

                        if (y == 7)
                        {
                            if (Game.GameGrid[x, y] == 1) { Game.GameGrid[x, y] = 2; Console.WriteLine("Game.Update:  Changed Player '1' to Player '2'"); }
                        }
                        if (y == 0)
                        {
                            if (Game.GameGrid[x, y] == 3) { Game.GameGrid[x, y] = 4; Console.WriteLine("Game.Update:  Changed Player '3' to Player '4'"); }
                        }
                    }
                }
                //Console.WriteLine("Player1Count = {0}", Player1Count);
                if (Player1Count <= 0) { EndGame = true; Winner = "Brown"; }
                if (Player2Count <= 0) { EndGame = true; Winner = "Yellow"; } 
                */
            }
        }
    }

    /*public enum TextureID
    {
        air,
        dirt
    }*/
}
