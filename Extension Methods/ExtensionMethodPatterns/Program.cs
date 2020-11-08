using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethodPatterns
{

    public static class ExtensionMethods
    {
        public static StringBuilder al(this StringBuilder sb, string text)
        {
            return sb.AppendLine(text);
        }

        public static StringBuilder AppendFormatLine(this StringBuilder sb, string format, params object[] args)
        {
            return sb.AppendFormat(format, args).AppendLine();
        }

        public static ulong Xor(this IList<ulong> values)
        {
            ulong first = values[0];
            foreach (var x in values.Skip(1))
            {
                first ^= x;
            }
            return first;
        }

        public static void AddRange<T>(this IList<T> list, params T[] objects)
        {
            //foreach (var t in objects)
            //{
            //    list.Add(t);
            //}
            list.AddRange(objects);
        }

        public static string f(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static DateTime June(this int day, int year)
        {
            return new DateTime(year, 6, day);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            //list.AddRange(new[] { 1, 2, 3 });
            list.AddRange(1, 2, 3);

            "My name is {0}".f("Philip");

            var notToday = 10.June(2020);



        }
    }
}
