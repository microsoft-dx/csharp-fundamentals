using System;

namespace Overriding
{
    public class Dog : Animal
    {
        public string Breed { get; set; }

        public override void Eat(string food)
        {
            Console.WriteLine("{0} {1} dog eating {2}", Color, Breed, food);
        }

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
