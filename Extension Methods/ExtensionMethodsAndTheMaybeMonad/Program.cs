using System;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;

namespace ExtensionMethodsAndTheMaybeMonad
{
    public static class Maybe
    {
        public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator)
            where TResult:class
            where TInput:class
        {
            if (o == null) return null;
            return evaluator(o);
        }
        
        public static TInput If<TInput>(this TInput o, Func<TInput, bool> evaluator)
            where TInput:class
        {
            if (o == null) return null;
            return evaluator(o) ? o : null;
        }

        public static TInput Do<TInput>(this TInput o, Action<TInput> action)
            where TInput:class
        {
            if (o == null) return null;
            action(o);
            return o;
        }

        public static TResult Return<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator, TResult failureValue)
            where TInput:class
        {
            if (o == null) return failureValue;
            return evaluator(o);
        }

    }



    public class Address
    {
        public string PostCode { get; set; }
    }
    public class Person
    {
        public Address Address { get; set; }
    }




    class Program
    {
        public void MyMethod(Person p)
        {
            string postcode = "UNKNOWN";
            //postcode = p?.Address?.PostCode;
            if (p!=null)
            {
                if (HasMedicalRecord(p) && p.Address!=null)
                {
                    CheckAddress(p.Address);
                    if (p.Address.PostCode != null)
                        postcode = p.Address.PostCode.ToString();
                    else
                        postcode = "UNKNOWN";
                }
            }

        }

        public void MyMethodBetter(Person p)
        {
            string postcode = p.With(x => x.Address).With(x => x.PostCode);

            postcode = p
                .If(HasMedicalRecord)
                .With(x => x.Address)
                .Do(CheckAddress)
                .Return(x => x.PostCode, "UNKNOWN");
                
        }

        private void CheckAddress(Address address)
        {
            throw new NotImplementedException();
        }

        private bool HasMedicalRecord(Person p)
        {
            throw new NotImplementedException();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
