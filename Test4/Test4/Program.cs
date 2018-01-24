using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4
{
    class Main_Class
    {
        static void Main()
        {
            Main_Class Main_Class = new Main_Class();
            int Num = Main_Class.Get_Num(5);
            Console.WriteLine("Ans:{0}", Num);
            Console.ReadLine();
            Console.WriteLine();
        }

        int Get_Num(int args)
        {
            return args * 5;
        }
    }
}
