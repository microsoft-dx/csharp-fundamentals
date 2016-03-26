using System;

namespace Overriding
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal("green");
            animal.Eat("food");
            Pet(animal);

            Console.WriteLine("\n");
            Dog dog = new Dog("blue", "bichon");
            dog.Eat("bones");
            dog.Bark();
            Pet(dog);

            Console.WriteLine("\n");
            Snake snake = new Snake("yellow", false);
            snake.Eat("rats");
            snake.Bite();
            Pet(snake);

            Console.WriteLine("\nArray of animals eating: ");

            Animal[] animals = new Animal[] 
            {
                animal,
                dog,
                snake
            };

            foreach (var a in animals)
                a.Eat("food for everybody");

            Console.WriteLine("\nPetting");
            foreach (var a in animals)
                Pet(a);
        }

        public static void Pet(Animal animal)
        {
            Console.WriteLine("You are petting a {0}", animal.GetType());
        }
    }
}
