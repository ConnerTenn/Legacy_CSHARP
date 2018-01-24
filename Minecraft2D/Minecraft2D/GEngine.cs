using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Drawing;

namespace Minecraft2D
{
    class GEngine
    {
        /*-------------------Members-------------------*/
        private Graphics drawHandle;
        private Thread renderThread;

        //private Bitmap tex_steve;
        //private Bitmap tex_dirt;
        //private Bitmap tex_Player;
        private Bitmap tex_box;
        private Bitmap tex_selectbox;
        private Bitmap tex_help;

        public static bool ShowHelp = false;

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
            //tex_steve = Minecraft2D.Properties.Resources.steve;
            //tex_dirt = Minecraft2D.Properties.Resources.tex_dirt;
            //tex_Player = Minecraft2D.Properties.Resources.MarioFront;
            tex_box = Minecraft2D.Properties.Resources.MultiBox3;
            tex_selectbox = Minecraft2D.Properties.Resources.SelectBox2;
            tex_help = Minecraft2D.Properties.Resources.Help;

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
            Bitmap frame = new Bitmap(Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
            Graphics frameGraphics = Graphics.FromImage(frame);
            int[] ItemSelectPos = { 480, 480 + 65, 480 + (65 * 2), 480 + (65 * 3) };
            //TextureID[,] textures = Level1.Blocks;

            while (true)
            {
                //Background Colour
                frameGraphics.FillRectangle(new SolidBrush(Color.Aqua), 0, 0, Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
                frameGraphics.FillRectangle(new SolidBrush(Color.Wheat), 0, 30 * 20, Game.CANVAS_WIDTH, (30 * 50) - Game.CANVAS_HEIGHT);

                //draw bottom frame
                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0,0,0)), 0,0, Game.TILE_SIDE_LENGTH, Game.CANVAS_HEIGHT);
                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), Game.CANVAS_WIDTH - Game.TILE_SIDE_LENGTH, 0, Game.TILE_SIDE_LENGTH, Game.CANVAS_HEIGHT);
                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), 0, Game.CANVAS_HEIGHT-Game.TILE_SIDE_LENGTH, Game.CANVAS_WIDTH, Game.TILE_SIDE_LENGTH);
                //frameGraphics.FillRectangle(new SolidBrush(Color.Black), 480, 610, 50, 50);
                

                for (int x = 0; x < Game.LEVEL_WIDTH; x++)
                {
                    for (int y = 0; y < Game.LEVEL_HEIGHT; y++)
                    {
                        switch (Game.GameGrid[x, y])
                        {
                                //0: Air,  1: Grass,  2: Player,  3: Wall,  4: Gravel  5: Dirt  6: WaterSource  7-9: Water
                            case 0:
                                break;
                            case 1:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 255, 0)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH);
                                break;
                            //case 2:
                            //    frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(255,0,0)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH);
                            //    break;
                            case 3:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH);
                                break;
                            case 4:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(100,100,100)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH);
                                break;
                            case 5:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(130, 90, 20)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH);
                                break;

                            case 6:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 255)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH);
                                break;
                            case 7:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 255)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH + 5, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH - 5);
                                break;
                            case 67:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 255)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH + 5, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH - 5);
                                break;
                            case 8:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 255)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH + 10, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH - 10);
                                break;
                            case 68:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 255)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH + 10, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH - 10);
                                break;
                            case 9:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 255)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH + 15, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH - 15);
                                break;
                            case 69:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 255)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH + 15, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH - 15);
                                break;
                            case 10:
                                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 255)), x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH);
                                break;
                        }
                    }
                }
                frameGraphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0)),Game.PlayerX * Game.TILE_SIDE_LENGTH, Game.PlayerY * Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH, Game.TILE_SIDE_LENGTH);

                frameGraphics.DrawImage(tex_box, 480, 610);
                //frameGraphics.DrawImage(tex_selectbox, 480, 610);
                frameGraphics.DrawImage(tex_selectbox, ItemSelectPos[Game.ItemSelect], 610);
                frameGraphics.DrawString("Press F1 to View Help.", new Font("sans", 15), new SolidBrush(Color.Black), 50, Game.CANVAS_HEIGHT - 60);//new PointF(50, Game.CANVAS_HEIGHT - 60), );

                if (ShowHelp)
                {
                    frameGraphics.DrawImage(tex_help, 300, 150);
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
                            case TextureID.Player:
                                frameGraphics.DrawImage(tex_Player, x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH);
                                break;
                        }
                    }
                }*/

                //Draw the frame on the canvas
                drawHandle.DrawImage(frame, 0, 0);

                //Benchmarking
                framesRendered++;
                if ((Environment.TickCount) >= startTime + 1000)
                {
                    Console.WriteLine("GEngine: {0} fps", framesRendered);
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                }
            }
        }
    }
}
