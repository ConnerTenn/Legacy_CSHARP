using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Test
{
    class Program
    {
        static void Main()
        {
            ball b = new ball(1,2,3,4,5,6);
            b.init(3, 4);

            b.print("hi");
            b.print((b.Value).ToString());
            b.print((b.Value2).ToString());
            b.print(b.ToString());
            Console.ReadLine();
        }
    }
}
