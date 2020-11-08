using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace ExpandoObjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic person = new ExpandoObject();
            person.FirstName = "Philip";
            person.Age = 22;
            Console.WriteLine($"{person.FirstName} is {person.Age} yrs old");

            person.Address = new ExpandoObject();
            person.Address.Country = "Greece";
            person.Address.City = "Athens";

            person.SayHello = new Action(() => { Console.WriteLine("Hello"); });
            person.SayHello();

            person.FallsIll = null;
            person.FallsIll += new EventHandler<dynamic>((sender, args) =>
            {
                Console.WriteLine($"We need a doctor for {args}");
            });

            EventHandler<dynamic> e = person.FallsIll;
            e?.Invoke(person, person.FirstName);

            var dict = (IDictionary<string, object>)person;
            Console.WriteLine(dict.ContainsKey("FirstName"));
            Console.WriteLine(dict.ContainsKey("LastName"));
            dict["LastName"] = "Hassialis";
            Console.WriteLine(person.LastName);
        }
    }
}
