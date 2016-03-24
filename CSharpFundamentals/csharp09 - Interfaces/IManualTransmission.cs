namespace Interfaces
{
    public interface IManualTransmission
    {
        int Gear { get; set; }

        void ShiftGearUp();
        void ShiftGearDown();
    }
}
