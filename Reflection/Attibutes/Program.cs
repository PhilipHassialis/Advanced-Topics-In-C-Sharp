using System;

namespace Attibutes
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class RepeatAttribute : Attribute
    {
        public int Times { get; }
        public RepeatAttribute(int times)
        {
            Times = times;
        }
    }

    public class AttributeDemo
    {
        [Repeat(3)]
        [Repeat(7)]
        public void SomeMethod() {}
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sm = typeof(AttributeDemo).GetMethod("SomeMethod");
            foreach (var att in sm.GetCustomAttributes(true))
            {
                Console.WriteLine($"Found attribute {att.GetType()}");
                if (att is RepeatAttribute ra)
                {
                    Console.WriteLine($"Need to repeat {ra.Times}");
                }
            }
        }
    }
}
