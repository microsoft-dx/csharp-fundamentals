using System;

namespace Static
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.PrintCount();

            Person newton = new Person(firstName: "Isaac", lastName: "Newton", age: 373);
            newton.PrintPerson();

            Person.PrintCount();

            Person galileo = new Person("Galileo", "Galilei", 452);
            galileo.PrintPerson();

            Person.PrintCount();
            Console.WriteLine(MathUtilities.Square(7));
        }
    }
}
