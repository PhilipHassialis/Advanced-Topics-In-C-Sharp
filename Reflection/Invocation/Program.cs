using System;

namespace Invocation
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "Philip Alexander      ";
            var t = s.GetType();
            Console.WriteLine(t);

            var trimMethod = t.GetMethod("Trim", Array.Empty<Type>());
            var result = trimMethod.Invoke(s, Array.Empty<object>());
            Console.WriteLine($"\"{result}\"");

            var numberString = "123";
            var parseMethod = typeof(int).GetMethod("TryParse", new[] { typeof(string), typeof(int).MakeByRefType() });
            object[] methodArgs = { numberString, null };
            var ok = parseMethod.Invoke(null, methodArgs);

            Console.WriteLine(ok);
            Console.WriteLine(methodArgs[1]);

            // Activator.CreateInstance<T>

            var at = typeof(Activator);
            var method = at.GetMethod("CreateInstance", Array.Empty<Type>());
            Console.WriteLine(method);
            
            var ciGeneric = method.MakeGenericMethod(typeof(Guid));
            Console.WriteLine(ciGeneric);

            var guid = ciGeneric.Invoke(null, Array.Empty<object>());
            Console.WriteLine(guid);

        }
    }
}
