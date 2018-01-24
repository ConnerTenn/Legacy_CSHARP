using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Minecraft2D
{
    class Level1
    {
        /*private static TextureID[,] blocks = new TextureID[Game.LEVEL_WIDTH, Game.LEVEL_HEIGHT];

        public static TextureID[,] Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }*/
        public static long startTime = 0;
        public static long WaterClock = 0;
        public static bool OnGround = true;

        public static void stop()
        {
            Game.LevelThread.Abort();
        }

        public static void initLevel()
        {
            int gencycle = 4;
            int waterlevel = 6;
            int gencycleswitch = 1;
            Random Rnd = new Random();
            int rnd;
            int rnd2;
            for (int x = 0; x < Game.LEVEL_WIDTH; x++)
            {
                rnd = Rnd.Next(-1, 3);

                if (gencycle <= 6) { gencycleswitch = 1; }
                if (gencycle >= 12) { gencycleswitch = 2; }
                if (gencycleswitch == 1) { gencycle += rnd; } else { gencycle -= rnd; }
                if (gencycle < 2) { gencycle = 2; }

                for (int y = 0; y < Game.LEVEL_HEIGHT; y++)
                {
                    rnd2 = Rnd.Next(0, 10);

                    if (y == Game.LEVEL_HEIGHT - gencycle) //Create Grass
                    {
                        if (x == Game.PlayerX) { Game.PlayerY = y - 1; }
                        Game.GameGrid[x, y] = 1;
                    }
                    else if (y > Game.LEVEL_HEIGHT - gencycle) // Create Dirt 
                    {
                        Game.GameGrid[x, y] = 5;
                    }
                    else
                    {
                        Game.GameGrid[x, y] = 0;  // Create Air
                    }
                    if (y > Game.LEVEL_HEIGHT - (gencycle) && rnd2 == 5) // Create Gravel
                    {
                        Game.GameGrid[x, y] = 4;
                    }
                    else if (y > Game.LEVEL_HEIGHT - waterlevel && Game.GameGrid[x, y] == 0)  // Create Water
                    {
                        Game.GameGrid[x, y] = 6;
                    }

                    if (y == Game.LEVEL_HEIGHT-1) { Game.GameGrid[x, y] = 3; }
                    if (y == 0) { Game.GameGrid[x, y] = 3; }
                    if (x == Game.LEVEL_WIDTH-1) { Game.GameGrid[x, y] = 3; }
                    if (x == 0) { Game.GameGrid[x, y] = 3; }
                }
            }
            //Game.GameGrid[Game.PlayerX, Game.PlayerY] = 2;

            Level1.MainLoop();
            /*
            for (int x = 0; x < Game.LEVEL_WIDTH; x++)
            {
                for (int y = 0; y < Game.LEVEL_HEIGHT; y++)
                {
                    if (y >= 11)
                    {
                        blocks[x, y] = TextureID.dirt;
                    }
                    else if (y == 9 && x == 10)
                    {
                        blocks[x, y] = TextureID.Player;
                    }
                    else if (y == 1 && x == 1)
                    {
                        blocks[x, y] = TextureID.dirt;
                    }
                    else if (y == 0 && x == 2)
                    {
                        blocks[x, y] = TextureID.dirt;
                    }
                    else if (y == 2 && x == 0)
                    {
                        blocks[x, y] = TextureID.dirt;
                    }
                    else
                    {
                        blocks[x, y] = TextureID.air;
                    }
                }
            }
            */
        }

        public static void MainLoop()
        {
            bool Play = true;

            while (Play)
            {
                //WaterClock = Environment.TickCount;
                if (Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 0)
                {
                    if (OnGround) { Level1.startTime = Environment.TickCount; }
                    OnGround = false;
                    
                    if ((Environment.TickCount) >= startTime + 500)
                    {
                        if (Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 0)
                        {
                            //Game.GameGrid[Game.PlayerX, Game.PlayerY] = 0;
                            //Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] = 2;
                            Game.PlayerY += 1;
                        }
                        startTime = Environment.TickCount;
                    }
                }
                else
                {
                    OnGround = true;
                }
                
                //Thread.Sleep(0);

                if ((Environment.TickCount) >= WaterClock + 300)
                {
                    Water();
                    WaterClock = Environment.TickCount;
                }
            }
        }//End MainLoop

        public static void Water()
        {
            for (int x = 0; x < Game.LEVEL_WIDTH; x++)
            {
                //for (int y = 0; y < Game.LEVEL_HEIGHT; y++)
                for (int y = Game.LEVEL_HEIGHT-1; y > -1;  y--)
                {
                    if (Game.GameGrid[x, y] == 6)
                    {
                        if (Game.GameGrid[x + 1, y] == 0) { Game.GameGrid[x + 1, y] = 67; }
                        if (Game.GameGrid[x - 1, y] == 0) { Game.GameGrid[x - 1, y] = 67; }
                        if (Game.GameGrid[x, y + 1] == 0) { Game.GameGrid[x, y + 1] = 70; }
                        //if (Game.GameGrid[x, y - 1] == 0) { Game.GameGrid[x - 1, y] = 67; }
                    }
                    if (Game.GameGrid[x, y] == 7)
                    {
                        if (Game.GameGrid[x, y + 1] != 0 && Game.GameGrid[x, y + 1] != 6 && Game.GameGrid[x, y + 1] != 7 && Game.GameGrid[x, y + 1] != 8 && Game.GameGrid[x, y + 1] != 9 && Game.GameGrid[x, y + 1] != 10 && Game.GameGrid[x + 1, y] == 0) { Game.GameGrid[x + 1, y] = 68; }
                        if (Game.GameGrid[x, y + 1] != 0 && Game.GameGrid[x, y + 1] != 6 && Game.GameGrid[x, y + 1] != 7 && Game.GameGrid[x, y + 1] != 8 && Game.GameGrid[x, y + 1] != 9 && Game.GameGrid[x, y + 1] != 10 && Game.GameGrid[x - 1, y] == 0) { Game.GameGrid[x - 1, y] = 68; }
                        if (Game.GameGrid[x, y + 1] == 0 || Game.GameGrid[x, y + 1] == 7 || Game.GameGrid[x, y + 1] == 8 || Game.GameGrid[x, y + 1] == 9) { Game.GameGrid[x, y + 1] = 70; }
                        //if (Game.GameGrid[x, y - 1] == 0) { Game.GameGrid[x - 1, y] = 67; }
                        //if (Game.GameGrid[x - 1, y] != 6 && Game.GameGrid[x + 1, y] != 6 && Game.GameGrid[x - 1, y] != 10 && Game.GameGrid[x + 1, y] != 10) { Game.GameGrid[x, y] = 60; }
                        //if (Game.GameGrid[x - 1, y] == 0 && (Game.GameGrid[x + 1, y] == 0 || Game.GameGrid[x - 1, y] == 2 && Game.GameGrid[x + 1, y] == 2 || Game.GameGrid[x - 1, y] == 1 && Game.GameGrid[x + 1, y] == 1 || Game.GameGrid[x - 1, y] == 3 && Game.GameGrid[x + 1, y] == 3 || Game.GameGrid[x - 1, y] == 4 && Game.GameGrid[x + 1, y] == 4 || Game.GameGrid[x - 1, y] == 5 && Game.GameGrid[x + 1, y] == 5)) { Game.GameGrid[x, y] = 60; }
                        if (Game.GameGrid[x - 1, y] == 6 || Game.GameGrid[x + 1, y] == 6 || Game.GameGrid[x - 1, y] == 10 || Game.GameGrid[x + 1, y] == 10) { } else { Game.GameGrid[x, y] = 60; }
                    }
                    if (Game.GameGrid[x, y] == 8)//
                    {
                        if (Game.GameGrid[x, y + 1] != 0 && Game.GameGrid[x, y + 1] != 6 && Game.GameGrid[x, y + 1] != 7 && Game.GameGrid[x, y + 1] != 8 && Game.GameGrid[x, y + 1] != 9 && Game.GameGrid[x, y + 1] != 10 && Game.GameGrid[x + 1, y] == 0) { Game.GameGrid[x + 1, y] = 69; }
                        if (Game.GameGrid[x, y + 1] != 0 && Game.GameGrid[x, y + 1] != 6 && Game.GameGrid[x, y + 1] != 7 && Game.GameGrid[x, y + 1] != 8 && Game.GameGrid[x, y + 1] != 9 && Game.GameGrid[x, y + 1] != 10 && Game.GameGrid[x - 1, y] == 0) { Game.GameGrid[x - 1, y] = 69; }
                        if (Game.GameGrid[x, y + 1] == 0 || Game.GameGrid[x, y + 1] == 7 || Game.GameGrid[x, y + 1] == 8 || Game.GameGrid[x, y + 1] == 9) { Game.GameGrid[x, y + 1] = 70; }
                        //if (Game.GameGrid[x, y - 1] == 0) { Game.GameGrid[x - 1, y] = 67; }
                        //if (Game.GameGrid[x - 1, y] != 6 && Game.GameGrid[x + 1, y] != 6 && Game.GameGrid[x - 1, y] != 7 && Game.GameGrid[x + 1, y] != 7 && Game.GameGrid[x - 1, y] != 10 && Game.GameGrid[x + 1, y] != 10) { Game.GameGrid[x, y] = 60; }
                        //if (Game.GameGrid[x - 1, y] == 0 && (Game.GameGrid[x + 1, y] == 0 || Game.GameGrid[x - 1, y] == 2 && Game.GameGrid[x + 1, y] == 2 || Game.GameGrid[x - 1, y] == 1 && Game.GameGrid[x + 1, y] == 1 || Game.GameGrid[x - 1, y] == 3 && Game.GameGrid[x + 1, y] == 3 || Game.GameGrid[x - 1, y] == 4 && Game.GameGrid[x + 1, y] == 4 || Game.GameGrid[x - 1, y] == 5 && Game.GameGrid[x + 1, y] == 5)) { Game.GameGrid[x, y] = 60; }
                        if (Game.GameGrid[x - 1, y] == 7 || Game.GameGrid[x + 1, y] == 7) { } else { Game.GameGrid[x, y] = 60; }
                    }
                    if (Game.GameGrid[x, y] == 9)//
                    {
                        //if (Game.GameGrid[x, y + 1] != 0 && Game.GameGrid[x, y + 1] != 6 && Game.GameGrid[x, y + 1] != 7 && Game.GameGrid[x, y + 1] != 8 && Game.GameGrid[x, y + 1] != 9 && Game.GameGrid[x, y + 1] != 10 && Game.GameGrid[x + 1, y] == 0) { Game.GameGrid[x, y + 1] = 70; }
                        //if (Game.GameGrid[x, y + 1] != 0 && Game.GameGrid[x, y + 1] != 6 && Game.GameGrid[x, y + 1] != 7 && Game.GameGrid[x, y + 1] != 8 && Game.GameGrid[x, y + 1] != 9 && Game.GameGrid[x, y + 1] != 10 && Game.GameGrid[x - 1, y] == 0) { Game.GameGrid[x, y - 1] = 70; }
                        if (Game.GameGrid[x, y + 1] == 0) { Game.GameGrid[x, y + 1] = 70; }
                        //if (Game.GameGrid[x - 1, y] != 6 && Game.GameGrid[x + 1, y] != 6 && Game.GameGrid[x - 1, y] != 7 && Game.GameGrid[x + 1, y] != 7 && Game.GameGrid[x - 1, y] != 8 && Game.GameGrid[x + 1, y] != 8 && Game.GameGrid[x - 1, y] != 10 && Game.GameGrid[x + 1, y] != 10) { Game.GameGrid[x, y] = 60; }
                        //if (Game.GameGrid[x - 1, y] == 0 && (Game.GameGrid[x + 1, y] == 0 || Game.GameGrid[x - 1, y] == 2 && Game.GameGrid[x + 1, y] == 2 || Game.GameGrid[x - 1, y] == 1 && Game.GameGrid[x + 1, y] == 1 || Game.GameGrid[x - 1, y] == 3 && Game.GameGrid[x + 1, y] == 3 || Game.GameGrid[x - 1, y] == 4 && Game.GameGrid[x + 1, y] == 4 || Game.GameGrid[x - 1, y] == 5 && Game.GameGrid[x + 1, y] == 5)) { Game.GameGrid[x, y] = 60; }
                        if (Game.GameGrid[x - 1, y] == 8 || Game.GameGrid[x + 1, y] == 8) { } else { Game.GameGrid[x, y] = 60; }
                    }
                    if (Game.GameGrid[x, y] == 10)
                    {
                        if (Game.GameGrid[x, y + 1] != 0 && Game.GameGrid[x, y + 1] != 6 && Game.GameGrid[x, y + 1] != 7 && Game.GameGrid[x, y + 1] != 8 && Game.GameGrid[x, y + 1] != 9 && Game.GameGrid[x, y + 1] != 10 && Game.GameGrid[x + 1, y] == 0) { Game.GameGrid[x + 1, y] = 67; }
                        if (Game.GameGrid[x, y + 1] != 0 && Game.GameGrid[x, y + 1] != 6 && Game.GameGrid[x, y + 1] != 7 && Game.GameGrid[x, y + 1] != 8 && Game.GameGrid[x, y + 1] != 9 && Game.GameGrid[x, y + 1] != 10 && Game.GameGrid[x - 1, y] == 0) { Game.GameGrid[x - 1, y] = 67; }
                        if (Game.GameGrid[x, y + 1] == 0 || Game.GameGrid[x, y + 1] == 7 || Game.GameGrid[x, y + 1] == 8 || Game.GameGrid[x, y + 1] == 9) { Game.GameGrid[x, y + 1] = 70; }
                        //if (Game.GameGrid[x, y - 1] == 0) { Game.GameGrid[x - 1, y] = 67; }
                        //if (Game.GameGrid[x, y - 1] != 6 && Game.GameGrid[x, y - 1] != 7 && Game.GameGrid[x, y - 1] != 8 && Game.GameGrid[x, y - 1] != 9 && Game.GameGrid[x, y - 1] != 10 && Game.GameGrid[x - 1, y] != 10 && Game.GameGrid[x + 1, y] != 10) { Game.GameGrid[x, y] = 60; }
                        //if (Game.GameGrid[x, y - 1] == 0 || Game.GameGrid[x, y - 1] == 1 || Game.GameGrid[x, y - 1] == 2 || Game.GameGrid[x, y - 1] == 3 || Game.GameGrid[x, y - 1] == 4 || Game.GameGrid[x, y - 1] == 5) { Game.GameGrid[x, y] = 60; }
                        if (Game.GameGrid[x, y - 1] == 6 || Game.GameGrid[x, y - 1] == 7 || Game.GameGrid[x, y - 1] == 8 || Game.GameGrid[x, y - 1] == 9 || Game.GameGrid[x, y - 1] == 10) { } else { Game.GameGrid[x, y] = 60; }
                    }


                    /*for (int a = 7; a < 10; a++)
                    {
                        if (Game.GameGrid[x, y] == a)
                        {
                            if (Game.GameGrid[x + 1, y] == 0) { Game.GameGrid[x, y + 1] = (60 + (a + 1)); }
                            if (Game.GameGrid[x - 1, y] == 0) { Game.GameGrid[x, y - 1] = (60 + (a + 1)); }
                            if (Game.GameGrid[x, y + 1] == 0) { Game.GameGrid[x + 1, y] = (60 + (a + 1)); }
                            //if (Game.GameGrid[x, y - 1] == 0) { Game.GameGrid[x - 1, y] = (60 + (a + 1)); }/**/
                    /*
                    if ((Game.GameGrid[x + 1, y] < a) && (Game.GameGrid[x + 1, y] > 6)) { }
                    else
                    {
                        if ((Game.GameGrid[x - 1, y] < a) && (Game.GameGrid[x - 1, y] > 6)) { }
                        else
                        {
                            if ((Game.GameGrid[x, y + 1] < a) && (Game.GameGrid[x, y + 1] > 6)) { }
                            else
                            {
                                if ((Game.GameGrid[x, y - 1] < a) && (Game.GameGrid[x, y - 1] > 6)) { }
                                else { Game.GameGrid[x, y] = 0; }
                            }
                        }
                    }*/
                    //}
                    //}
                }
            }
            for (int x = 0; x < Game.LEVEL_WIDTH; x++)
            {
                for (int y = 0; y < Game.LEVEL_HEIGHT; y++)
                {
                    if (Game.GameGrid[x, y] >= 60) { Game.GameGrid[x, y] = Game.GameGrid[x, y] - 60; }
                }
            }
        }
    }
}
