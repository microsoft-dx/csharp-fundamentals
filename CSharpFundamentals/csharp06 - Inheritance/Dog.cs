using System;

namespace Inheritance
{
    public class Dog : Animal
    {
        public string Breed { get; set; }

        public void Bark()
        {
            Console.WriteLine("{0} {1} dog barking", Color, Breed);
        }

        public Dog()
        {
        }

        public Dog(string color, string breed) : base(color)
        {
            Breed = breed;
        }
    }
}
