using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Test3
{
    class Program
    {
        static void Main()
        {
            SubThings C = new SubThings(4);
            SubThings D = new SubThings(9);
            List<object> ObjectList = new List<object>();
            ObjectList.Add(C);
            ObjectList.Add(D);

            IList<System.Object> a = new IList<>();
		  
            a.Add(C);

            C.PrintSelf();
            Console.WriteLine("Object Val \"{0}\"(C) = {1}", C, C.a);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press [Enter] To Continue ");
            Console.ReadLine();


            {
                //Thing.PrintSelf();
                //Console.WriteLine("Object Val \"{0}\" = {1}", Thing, Thing.a);
                //Console.WriteLine("Object Val \"Thing\" = {0} ", Thing);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("---------------------");
            }
            Console.Write("Press [Enter] To Continue ");
            Console.ReadLine();
        }
    }

    public class Things
    {
        public int a;
        public int b;
        public int c;

        public Things()
        {
            a = 5;
            b = 12;
            c = 9;
        }

        public void PrintSelf()
        {
            Console.WriteLine("Object = {0}", this);
        }
    }

    public class SubThings : Things
    {
        public int aa;
        public int bb;
        public int cc;

        public SubThings(int v)
        {
            aa = v;
            bb = 12;
            cc = 9;
        }

        public void PrintSelft()
        {
            Console.WriteLine("Object = {0}", this);
        }
    }
}
