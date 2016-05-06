using System;

namespace Abstract
{
    public abstract class Shape
    {
        public Point Center { get; set; }

        public abstract double GetArea();

        public abstract void Print();

        public Shape()
        {
        }

        public Shape(double xCoordinate, double yCoordinate)
        {
            Center = new Point(xCoordinate, yCoordinate);
        }
    }
}
