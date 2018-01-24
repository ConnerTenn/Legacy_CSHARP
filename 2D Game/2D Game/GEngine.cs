using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Drawing;

namespace _2D_Game
{
    class GEngine
    {
        /*-------------------Members-------------------*/
        private Graphics drawHandle;
        private Thread renderThread;

        private Bitmap tex_steve;
        private Bitmap tex_dirt;

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
            tex_steve = _2D_Game.Properties.Resources.steve;
            tex_dirt = _2D_Game.Properties.Resources.tex_dirt;
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

            TextureID[,] textures = Level.Blocks;

            while (true)
            {
                //Background Colour
                frameGraphics.FillRectangle(new SolidBrush(Color.Aqua), 0, 0, Game.CANVAS_Width, Game.CANVAS_HEIGHT );

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
                }
                
                //Draw the frame on the canvas
                drawHandle.DrawImage(frame, 0, 0);

                //Benchmarking
                framesRendered++;
                if ((Environment.TickCount) >= startTime+1000)
                {
                    Console.WriteLine("GEngine: {0} fps", framesRendered);
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                }
            }
        }
    }
}
