using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Multithreading_Test1
{
    class Program
    {
        private static System.Diagnostics.Stopwatch watch;
        public static float SecondsCount = 0;
        public static float ElapsedSeconds = 0;

        static void Main()
        {
            //Thread2 oThread2 = new Thread2();
            Thread oThread2 = new Thread(new ThreadStart(Thread2.main));
            oThread2.Start();

            watch = System.Diagnostics.Stopwatch.StartNew();

            
            while (Thread2.Play)
            {
                SecondsCount += (float)watch.ElapsedTicks / (System.Diagnostics.Stopwatch.Frequency);

                if (SecondsCount > 1)
                {
                    ElapsedSeconds += SecondsCount;
                    SecondsCount = 0;
                    Console.WriteLine("Elapsed Time = {0}", ElapsedSeconds);
                }
            }

            oThread2.Abort();

            Console.WriteLine();
            Console.WriteLine("Press [Enter] To Exit.");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
