using System;
using System.Linq;

namespace Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = typeof(bool);
            var b = Activator.CreateInstance(t);
            Console.WriteLine(b);

            var b2 = Activator.CreateInstance<bool>();
            Console.WriteLine(b2);

            var wc = Activator.CreateInstance("System", "System.Timers.Timer");
            Console.WriteLine(wc);
            wc.Unwrap();
            Console.WriteLine(wc.Unwrap());

            var alType = Type.GetType("System.Collections.ArrayList");
            var alCtor = alType.GetConstructor(Array.Empty<Type>());

            var al = alCtor.Invoke(Array.Empty<object>());

            Console.WriteLine(al);

            var st = typeof(string);
            var ctor = st.GetConstructor(new[] { typeof(char[]) });
            var str = ctor.Invoke(new object[]
            {
                new [] {'h','e','l','l','o'}
            });

            Console.WriteLine(str);

            var listType = Type.GetType("System.Collections.Generic.List`1");
            var listOfIntType = listType.MakeGenericType(typeof(int));
            var listOfIntCtor = listOfIntType.GetConstructor(Array.Empty<Type>());
            var theList = listOfIntCtor.Invoke(Array.Empty<object>());

            Console.WriteLine(theList);

            var charType = typeof(char);
            Array.CreateInstance(charType, 10);
            var charArrayType = charType.MakeArrayType();
            Console.WriteLine(charArrayType);

            var charArrayCtor = charArrayType.GetConstructor(new[] { typeof(int) });
            var arr = charArrayCtor.Invoke(new object[] { 20 });
            Console.WriteLine(arr);

            char[] arr2 = (char[])arr;

            for (int i = 0; i < arr2.Length; i++) arr2[i] = (char)('A' + i);
            Console.WriteLine(arr2);






        }
    }
}
