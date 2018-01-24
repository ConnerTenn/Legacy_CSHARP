using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft2D
{
    class InputHandle
    {
        public static void KeyHandle(string Key)
        {
            if (Key == "W")
            {
                if ((Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 0 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 6 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 7 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 8 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 9 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 10 ) && 
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] != 0)
                {
                    //Game.GameGrid[Game.PlayerX, Game.PlayerY] = 0;
                    //Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] = 2;
                    Game.PlayerY -= 1;
                    //Level1.startTime = Environment.TickCount;
                }
            }
            if (Key == "S")
            {
                if (Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 0 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 6 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 7 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 8 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 9 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 10)
                {
                    //Game.GameGrid[Game.PlayerX, Game.PlayerY] = 0;
                    //Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] = 2;
                    Game.PlayerY += 1;
                    Level1.startTime = Environment.TickCount;
                }
            }
            if (Key == "A")
            {
                if (Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 0 ||
                        Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 6 ||
                        Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 7 ||
                        Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 8 ||
                        Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 9 ||
                        Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 10 )
                {
                    //Game.GameGrid[Game.PlayerX, Game.PlayerY] = 0;
                    //Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] = 2;
                    Game.PlayerX -= 1;
                }
            }
            if (Key == "D")
            {
                if (Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 0 ||
                        Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 6 ||
                        Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 7 ||
                        Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 8 ||
                        Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 9 ||
                        Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 10 )
                {
                    //Game.GameGrid[Game.PlayerX, Game.PlayerY] = 0;
                    //Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] = 2;
                    Game.PlayerX += 1;
                }
            }
            int Block = 1;
            if (Game.ItemSelect == 0) { Block = 1; }
            else if (Game.ItemSelect == 1) { Block = 4; }
            else if (Game.ItemSelect == 2) { Block = 5; }
            else if (Game.ItemSelect == 3) { Block = 6; }
            if (Key == "I")
            {
                if (Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 3) { }
                else if (Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 0 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 6 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 7 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 8 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 9 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] == 10)
                {
                    Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] = Block;
                }
                else
                {
                    Game.GameGrid[Game.PlayerX, Game.PlayerY - 1] = 0;
                }
            }
            if (Key == "K")
            {
                if (Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 3) { }
                else if (Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 0 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 6 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 7 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 8 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 9 ||
                        Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] == 10)
                {
                    Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] = Block;
                }
                else
                {
                    Game.GameGrid[Game.PlayerX, Game.PlayerY + 1] = 0;
                }
            }
            if (Key == "J")
            {
                if (Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 3) { }
                else if (Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 0 ||
                        Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 6 ||
                        Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 7 ||
                        Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 8 ||
                        Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 9 ||
                        Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] == 10)
                {
                    Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] = Block;
                }
                else
                {
                    Game.GameGrid[Game.PlayerX - 1, Game.PlayerY] = 0;
                }
            }
            if (Key == "L")
            {
                if (Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 3) { }
                else if (Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 0 ||
                        Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 6 ||
                        Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 7 ||
                        Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 8 ||
                        Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 9 ||
                        Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] == 10)
                {
                    Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] = Block;
                }
                else
                {
                    Game.GameGrid[Game.PlayerX + 1, Game.PlayerY] = 0;
                }
            }
            if (Key == "D1") { Game.ItemSelect = 0; }
            if (Key == "D2") { Game.ItemSelect = 1; }
            if (Key == "D3") { Game.ItemSelect = 2; }
            if (Key == "D4") { Game.ItemSelect = 3; }

            if (Key == "F1")
            {
                switch (GEngine.ShowHelp)
                {
                    case true: GEngine.ShowHelp = false; break;
                    case false: GEngine.ShowHelp = true; break;
                }
            }
            if (Key == "Escape" && GEngine.ShowHelp) { GEngine.ShowHelp = false; }
        }
    }
}
