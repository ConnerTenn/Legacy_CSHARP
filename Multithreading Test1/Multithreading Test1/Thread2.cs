using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading_Test1
{
    class Thread2
    {
        public static bool Play = true;

        public static void main()
        {
            while (true)
            {
                if (Program.ElapsedSeconds>10)
                {
                    Console.WriteLine("Ending");
                    Play = false;
                } 
            }
        }
    }
}
