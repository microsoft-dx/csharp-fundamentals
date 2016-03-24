namespace Interfaces
{
    public interface IVehicle
    {
        int Speed { get; set; }

        void Move();
        void Accelerate(int desiredSpeed);
        void Decelerate(int desiredSpeed);
    }
}
