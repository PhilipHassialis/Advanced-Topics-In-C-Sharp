using System;

namespace SystemType
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(int);
            Console.WriteLine(t.GetMethods());
            Type t2 = "hello".GetType();
            Console.WriteLine(t2.FullName);
            Console.WriteLine(t2.GetFields());
            var a = typeof(string).Assembly;
            Console.WriteLine(a);
            var types = a.GetTypes();
            Console.WriteLine(types[10]);
            var t3 = Type.GetType("System.Int64");
            var t4 = Type.GetType("System.Collections.Generic.List`1");
            Console.WriteLine(t4.GetFields());
            Console.WriteLine(t4.GetFields().Length);
        }
    }
}
