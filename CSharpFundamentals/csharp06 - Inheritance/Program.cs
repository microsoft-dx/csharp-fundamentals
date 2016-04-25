using System;

namespace Inheritance
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
            snake.Bite();

            HuntingDog huntingDog = new HuntingDog("pink", "chihuahua", 120);
            huntingDog.Hunt();


            Animal[] animals = new Animal[]
            {
                animal,
                dog,
                snake,
                huntingDog
            };

            Console.WriteLine("Iterating through the animals array\n");

            foreach (var a in animals)
            {
                a.Eat("food for animals");
                PrintColor(a);
            }
        }

        public static void PrintColor(Animal animal)
        {
            Console.WriteLine("The animal is: {0}\n", animal.Color);
        }
    }
}
