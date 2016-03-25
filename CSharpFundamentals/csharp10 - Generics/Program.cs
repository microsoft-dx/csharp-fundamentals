using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using the generic Swap method with integers");

            int zero = 0, one = 1;
            Console.WriteLine("zero = {0}, one = {1}", zero, one);

            Swap(ref zero, ref one);
            Console.WriteLine("zero = {0}, one = {1}", zero, one);

            Console.WriteLine("\nUsing the generic swap methods with chars");

            char firstLetter = 'a', lastLetter = 'z';
            Console.WriteLine("firstLetter = {0}, lastLetter = {1}", firstLetter, lastLetter);

            Swap(ref firstLetter, ref lastLetter);
            Console.WriteLine("firstLetter = {0}, lastLetter = {1}", firstLetter, lastLetter);


            Console.WriteLine("\nUsing generic collections");

            List<string> messages = new List<string>();
            messages.Add("Hello");
            messages.Add("World!");

            //messages.Add(46); - not allowed

            List<int> numbers = new List<int>();
            numbers.Add(46);
            numbers.Add(7);

            //numbers.Add("Hello"); - not allowed
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp;

            temp = a;
            a = b;
            b = temp;
        }
    }
}
