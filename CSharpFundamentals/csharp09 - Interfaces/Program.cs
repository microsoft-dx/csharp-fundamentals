using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle[] vehicles = new IVehicle[]
            {
                new Car(),
                new Plane()
            };

            IFlyable[] flyingThings = new IFlyable[]
            {
                new Plane(),
                new Bird()
            };

            Console.WriteLine("Iterating through vehicles");

            foreach (var v in vehicles)
                v.Move();

            Console.WriteLine("Iterating through flying things");

            foreach (var f in flyingThings)
                f.Fly();
        }
    }
}
