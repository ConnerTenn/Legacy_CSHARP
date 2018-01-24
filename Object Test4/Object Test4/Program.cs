using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Net;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace Object_Test4
{
    class Program
    {
        
        static void Main()
        {
            /*
            Dictionary<string, string> providerOptions = new Dictionary<string, string>
                {
                    {"CompilerVersion", "v3.5"}
                };
            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);

            CompilerParameters compilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };

            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, source);

            if (results.Errors.Count != 0)
                throw new Exception("Mission failed!");

            object o = results.CompiledAssembly.CreateInstance("Foo.Bar");
            MethodInfo mi = o.GetType().GetMethod(Q.Method);
            mi.Invoke(o, null);

            IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo> group =
                typeof(String).GetMembers().
                GroupBy(member => member.MemberType).
                First();
            Console.WriteLine("\nValues that have the key '{0}':", group.Key);
            foreach (System.Reflection.MemberInfo mi in group)
                Console.WriteLine(mi.Name);*/

            

            Test A = new Test();
            Test B = new Test();
            Test C = new Test();
            Test D = new Test();
            List<Object> ObjectList = new List<Object>();
            ObjectList.Add(A);
            ObjectList.Add(B);
            ObjectList.Add(C);
            ObjectList.Add(D);


            foreach (object Thing in ObjectList)
            {
                //MethodInfo MI = Thing.GetType();
                MemberInfo MI2 = Thing.GetType();
                var MI3 = Thing.GetType().GetMethods();
                var MI4 = Thing.GetType().GetMethod("print");
                var MI5 = Thing.GetType().GetMember("print");
                Console.WriteLine(MI2);
                Console.WriteLine(MI3);
                Console.WriteLine(MI4);
                Console.WriteLine(MI5);
                Console.WriteLine();
                
                //MI2.print();
            }

            Console.WriteLine();
            Console.Write("Press [Enter] To Exit");
            Console.ReadLine();
            
        }
    }

    class Test
    {
        public int num = 5;

        public void print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
