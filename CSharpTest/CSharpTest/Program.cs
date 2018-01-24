using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("A={0}", A());
            Class1 classa = new Class1();
            Console.WriteLine("classa = {0}", classa.a);
            Console.ReadLine();
        }
        static int A()
        {
            return 5;
        }
    }
}
