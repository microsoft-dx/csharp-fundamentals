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

            Animal[] animals = new Animal[3];
            animals[0] = animal;
            animals[1] = dog;
            animals[2] = snake;

            foreach (var a in animals)
                a.Eat("food for everybody");
        }
    }
}
