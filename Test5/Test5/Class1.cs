using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Class1
{
    public int Num2(int num)
    {
        /*List<string> List1 = new List<string>();
        List1.Add("Hello");
        List1.Add("Goodbye");
        List<string> List2 = new List<string>();
        List2.Add("Good_Morning");
        List2.Add("Good_Night");
        var List3 = List1.Concat(List2);
        List3.ToList();*/
        string[] Range1 = { "Hi", "Hello" };
        List<string> List1 = new List<string>();
        List1.AddRange(Range1);
        string[] Range2 = { "By", "Goodbye"};
        List<string> List2 =  new List<string>();
        List2.AddRange(Range2);
        //List<string> List3 = new List<string>();
        var List3 = List1.Concat(List2);
        List3.ToList();
        
            foreach(string Item in List3)
            {
                Console.Write("{0} ", Item);
            }
            Console.WriteLine();
            Console.WriteLine();
        return num+1;
    }
}

