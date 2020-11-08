using System;

namespace Inspection
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = typeof(Guid);
            Console.WriteLine(t.FullName);
            Console.WriteLine(t.Name);
            var ctors = t.GetConstructors();
            foreach (var ct in ctors)
            {
                Console.WriteLine(ct);
                Console.WriteLine("-----");
                var pars = ct.GetParameters();
                for (int i = 0; i < pars.Length; i++)
                {
                    var par = pars[i];
                    Console.Write($"{par.ParameterType.Name} {par.Name}");
                    if (i + 1 < pars.Length) Console.Write(",");
                }

                Console.WriteLine("\n====");
            }

            var meths = t.GetMethods();
            foreach (var meth in meths)
            {
                Console.Write(meth.Name);
                Console.Write("(");
                var pars = meth.GetParameters();
                for (int i = 0; i < pars.Length; i++)
                {
                    Console.Write($"{pars[i].ParameterType.Name} {pars[i].Name}");
                    if (i + 1 < pars.Length) Console.Write(",");
                }
                Console.WriteLine(")");
            }
        }
    }
}
