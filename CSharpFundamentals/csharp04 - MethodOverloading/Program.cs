
namespace MethodOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Add(2, 3);
            Add(2, 3, 4);

            Add(2.0, 3.0);
            Add(2.0, 3.0, 4.0);
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Add(double a, double b, double c)
        {
            return a + b + c;
        }
    }
}
