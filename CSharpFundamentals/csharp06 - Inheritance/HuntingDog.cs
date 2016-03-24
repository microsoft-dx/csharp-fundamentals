using System;

namespace Inheritance
{
    public class HuntingDog : Dog
    {
        public double Speed { get; set; }

        public void Hunt()
        {
            Console.WriteLine("{0} {1} hunting dog hunting with {2} mph speed", Color, Breed, Speed);
        }

        public HuntingDog()
        {
        }

        public HuntingDog(string color, string breed, double speed) : base(color, breed)
        {
            Speed = speed;
        }
    }
}
