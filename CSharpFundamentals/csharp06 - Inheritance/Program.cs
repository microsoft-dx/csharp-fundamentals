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
        }
    }
}
