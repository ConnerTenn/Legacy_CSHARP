using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    public static void Main()
    {
        Program program = new Program();
        Class1 class1 = new Class1();
        int a = program.Num();
        int b = class1.Num2(1);
        Console.WriteLine("Num={0}, Num2={1}", a, b);
        Console.ReadLine();
        Console.WriteLine();
    }

    int Num()
    {
        //Console.WriteLine("Hi2");
        return 5;
    }
}

