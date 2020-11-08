using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;

namespace ExtensionMethods
{
    public class Foo
    {
        public virtual string Name => "Foo";
    }

    public class FooDerived:Foo
    {
        public override string Name => "FooDerived";
    }

    public class Person
    {
        public string Name;
        public int Age;

        public override string ToString()
        {
            return $"Name: {Name} Age: {Age}";
        }
    }

    public static class DemoExtensionMethods
    {
        public static int Measure(this Foo foo)
        {
            return foo.Name.Length;
        }

        public static int Measure(this FooDerived derived)
        {
            return 42; // derived.Name.Length;
        }

        public static string ToString(this Foo foo)
        {
            return "test";
        }


        public static string ToBinary(this int n)
        {
            return Convert.ToString(n, 2);
        }

        public static Person ToPerson(this (string name, int age) data)
        {
            return new Person() { Name = data.name, Age = data.age };

        }

        public static int Measure<T,U>(this Tuple<T,U> t)
        {
            return t.Item2.ToString().Length;
        }

        public static Stopwatch Measure(this Func<int> f)
        {
            var st = new Stopwatch();
            st.Start();
            f();
            st.Stop();
            return st;
        }

        public static void Foo(this object o)
        {
            Console.WriteLine("Object Foo extension");
        }

        public static void Foo<T>(this T o)
        {
            Console.WriteLine("Generic Foo extension: "+o.GetType().Name);
        }

        public static void DeepCopy<T> (this T o) where T:ISerializable, new()
        {

        }

        public static void Save(this ISerializable serializable)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var f = new Foo();
            Console.WriteLine(f.Measure());
            int n = 7;
            Console.WriteLine(n.ToBinary());
            var derived = new FooDerived();
            Foo parent = derived;
            Console.WriteLine("Derived: "+derived.Measure());
            Console.WriteLine("Parent:  "+parent.Measure());
            Console.WriteLine(f);
            Console.WriteLine(ExtensionMethods.DemoExtensionMethods.ToString(f));

            Console.WriteLine(("Philip", 45).ToPerson());

            Console.WriteLine(Tuple.Create("Philip",true).Measure());

            Func<int> calc = delegate
            {
                Thread.Sleep(1000);
                return 45;
            };

            Console.WriteLine(calc.Measure().ElapsedMilliseconds);

            "hello".Foo();


        }
    }
}
