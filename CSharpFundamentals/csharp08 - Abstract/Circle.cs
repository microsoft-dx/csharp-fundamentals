using System;

namespace Abstract
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetLength()
        {
            return 2 * Math.PI * Radius;
        }

        public override void Print()
        {
            Console.WriteLine("This is a circle centered in {0} with {1} radius and with {2} area", Center.ToString(), Radius, GetArea());
        }

        public Circle()
        {
        }

        public Circle(double xCoordinate, double yCoordinate, double radius) : base(xCoordinate, yCoordinate)
        {
            Radius = radius;
        }
    }
}
