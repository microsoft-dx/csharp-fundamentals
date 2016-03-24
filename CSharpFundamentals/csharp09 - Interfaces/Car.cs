using System;

namespace Interfaces
{
    public class Car : IVehicle, IManualTransmission
    {
        public int Gear { get; set; }
        
        public int Speed { get; set; }

        public void Move()
        {
            Console.WriteLine("Car moving");
        }

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

        public void ShiftGearDown()
        {
            Gear = (Gear > 0) ? Gear -- : 0;
        }

        public void ShiftGearUp()
        {
            Gear++;
        }
    }
}
