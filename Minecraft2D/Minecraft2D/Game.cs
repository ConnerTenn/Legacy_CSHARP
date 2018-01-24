using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Drawing;

namespace Minecraft2D
{
    class Game
    {
        /*-------------------Constants-------------------*/
        public const int CANVAS_WIDTH = 1200;
        public const int CANVAS_HEIGHT = 700;
        public const int LEVEL_WIDTH = 60;
        public const int LEVEL_HEIGHT = 30; //35
        public const int TILE_SIDE_LENGTH = 20;

        /*-------------------Members-------------------*/
        private GEngine gEngine;
        public static int[,] GameGrid = new int[LEVEL_WIDTH, LEVEL_HEIGHT];
        public static int ItemSelect = 0;

        public static Thread LevelThread;
        public static int PlayerX = 10;
        public static int PlayerY = Game.LEVEL_HEIGHT - 7;

        //Load the level
        public void loadLevel()
        {
            //Level1.initLevel();
            LevelThread = new Thread(new ThreadStart(Level1.initLevel));
            LevelThread.Start();
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
            Level1.stop();
        }
    }

    /*public enum TextureID
    {
        air,
        dirt,
        Player
    }*/
}
