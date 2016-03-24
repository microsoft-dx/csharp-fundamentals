using System;

namespace Inheritance
{
    public class Snake : Animal
    {
        public bool IsVenomous { get; set; }

        public void Bite()
        {
            string bite = (IsVenomous) ? String.Format("{0} venomous snake biting", Color) : String.Format("harmless {0} snake biting", Color);
            Console.WriteLine(bite);
        }

        public Snake()
        {
        }

        public Snake(string color, bool isVenomous) : base(color)
        {
            IsVenomous = isVenomous;
        }
    }
}
