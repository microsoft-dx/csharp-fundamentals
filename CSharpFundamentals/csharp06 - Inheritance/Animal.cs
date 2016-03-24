using System;

namespace Inheritance
{
    public class Animal
    {
        public string Color { get; set; }

        public void Eat(string food)
        {
            Console.WriteLine("{0} animal eating {1}", Color, food);
        }

        public Animal()
        {
        }

        public Animal(string color)
        {
            Color = color;
        }
    }
}
