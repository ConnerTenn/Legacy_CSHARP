using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Timmer
{
    class Game
    {
        /*-------------------Constants-------------------*/
        public const int CANVAS_Width = 1200;
        public const int CANVAS_HEIGHT = 700;
        public const int LEVEL_WIDTH = 24;
        public const int LEVEL_HEIGHT = 14;
        public const int TILE_SIDE_LENGTH = 50;

        /*-------------------Members-------------------*/
        private GEngine gEngine;

        //Load the level
        public void loadLevel()
        {
            Level.initLevel();
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
        }
    }

    public enum TextureID
    {
        air,
        dirt
    }
}
