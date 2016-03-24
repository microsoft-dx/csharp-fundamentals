using System;

namespace Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[] 
            {
                new Circle(xCoordinate: 1, yCoordinate: 2, radius: 4),
                new Square(xCoordinate: 3.5, yCoordinate: 4.6, side: 12)
            };

            foreach (var shape in shapes)
                shape.Print();
        }
    }
}
