using System;

namespace RefKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 3;
            Increment(number);
            Console.WriteLine("After calling the Increment method, the value of number is: {0}", number);

            int num = 0;
            ReferenceIncrement(ref num);
            Console.WriteLine("After calling the ReferenceIncrement method, the value of num is: {0}", num);
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

