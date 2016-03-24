using System;


namespace ValueReference
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 5;
            Console.WriteLine("Initially, the value of the number is: {0}", number);

            ModifyNumber(number);
            Console.WriteLine("After calling the ModifyNumber method, the value of number is: {0}", number);

            int[] numbers = new int[5];
            Console.WriteLine("Initially, the value of numbers[0] is: {0}", numbers[0]);

            ModifyArray(numbers);
            Console.WriteLine("After calling the ModifyArray method, the value of numbers[0] is :{0}", numbers[0]);
        }

        public static void ModifyArray(int[] array)
        {
            array[0] = 100;
        }

        public static void ModifyNumber(int number)
        {
            number = 1000;
        }
    }
}
