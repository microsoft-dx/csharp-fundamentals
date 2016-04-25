using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal("green");
            animal.Eat("food");
            PrintColor(animal);

            Dog dog = new Dog("blue", "bichon");
            dog.Eat("bones");
            dog.Bark();
            PrintColor(dog);

            Snake snake = new Snake("yellow", false);
            snake.Bite();
            PrintColor(snake);

            HuntingDog huntingDog = new HuntingDog("pink", "chihuahua", 120);
            huntingDog.Hunt();
            PrintColor(snake);


            Animal[] animals = new Animal[]
            {
                animal,
                dog,
                snake,
                huntingDog
            };

            Console.WriteLine("Iterating through the animals array\n");

            foreach (var a in animals)
                a.Eat("food for animals");
        }

        public static void PrintColor(Animal animal)
        {
            Console.WriteLine("The animal is: {0}\n", animal.Color);
        }
    }
}
