using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer_Game
{
    class Walls:Objects
    {
        public float PosX;
        public float PosY;
        public float PosX2;
        public float PosY2;
        public float Width;
        public float Height;
        public float CoordsX1;
        public float CoordsY1;
        public float CoordsX2;
        public float CoordsY2;
        public List<float> Coords = new List<float>{1,2,3,4};
        public static List<Walls> WallList = new List<Walls> { };
        

        public Walls(float X1, float Y1, float X2, float Y2)
        {
            PosX=X1;
            PosY=Y1;
            PosX2=X2;
            PosY2 = Y2;
            Width = PosX2 - PosX;
            Height = PosY2 - PosY;
            CoordsX1=PosX;
            CoordsY1=PosY;
            CoordsX2=PosX2;
            CoordsY2=PosY2;
            Coords.Add(CoordsX1);
            Coords.Add(CoordsY1);
            Coords.Add(CoordsX2);
            Coords.Add(CoordsY2);
            //Coords = (CoordsX1, CoordsY1, CoordsX2, CoordsY2);
            //Coords = [CoordsX1, CoordsY1, CoordsX2, CoordsY2];
            //Coords={CoordsX1, CoordsY1, CoordsX2, CoordsY2};
        }
    }
}
