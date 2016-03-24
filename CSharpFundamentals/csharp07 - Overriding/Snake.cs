using System;

namespace Overriding
{
    public class Snake : Animal
    {
        public bool IsVenomous { get; set; }

        public override void Eat(string food)
        {
            string eat = (IsVenomous) ? String.Format("{0} venomous snake eating {1}", Color, food) : String.Format("harmless {0} snake eating {1}", Color, food);
            Console.WriteLine(eat);
        }

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
