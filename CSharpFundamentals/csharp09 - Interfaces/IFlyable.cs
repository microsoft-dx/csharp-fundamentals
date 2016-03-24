namespace Interfaces
{
    public interface IFlyable
    {
        int Altitude { get; set; }

        void Fly();
        void IncreaseAltitude(int desiredAltitude);
        void DecreaseAltitude(int desiredAltitude);
    }
}
