using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Drawing;

namespace Checkers
{
    class GEngine
    {
        /*-------------------Members-------------------*/
        public static Graphics drawHandle;
        private Thread renderThread;

        private Bitmap tex_Board;
        private Bitmap tex_Player1;
        private Bitmap tex_Player1Highlight;
        private Bitmap tex_Player2;
        private Bitmap tex_Player2Highlight;

        private Bitmap tex_Player1King;
        private Bitmap tex_Player1HighlightKing;
        private Bitmap tex_Player2King;
        private Bitmap tex_Player2HighlightKing;
        //private Bitmap tex_test;

        /*-------------------Functions-------------------*/
        public GEngine(Graphics g)
        {
            drawHandle = g;
        }

        //Takes care of initalizing all importent things.
        public void init()
        {
            //Load assets
            loadAssets();

            //Start render thread
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

        //Loads resources
        private void loadAssets()
        {
            //tex_Board = Checkers.Properties.Resources.CheckerBoard;
            tex_Board = new Bitmap(Checkers.Properties.Resources.CheckerBoard, new Size(400, 400));

            tex_Player1 = new Bitmap(Checkers.Properties.Resources.Brown, new Size(40, 40));
            tex_Player2 = new Bitmap(Checkers.Properties.Resources.Yellow, new Size(40, 40));
            tex_Player1Highlight = new Bitmap(Checkers.Properties.Resources.BrownHighlight, new Size(40, 40));
            tex_Player2Highlight = new Bitmap(Checkers.Properties.Resources.YellowHighlight, new Size(40, 40));

            tex_Player1King = new Bitmap(Checkers.Properties.Resources.BrownKing, new Size(40, 40));
            tex_Player2King = new Bitmap(Checkers.Properties.Resources.YellowKing, new Size(40, 40));
            tex_Player1HighlightKing = new Bitmap(Checkers.Properties.Resources.BrownHighlightKing, new Size(40, 40));
            tex_Player2HighlightKing = new Bitmap(Checkers.Properties.Resources.YellowHighlightKing, new Size(40, 40));
        }

        //Stops the engine  (the thread)
        public void stop()
        {
            renderThread.Abort();
        }

        // draws each frame. (infinate loop) 
        private void render()
        {
            //Benchmarking info
            int framesRendered = 0;
            long startTime = Environment.TickCount;

            //Objects used for constructing the individual frames of the game
            Bitmap frame = new Bitmap(Game.CANVAS_Width, Game.CANVAS_HEIGHT);
            Graphics frameGraphics = Graphics.FromImage(frame);

            //TextureID[,] textures = Level.Blocks;

            while (true)
            {
                //Background Colour
                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(230, 230, 230)), 0, 0, Game.CANVAS_Width, Game.CANVAS_HEIGHT);

                //frameGraphics.DrawString("Current Player:", new Font("sans", 12), new SolidBrush(Color.Black), 405, 60);
                if (Game.CurrentPlayer == 1) { frameGraphics.DrawImage(tex_Player1, 430, 110); }
                if (Game.CurrentPlayer == 2) { frameGraphics.DrawImage(tex_Player2, 430, 110); }

                frameGraphics.DrawImage(tex_Board, 0, 0);
                //frameGraphics.DrawImage(tex_Player1, 50, 0);
                //frameGraphics.DrawImage(tex_Player2, 50, 50);

                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        //if (!Game.MovePiece) { if (Game.GameGrid[x, y] == 1) { frameGraphics.DrawImage(tex_Player1, x * 50, y * 50 + 5); } } // Draw Player1
                        //else { if (Game.GameGrid[x, y] == 1) { frameGraphics.DrawImage(tex_Player1Highlight, x * 50, y * 50 + 5); } } // Draw Player1
                        //if (!Game.MovePiece) { if (Game.GameGrid[x, y] == 3) { frameGraphics.DrawImage(tex_Player2, x * 50, y * 50 + 5); } } // Draw Player2
                        //else { if (Game.GameGrid[x, y] == 3) { frameGraphics.DrawImage(tex_Player2Highlight, x * 50, y * 50 + 5); } }// Draw Player2

                        //if (!Game.MovePiece) { if (Game.GameGrid[x, y] == 1) { frameGraphics.DrawImage(tex_Player1, x * 50, y * 50 + 5); } }
                        //if (!Game.MovePiece) { if (Game.GameGrid[x, y] == 3) { frameGraphics.DrawImage(tex_Player2, x * 50, y * 50 + 5); } }
                        if (Game.GameGrid[x, y] == 1) { frameGraphics.DrawImage(tex_Player1, x * 50, y * 50 + 5); }
                        if (Game.GameGrid[x, y] == 2) { frameGraphics.DrawImage(tex_Player1King, x * 50, y * 50 + 5); }
                        if (Game.GameGrid[x, y] == 3) { frameGraphics.DrawImage(tex_Player2, x * 50, y * 50 + 5); }
                        if (Game.GameGrid[x, y] == 4) { frameGraphics.DrawImage(tex_Player2King, x * 50, y * 50 + 5); }

                        if (Game.GameGrid[x, y] == Game.ClickPiece && Game.MovePiece)
                        {
                            if (Game.ClickPiece == 1) { frameGraphics.DrawImage(tex_Player1Highlight, Game.SelectedX * 50, Game.SelectedY * 50 + 5); }
                            if (Game.ClickPiece == 2) { frameGraphics.DrawImage(tex_Player1HighlightKing, Game.SelectedX * 50, Game.SelectedY * 50 + 5); }
                            if (Game.ClickPiece == 3) { frameGraphics.DrawImage(tex_Player2Highlight, Game.SelectedX * 50, Game.SelectedY * 50 + 5); }
                            if (Game.ClickPiece == 4) { frameGraphics.DrawImage(tex_Player2HighlightKing, Game.SelectedX * 50, Game.SelectedY * 50 + 5); }
                        }
                        else if (Game.Doubles)
                        {
                            /*if (Game.ClickPiece == 1) { frameGraphics.DrawImage(tex_Player1Highlight, Game.DoubleX * 50, Game.DoubleY * 50 + 5); }
                            if (Game.ClickPiece == 2) { frameGraphics.DrawImage(tex_Player1HighlightKing, Game.DoubleX * 50, Game.DoubleY * 50 + 5); }
                            if (Game.ClickPiece == 3) { frameGraphics.DrawImage(tex_Player2Highlight, Game.DoubleX * 50, Game.DoubleY * 50 + 5); }
                            if (Game.ClickPiece == 4) { frameGraphics.DrawImage(tex_Player2HighlightKing, Game.DoubleX * 50, Game.DoubleY * 50 + 5); }*/
                            if (Game.ClickPiece == 1) { frameGraphics.DrawImage(tex_Player1Highlight, Game.SelectedX * 50, Game.SelectedY * 50 + 5); }
                            if (Game.ClickPiece == 2) { frameGraphics.DrawImage(tex_Player1HighlightKing, Game.SelectedX * 50, Game.SelectedY * 50 + 5); }
                            if (Game.ClickPiece == 3) { frameGraphics.DrawImage(tex_Player2Highlight, Game.SelectedX * 50, Game.SelectedY * 50 + 5); }
                            if (Game.ClickPiece == 4) { frameGraphics.DrawImage(tex_Player2HighlightKing, Game.SelectedX * 50, Game.SelectedY * 50 + 5); }
                            frameGraphics.DrawString("Doubles", new Font("sans", 12), new SolidBrush(Color.Blue), 410, 205 - 50 / 2);
                        }
                        //if (Game.MovePiece && Game.CurrentPlayer == 1) { if (Game.GameGrid[x, y] == 1) { frameGraphics.DrawImage(tex_Player1Highlight, Game.SelectedX * 50, Game.SelectedY * 50 + 5); } }
                        //if (Game.MovePiece && Game.CurrentPlayer == 1) { if (Game.GameGrid[x, y] == 2) { frameGraphics.DrawImage(tex_Player1HighlightKing, Game.SelectedX * 50, Game.SelectedY * 50 + 5); } }
                        //if (Game.MovePiece && Game.CurrentPlayer == 2) { if (Game.GameGrid[x, y] == 3) { frameGraphics.DrawImage(tex_Player2Highlight, Game.SelectedX * 50, Game.SelectedY * 50 + 5); } }
                        //if (Game.MovePiece && Game.CurrentPlayer == 2) { if (Game.GameGrid[x, y] == 4) { frameGraphics.DrawImage(tex_Player2HighlightKing, Game.SelectedX * 50, Game.SelectedY * 50 + 5); } }
                    }
                }
                /*
                for (int x = 0; x < Game.LEVEL_WIDTH; x++)
                {
                    for (int y = 0; y < Game.LEVEL_HEIGHT; y++)
                    {
                        switch (textures[x, y])
                        {
                            case TextureID.air:
                                break;
                            case TextureID.dirt:
                                frameGraphics.DrawImage(tex_dirt, x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH);
                                break;
                        }
                    }
                }*/

                //Draw the frame on the canvas
                if (Game.EndGame)
                {
                    string EndText = Game.Winner + " Wins";
                    EndText = "Yellow" + " Wins";
                    frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), 80, 200 - 50/2, 240, 50);
                    frameGraphics.DrawString((EndText), new Font("sans", 30), new SolidBrush(Color.Black), 85, 205 - 50 / 2);
                }

                drawHandle.DrawImage(frame, 0, 0);

                //Benchmarking
                framesRendered++;
                if ((Environment.TickCount) >= startTime + 1000)
                {
                    //Console.WriteLine("GEngine: {0} fps", framesRendered);
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                }
            }
        }
    }
}
