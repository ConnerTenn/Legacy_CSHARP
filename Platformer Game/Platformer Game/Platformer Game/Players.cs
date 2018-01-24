using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer_Game
{
    class Players:Objects
    {
        public  float JumpSpeed;
        public  float VelosityY;
        public  float VelosityX;
        public  float FallSpeed;
        public  string State;
        public  bool StateLift;
        public  float PosX;
        public  float PosY;
        public  float PosX2;
        public  float PosY2;
        public  float Width;
        public  float Height;
        public  float CoordsX1;
        public  float CoordsY1;
        public  float CoordsX2;
        public  float CoordsY2;
        public  List<float> Coords = new List<float>();
        public static List<Players> PlayerList = new List<Players> { };

        public  Players(float X1, float Y1, float X2, float Y2)
        {
            JumpSpeed= (float)-1.5;
            VelosityY = 0;
            VelosityX = 0;
            FallSpeed = 0;
            State = "Standing";
            StateLift = false;
            PosX = X1;
            PosY = Y1;
            PosX2 = X2;
            PosY2 = Y2;
            Width = PosX2 - PosX;
            Height = PosY2 - PosY;
            Coords.Add(CoordsX1);
            Coords.Add(CoordsY1);
            Coords.Add(CoordsX2);
            Coords.Add(CoordsY2);
        }

        public bool OnGround()
        {
            foreach (Players thing in Players.PlayerList)
            {
                if (thing == this)
                {
                }
                else
                {
                    if (CollideTop(this.Coords, thing.Coords))
                    {
                        return true;
                    }
                }
            }
            foreach (Walls thing2 in Walls.WallList)
            {
                if (CollideTop(this.Coords, thing2.Coords))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HitTop()
        {
            foreach (Players thing in Players.PlayerList)
            {
                if (thing == this)
                {
                }
                else
                {
                    if (CollideBottom(this.Coords, thing.Coords))
                    {
                        return true;
                    }
                }
            }
            foreach (Walls thing2 in Walls.WallList)
            {
                if (CollideBottom(this.Coords, thing2.Coords))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HitSideRight()
        {
            foreach (Players thing in Players.PlayerList)
            {
                if (thing == this)
                {
                }
                else
                {
                    if (CollideRight(this.Coords, thing.Coords))
                    {
                        return true;
                    }
                }
            }
            foreach (Walls thing2 in Walls.WallList)
            {
                if (CollideRight(this.Coords, thing2.Coords))
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool HitSideLeft()
        {
            foreach (Players thing in Players.PlayerList)
            {
                if (thing == this)
                {
                }
                else
                {
                    if (CollideLeft(this.Coords, thing.Coords))
                    {
                        return true;
                    }
                }
            }
            foreach (Walls thing2 in Walls.WallList)
            {
                if (CollideLeft(this.Coords, thing2.Coords))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
