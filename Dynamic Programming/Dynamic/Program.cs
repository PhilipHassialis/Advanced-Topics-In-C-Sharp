using System;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            // late binding
            dynamic d = "Hello";
            //int n = d.Area; -- but it would compile

            Console.WriteLine(d.GetType());
            Console.WriteLine(d.Length);

            d += " World";
            Console.WriteLine(d);

            try
            {
                int n = d.Area;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            d = 321;
            Console.WriteLine(d.GetType());
            d--;
            Console.WriteLine(d);

        }
    }
}
