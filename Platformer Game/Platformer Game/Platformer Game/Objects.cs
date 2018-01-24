using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer_Game
{
    class Objects
    {

        public bool WithinX(List<float> Cords1, List<float> Cords2)
        {
            float co1x1 = Cords1[0];
            float co1x2 = Cords1[2];
            float co2x1 = Cords2[0];
            float co2x2 = Cords2[2];

            if (((co1x1 >= co2x1) && (co1x1 <= co2x2))
               || ((co1x2 >= co2x1) && (co1x2 <= co2x2)) 
               || ((co2x1 >= co1x1) && (co2x1 <= co1x2)) 
               || ((co2x2 >= co1x1) && (co2x2 <= co1x2)))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool WithinY(List<float> Cords1, List<float> Cords2)
         {
            float co1y1=Cords1[1];
            float co1y2=Cords1[3];
            float co2y1=Cords2[1];
            float co2y2=Cords2[3];

            if (((co1y1 > co2y1) && (co1y1 < co2y2)) 
               || ((co1y2 > co2y1) && (co1y2 < co2y2)) 
               || ((co2y1 > co1y1) && (co2y1 < co1y2)) 
               || ((co2y2 > co1y1) && (co2y2 < co1y2)))
            {
                return true;
            }
            else
            {
                return false;
            }
         }

        public bool CollideRight(List<float> Cords1, List<float> Cords2)
        {
            float co1x1=Cords1[0]-2;
            float co1x2=Cords1[2];
            float co2x1=Cords2[0];
            float co2x2=Cords2[2];
            if (WithinY(Cords1, Cords2))
            {
                if (co1x1 <= co2x2 && co1x1 >=co2x1)
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool CollideLeft(List<float> Cords1, List<float> Cords2)
        {
            float co1x1=Cords1[0];
            float co1x2=Cords1[2]+2;
            float co2x1=Cords2[0];
            float co2x2=Cords2[2];
            if (WithinY(Cords1, Cords2))
            {
                if (co1x2 >= co2x1 && co1x2 <=co2x2)
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool CollideBottom(List<float> Cords1, List<float> Cords2)
        {
            float co1y1=Cords1[1]-4;
            float co1y2=Cords1[3];
            float co2y1=Cords2[1];
            float co2y2=Cords2[3];
            if (WithinX(Cords1, Cords2))
            {
                if (co1y1 <= co2y2 && co1y1 >=co2y1)
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool CollideTop(List<float> Cords1, List<float> Cords2)
        {
            float co1y1=Cords1[1];
            float co1y2=Cords1[3]+4;
            float co2y1=Cords2[1];
            float co2y2=Cords2[3];
            if (WithinX(Cords1, Cords2))
            {
                if (co1y2 <= co2y2 && co1y2 >= co2y1)
                {
                    return true;
                }
            }
            return false;
        }
        /*
        public bool OnGround()
        {
            foreach (Object thing in Objects.ObjectList)
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
                return false;
            }
        }

        public bool HitTop()
    {
        foreach (Object thing in Objects.ObjectList)
        {
            if (thing==this)
            {
            }
            else
            {
                if (CollideBottom(this.Coords, Object.Coords))
                {
                    return true;
                }
            }
        return false;
    }

    def HitSideRight(self):
        for Object in Main.ObjectList:
            if Object==self:
                pass
            else:
                if self.CollideRight(self.Coords, Object.Coords):
                    return True
        if self==Main.player2:
            for Object in Main.ThruWallList:
                if Object==self:
                    pass
                else:
                    if self.CollideRight(self.Coords, Object.Coords):
                        return True            
        return False

    def HitSideLeft(self):
        for Object in Main.ObjectList:
            if Object==self:
                pass
            else:
                if self.CollideLeft(self.Coords, Object.Coords):
                    return True
        if self==Main.player2:
            for Object in Main.ThruWallList:
                if Object==self:
                    pass
                else:
                    if self.CollideLeft(self.Coords, Object.Coords):
                        return True
        return False
    }*/
    }
}
