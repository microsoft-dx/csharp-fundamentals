using System;

namespace Static
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public static int Count { get; private set; }

        public Person()
        {
            Count++;
        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;

            Count++;
        }

        public void PrintPerson()
        {
            Console.WriteLine("First Name: {0}, Last Name: {1}, Age: {2}", FirstName, LastName, Age);
        }

        public static void PrintCount()
        {
            Console.WriteLine("Number of persons: {0}", Count);
        }
    }
}
