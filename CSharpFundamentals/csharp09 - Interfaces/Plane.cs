using System;

namespace Interfaces
{
    public class Plane : IVehicle, IFlyable
    {
        public int Speed { get; set; }
        public int Altitude { get; set; }

        public void Accelerate(int desiredSpeed)
        {
            if (desiredSpeed > Speed)
                Speed = desiredSpeed;
        }

        public void Decelerate(int desiredSpeed)
        {
            if (desiredSpeed < Speed)
                Speed = desiredSpeed;
        }

        public void Move()
        {
            Console.WriteLine("Plane start moving");
        }

        public void IncreaseAltitude(int desiredAltitude)
        {
            if (desiredAltitude > Altitude)
                Altitude = desiredAltitude;
        }

        public void DecreaseAltitude(int desiredAltitude)
        {
            if (desiredAltitude < Altitude)
                Altitude = desiredAltitude;
        }

        public void Fly()
        {
            Console.WriteLine("Plane start flying");
        }
    }
}
