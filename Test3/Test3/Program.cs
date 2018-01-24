using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] List = { "a", "b", "c", "d", "e", "f", "g" };
            foreach(string Item in List)
            {
                Console.WriteLine("Item:{0}", Item);
            }
            Console.ReadLine();
        }
    }
}
