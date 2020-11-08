using System;
using System.Runtime.InteropServices;

namespace SpanOfT
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                byte* ptr = stackalloc byte[100];
                Span<byte> memory = new Span<byte>(ptr, 100);

                IntPtr unmanagedPtr = Marshal.AllocHGlobal(123);
                Span<byte> unmanagedMemory = new Span<byte>(unmanagedPtr.ToPointer(),123);

                Marshal.FreeHGlobal(unmanagedPtr);
            }

            char[] stuff = "hello".ToCharArray();
            Span<char> arrayMemory = stuff;

            ReadOnlySpan<char> more = "hi there!".AsSpan();

            Console.WriteLine($"our Span has {more.Length} elements");

            arrayMemory.Fill('x');
            Console.WriteLine(stuff);
            arrayMemory.Clear();
            Console.WriteLine(stuff);
        }
    }
}
