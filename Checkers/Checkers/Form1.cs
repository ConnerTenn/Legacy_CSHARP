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

namespace Checkers
{
    public partial class GameWindow : Form
    {
        //Main game object for managing things like graphics, ect.
        private Game game = new Game();
        public Graphics PaintGraphics;

        public GameWindow()
        {
            InitializeComponent();
            game.loadLevel();
            Graphics g = canvas.CreateGraphics();
            game.startGraphics(g);
        }

        //Canvas paint function - launches paint functionality
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            //Game.Count1 = Player1CountText;
            //Game.Count2 = Player2CountText;
            //game.loadLevel();
            //Graphics g = canvas.CreateGraphics();
            //game.startGraphics(g);
            //PaintGraphics = g;
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

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            game.loadLevel();
        }

        // Allows the cammand line to be seen during normal execution
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Game.EndGame)
            {
                //Console.WriteLine("GameWindow:  Mouse Click X = {0}, Mouse Click Y = {1}", e.X, e.Y);

                //int ClickGridX = (int)Math.Round((double)e.X / 50);
                int ClickGridX = (int)(e.X / 50);
                //int ClickGridY = (int)Math.Round((double)e.Y / 50);
                int ClickGridY = (int)(e.Y / 50);
                Console.WriteLine("GameWindow:  Mouse Grid Click [X, Y] = [{0}, {1}]", ClickGridX, ClickGridY);


                if (Game.CurrentPlayer == 1)
                {
                    if (Game.Doubles)
                    {
                        if (ClickGridX == Game.DoubleX && ClickGridY == Game.DoubleY && (Game.GameGrid[ClickGridX, ClickGridY] == 1 || Game.GameGrid[ClickGridX, ClickGridY] == 2))
                        {
                            Game.SelectedX = ClickGridX;
                            Game.SelectedY = ClickGridY;
                            //Game.DoubleX = ClickGridX;
                            //Game.DoubleY = ClickGridY;
                            Game.ClickPiece = Game.GameGrid[ClickGridX, ClickGridY];
                            Game.MovePiece = true;
                        }
                        else if (Game.GameGrid[ClickGridX, ClickGridY] == 3 || Game.GameGrid[ClickGridX, ClickGridY] == 4)
                        {
                            Game.SelectedX = ClickGridX;
                            Game.SelectedY = ClickGridY;
                            //Game.DoubleX = ClickGridX;
                            //Game.DoubleY = ClickGridY;
                            Game.ClickPiece = Game.GameGrid[ClickGridX, ClickGridY];
                            Game.MovePiece = true;
                            //Game.Doubles = false;
                        }
                    }
                    else if (Game.GameGrid[ClickGridX, ClickGridY] == 1 || Game.GameGrid[ClickGridX, ClickGridY] == 2)
                    {
                        Game.SelectedX = ClickGridX;
                        Game.SelectedY = ClickGridY;
                        Game.ClickPiece = Game.GameGrid[ClickGridX, ClickGridY];
                        Game.MovePiece = true;
                    }
                }
                else if (Game.CurrentPlayer == 2)
                {
                    if (Game.Doubles)
                    {
                        if (ClickGridX == Game.DoubleX && ClickGridY == Game.DoubleY && (Game.GameGrid[ClickGridX, ClickGridY] == 3 || Game.GameGrid[ClickGridX, ClickGridY] == 4))
                        {
                            Game.SelectedX = ClickGridX;
                            Game.SelectedY = ClickGridY;
                            Game.DoubleX = ClickGridX;
                            Game.DoubleY = ClickGridY;
                            Game.ClickPiece = Game.GameGrid[ClickGridX, ClickGridY];
                            Game.MovePiece = true;
                        }
                        else if (Game.GameGrid[ClickGridX, ClickGridY] == 1 || Game.GameGrid[ClickGridX, ClickGridY] == 2)
                        {
                            Game.SelectedX = ClickGridX;
                            Game.SelectedY = ClickGridY;
                            Game.DoubleX = ClickGridX;
                            Game.DoubleY = ClickGridY;
                            Game.ClickPiece = Game.GameGrid[ClickGridX, ClickGridY];
                            Game.MovePiece = true;
                            //Game.Doubles = false;
                        }
                    }
                    else if (Game.GameGrid[ClickGridX, ClickGridY] == 3 || Game.GameGrid[ClickGridX, ClickGridY] == 4)
                    {
                        Game.SelectedX = ClickGridX;
                        Game.SelectedY = ClickGridY;
                        Game.ClickPiece = Game.GameGrid[ClickGridX, ClickGridY];
                        Game.MovePiece = true;
                    }
                }
                else { Game.ClickPiece = -1; }

                if (Game.MovePiece)
                {
                    if (Game.ClickPiece == 1) // If current player is player1
                    {
                        if (Math.Abs(ClickGridX - Game.SelectedX) == 1 && (ClickGridY - Game.SelectedY == 1) && (Game.GameGrid[ClickGridX, ClickGridY] == 0))
                        {
                            //Console.WriteLine(0);
                            Game.GameGrid[ClickGridX, ClickGridY] = Game.ClickPiece;
                            Game.GameGrid[Game.SelectedX, Game.SelectedY] = 0;
                            Game.MovePiece = false;
                            Game.CurrentPlayer = 2;
                            Game.PlacedPiece = true;
                            Game.Doubles = false;
                        }
                        if (Math.Abs(ClickGridX - Game.SelectedX) == 2 && (ClickGridY - Game.SelectedY == 2) && (Game.GameGrid[ClickGridX, ClickGridY] == 0))
                        {
                            if (Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, Game.SelectedY + 1] == 3 || Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, Game.SelectedY + 1] == 4)
                            {
                                Game.GameGrid[ClickGridX, ClickGridY] = Game.ClickPiece;
                                Game.GameGrid[Game.SelectedX, Game.SelectedY] = 0;
                                Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, Game.SelectedY + 1] = 0;
                                Game.MovePiece = false;
                                Game.CurrentPlayer = 2;
                                Game.PlacedPiece = true;
                                Game.JumpPiece = true;
                                Game.Doubles = false;
                            }
                        }
                    }
                    if (Game.ClickPiece == 2) // If current player is player2
                    {
                        if (Math.Abs(ClickGridX - Game.SelectedX) == 1 && Math.Abs(ClickGridY - Game.SelectedY) == 1 && (Game.GameGrid[ClickGridX, ClickGridY] == 0))
                        {
                            Game.GameGrid[ClickGridX, ClickGridY] = Game.ClickPiece;
                            Game.GameGrid[Game.SelectedX, Game.SelectedY] = 0;
                            Game.MovePiece = false;
                            Game.CurrentPlayer = 2;
                            Game.PlacedPiece = true;
                            Game.Doubles = false;
                        }
                        if (Math.Abs(ClickGridX - Game.SelectedX) == 2 && Math.Abs(ClickGridY - Game.SelectedY) == 2 && (Game.GameGrid[ClickGridX, ClickGridY] == 0))
                        {
                            if (Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, (Game.SelectedY + ClickGridY) / 2] == 3 || Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, (Game.SelectedY + ClickGridY) / 2] == 4)
                            {
                                Game.GameGrid[ClickGridX, ClickGridY] = Game.ClickPiece;
                                Game.GameGrid[Game.SelectedX, Game.SelectedY] = 0;
                                Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, (Game.SelectedY + ClickGridY) / 2] = 0;
                                Game.MovePiece = false;
                                Game.CurrentPlayer = 2;
                                Game.PlacedPiece = true;
                                Game.JumpPiece = true;
                                Game.Doubles = false;
                            }
                        }
                    }
                    if (Game.ClickPiece == 3)// If current player is player3
                    {
                        if (Math.Abs(ClickGridX - Game.SelectedX) == 1 && (Game.SelectedY - ClickGridY == 1) && (Game.GameGrid[ClickGridX, ClickGridY] == 0))
                        {
                            Game.GameGrid[ClickGridX, ClickGridY] = Game.ClickPiece;
                            Game.GameGrid[Game.SelectedX, Game.SelectedY] = 0;
                            Game.MovePiece = false;
                            Game.CurrentPlayer = 1;
                            Game.PlacedPiece = true;
                            Game.Doubles = false;
                        }
                        if (Math.Abs(ClickGridX - Game.SelectedX) == 2 && (Game.SelectedY - ClickGridY == 2) && (Game.GameGrid[ClickGridX, ClickGridY] == 0))
                        {
                            if (Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, Game.SelectedY - 1] == 1 || Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, Game.SelectedY - 1] == 2)
                            {
                                Game.GameGrid[ClickGridX, ClickGridY] = Game.ClickPiece;
                                Game.GameGrid[Game.SelectedX, Game.SelectedY] = 0;
                                Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, Game.SelectedY - 1] = 0;
                                Game.MovePiece = false;
                                Game.CurrentPlayer = 1;
                                Game.PlacedPiece = true;
                                Game.JumpPiece = true;
                                Game.Doubles = false;
                            }
                        }
                    }
                    if (Game.ClickPiece == 4)// If current player is player4
                    {
                        if (Math.Abs(ClickGridX - Game.SelectedX) == 1 && Math.Abs(ClickGridY - Game.SelectedY) == 1 && (Game.GameGrid[ClickGridX, ClickGridY] == 0))
                        {
                            Game.GameGrid[ClickGridX, ClickGridY] = Game.ClickPiece;
                            Game.GameGrid[Game.SelectedX, Game.SelectedY] = 0;
                            Game.MovePiece = false;
                            Game.CurrentPlayer = 1;
                            Game.PlacedPiece = true;
                            Game.Doubles = false;
                        }
                        if (Math.Abs(ClickGridX - Game.SelectedX) == 2 && Math.Abs(ClickGridY - Game.SelectedY) == 2 && (Game.GameGrid[ClickGridX, ClickGridY] == 0))
                        {
                            if (Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, (Game.SelectedY + ClickGridY) / 2] == 1 || Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, (Game.SelectedY + ClickGridY) / 2] == 2)
                            {
                                Game.GameGrid[ClickGridX, ClickGridY] = Game.ClickPiece;
                                Game.GameGrid[Game.SelectedX, Game.SelectedY] = 0;
                                Game.GameGrid[(Game.SelectedX + ClickGridX) / 2, (Game.SelectedY + ClickGridY) / 2] = 0;
                                Game.MovePiece = false;
                                Game.CurrentPlayer = 1;
                                Game.PlacedPiece = true;
                                Game.JumpPiece = true;
                                Game.Doubles = false;
                            }
                        }
                    }
                }

                if (Game.PlacedPiece && Game.JumpPiece)
                {
                    int check1 = 0;
                    int check2 = 0;
                    bool Change = false;
                    if (Game.CurrentPlayer == 1) { check1 = 1; check2 = 2; }
                    if (Game.CurrentPlayer == 2) { check1 = 3; check2 = 4; }
                    //Console.WriteLine("Begin Loop");
                    for (int x = -2; x <= 2; x += 2)
                    {
                        for (int y = -2; y <= 2; y += 2)
                        {
                            //Console.WriteLine("X: {0}, Y: {1}", x, y);
                            if (ClickGridX + x >= 0 && ClickGridX + x <= 7 && ClickGridY + y >= 0 && ClickGridY + y <= 7 && !Change)
                            {
                                //Console.WriteLine("Good Range");
                                int NewX = ClickGridX + x;
                                int NewY = ClickGridY + y;
                                if (Game.GameGrid[ClickGridX, ClickGridY] == 2 || Game.GameGrid[ClickGridX, ClickGridY] == 4)
                                {
                                    if (Math.Abs(NewX - ClickGridX) == 2 && Math.Abs(NewY - ClickGridY) == 2 && (Game.GameGrid[NewX, NewY] == 0))
                                    {
                                        if (Game.GameGrid[(NewX + ClickGridX) / 2, (NewY + ClickGridY) / 2] == check1 || Game.GameGrid[(NewX + ClickGridX) / 2, (NewY + ClickGridY) / 2] == check2)
                                        {
                                            if (Game.CurrentPlayer == 1) { Game.CurrentPlayer = 2; }
                                            else if (Game.CurrentPlayer == 2) { Game.CurrentPlayer = 1; }
                                            Change = true;
                                            Game.Doubles = true;
                                            Game.DoubleX = ClickGridX; Game.DoubleY = ClickGridY;
                                            Game.SelectedX = Game.DoubleX; Game.SelectedY = Game.DoubleY;
                                            Game.MovePiece = true;
                                        }
                                        else { Game.PlacedPiece = false; }
                                    }// If 
                                }
                                if (Game.GameGrid[ClickGridX, ClickGridY] == 1)
                                {
                                    if (Math.Abs(NewX - ClickGridX) == 2 && (NewY - ClickGridY) == 2 && (Game.GameGrid[NewX, NewY] == 0))
                                    {
                                        if (Game.GameGrid[(NewX + ClickGridX) / 2, (NewY + ClickGridY) / 2] == check1 || Game.GameGrid[(NewX + ClickGridX) / 2, (NewY + ClickGridY) / 2] == check2)
                                        {
                                            if (Game.CurrentPlayer == 1) { Game.CurrentPlayer = 2; }
                                            else if (Game.CurrentPlayer == 2) { Game.CurrentPlayer = 1; }
                                            Change = true;
                                            Game.Doubles = true;
                                            Game.DoubleX = ClickGridX; Game.DoubleY = ClickGridY;
                                            Game.SelectedX = Game.DoubleX; Game.SelectedY = Game.DoubleY;
                                            Game.MovePiece = true;
                                        }
                                        else { Game.PlacedPiece = false; }
                                    }// If 
                                }
                                if (Game.GameGrid[ClickGridX, ClickGridY] == 3)
                                {
                                    if (Math.Abs(NewX - ClickGridX) == 2 && (NewY - ClickGridY) == -2 && (Game.GameGrid[NewX, NewY] == 0))
                                    {
                                        if (Game.GameGrid[(NewX + ClickGridX) / 2, (NewY + ClickGridY) / 2] == check1 || Game.GameGrid[(NewX + ClickGridX) / 2, (NewY + ClickGridY) / 2] == check2)
                                        {
                                            if (Game.CurrentPlayer == 1) { Game.CurrentPlayer = 2; }
                                            else if (Game.CurrentPlayer == 2) { Game.CurrentPlayer = 1; }
                                            Change = true;
                                            Game.Doubles = true;
                                            Game.DoubleX = ClickGridX; Game.DoubleY = ClickGridY;
                                            Game.SelectedX = Game.DoubleX; Game.SelectedY = Game.DoubleY;
                                            Game.MovePiece = true;
                                        }
                                        else { Game.PlacedPiece = false; }
                                    }// If 
                                }
                                else { Game.PlacedPiece = false; }
                            }// For Y
                            else { Game.PlacedPiece = false; }
                        }// For X
                    }
                }

                Game.Player1Count = 0;
                Game.Player2Count = 0;
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if (Game.GameGrid[x, y] == 1 || Game.GameGrid[x, y] == 2) { Game.Player1Count++; } // count Player1
                        if (Game.GameGrid[x, y] == 3 || Game.GameGrid[x, y] == 4) { Game.Player2Count++; } // count Player2

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
                if (Game.Player1Count <= 0) { Game.EndGame = true; Game.Winner = "Yellow"; }
                if (Game.Player2Count <= 0) { Game.EndGame = true; Game.Winner = "Brown"; }

                Console.WriteLine("GameWindow:  Current Player = {0}, Move Piece = {1}, Value at click location = {2}, Player1Count = {3}, Player2Count = {4}, EndGame = {5}", Game.CurrentPlayer, Game.MovePiece, Game.GameGrid[ClickGridX, ClickGridY], Game.Player1Count, Game.Player2Count, Game.EndGame);
                Console.WriteLine();
                //Player1CountText.Text = Game.CurrentPlayer.ToString();
                Game.JumpPiece = false;
            }
        }
    }
}
