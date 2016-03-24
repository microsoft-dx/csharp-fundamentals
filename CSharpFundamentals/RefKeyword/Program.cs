using System;

namespace RefKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 3;
            Increment(number);
            Console.WriteLine(number);

            int num = 0;
            ReferenceIncrement(ref num);
            Console.WriteLine(num);
        }

        public static void Increment(int number)
        {
            number = number + 1;
        }

        public static void ReferenceIncrement(ref int number)
        {
            number = number + 1;
        }
    }
}

