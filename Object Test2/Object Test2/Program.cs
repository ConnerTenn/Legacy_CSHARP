using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Test2
{
    class Program
    {
        static void Main()
        {
            ObjectClass Object1 = new ObjectClass(73, 96, 27, 50, 12, 42);
            ObjectClass Object2 = new ObjectClass(88, 13, 56, 32, 60, 58);
            ObjectClass Object3 = new ObjectClass(13, 47, 87, 39, 75, 47);

            Console.WriteLine(Object1.Value1);
            Object1.Func1();

            Console.WriteLine();

            Console.WriteLine(Object2.Value1);
            Object1.Func1();

            Console.Write("Press Enter To Exit.");
            Console.ReadLine();
        }
    }

    class ObjectClass
    {
        public int Value1;
        public int Value2;
        public int Value3;
        public int Value4;
        public int Value5;
        public int Value6;

        public ObjectClass(int in1, int in2, int in3, int in4, int in5, int in6)
        {
            Value1 = in1;
            Value2 = in2;
            Value3 = in3;
            Value4 = in4;
            Value5 = in5;
            Value6 = in6;
        }
        public void Func1()
        {
            Console.WriteLine(Value5);
        }
    }
}
