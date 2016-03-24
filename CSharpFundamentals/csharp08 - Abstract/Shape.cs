using System;

namespace Abstract
{
    public abstract class Shape
    {
        public Point Center { get; set; }

        public abstract double GetArea();
        
        public virtual void Print()
        {
            Console.WriteLine("This is a shape centered in {0}", Center.ToString());
        }

        public Shape()
        {
        }

        public Shape(double xCoordinate, double yCoordinate)
        {
            Center = new Point(xCoordinate, yCoordinate);
        }
    }
}
