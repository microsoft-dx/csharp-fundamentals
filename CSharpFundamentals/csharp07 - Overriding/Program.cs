using System;

namespace Overriding
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal("green");
            animal.Eat("food");

            Dog dog = new Dog("blue", "bichon");
            dog.Eat("bones");
            dog.Bark();

            Snake snake = new Snake("yellow", false);
            snake.Eat("rats");
            snake.Bite();

            Console.WriteLine("Array of animals eating: ");

            Animal[] animals = new Animal[] 
            {
                animal,
                dog,
                snake
            };

            foreach (var a in animals)
                a.Eat("food for everybody");
        }
    }
}
