using System;

namespace Classes
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person()
        {
        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void PrintPerson()
        {
            Console.WriteLine("First Name: {0}, Last Name: {1}, Age: {2}", FirstName, LastName, Age);
        }
    }
}
