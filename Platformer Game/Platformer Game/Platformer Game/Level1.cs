using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platformer_Game
{
    class Level1
    {
        public static int a = 0;
        //public static List<object> ObjectList;
        public static bool Play = true;
        public static Players Player1;
        public static Rectangle Player1Rect;
        public static Walls Wall1;
        public static Rectangle Wall1Rect;

        public static void Startup()
        {
            Console.WriteLine("HI1");

            Player1 = new Players(100, 100, 110, 110);
            Player1Rect = new Rectangle((int)Player1.PosX, (int)Player1.PosY, (int)Player1.Width, (int)Player1.Height);
            Form1.graphics.DrawRectangle(Form1.myPen, Player1Rect);

            Wall1 = new Walls(0, 890, 500, 900);
            Wall1Rect = new Rectangle((int)Wall1.PosX, (int)Wall1.PosY, (int)Wall1.Width, (int)Wall1.Height);
            Form1.graphics.DrawRectangle(Form1.myPen, Wall1Rect);

            Level1.LevelLoop();
        }

        public static void LevelLoop()
        {
            while (Play)
            {
                a += 1;
                //Console.WriteLine("HI2");
                Refresh();
                //Form1.Canvas.Refresh();
                if (a == 20)
                {
                    Play = false;
                }
            }
        }

        public static void ShutDown()
        {

        }

        public static void Refresh()
        {
            //Console.WriteLine("HI3");
            //Players Player1 = new Players(100, 100, 110, 110);
            //Rectangle Player1Rect = new Rectangle((int)Player1.PosX, (int)Player1.PosY, (int)Player1.Width, (int)Player1.Height);
            Form1.graphics.DrawRectangle(Form1.myPen, Player1Rect);

            //Walls Wall1 = new Walls(0, 890, 500, 900);
            //Rectangle Wall1Rect = new Rectangle((int)Wall1.PosX, (int)Wall1.PosY, (int)Wall1.Width, (int)Wall1.Height);
            Form1.graphics.DrawRectangle(Form1.myPen, Wall1Rect);
        }
    }
}
