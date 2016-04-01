using System;

namespace Abstract
{
    public class Square : Shape
    {
        public double Side { get; set; }

        public override double GetArea()
        {
            return Side * Side;
        }

        public double GetDiagonal()
        {
            return Side * Math.Sqrt(2);
        }

        public override void Print()
        {
            Console.WriteLine("This is a square centered in {0} with {1} side and with {2} area", Center.ToString(), Side, GetArea());
        }

        public Square()
        {
        }

        public Square(double xCoordinate, double yCoordinate, double side) : base(xCoordinate, yCoordinate)
        {
            Side = side;
        }
    }
}
