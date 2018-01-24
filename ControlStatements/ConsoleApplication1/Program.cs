using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStatements
{
    class Program
    {
        static void Main()
        {
            string[] ABC = { "A", "B", "C" };
            string[] DEF = { "D", "E", "F" };
            Console.WriteLine("ABC:{0}{1}{2}, DEF:{3}{4}{5}", ABC[0], ABC[1], ABC[2], DEF[0], DEF[1], DEF[2]);
            Console.ReadLine();
        }
    }
}