Abstract
=======
Introduction
------------------

>The abstract modifier indicates that the thing being modified has a **missing or incomplete implementation.** 

>The abstract modifier can be used with classes, methods, properties, indexers, and events. 

>Use the abstract modifier in a class declaration to indicate that a class is intended only to be a base class of other classes. 

>Members marked as abstract, or included in an abstract class, must be implemented by classes that derive from the abstract class.

>[More from the Official MSDN Documentation](https://msdn.microsoft.com/en-us/library/sf985hc5.aspx)

The reason we would want to have an abstract class is for it to serve as a base class for other classes, without making sense to have it on its own.

- An abstract class cannot be instantiated.

- An abstract class may contain abstract methods and accessors.

>It is not possible to modify an abstract class with the sealed (C# Reference) modifier because the two modifers have opposite meanings. The sealed modifier prevents a class from being inherited and the abstract modifier requires a class to be inherited.

- A non-abstract class derived from an abstract class must include actual implementations of all inherited abstract methods and accessors.

In this project, we have an inheritance structure as following: `Shape` --> `Circle`, `Square`.


`Circle` has a `Center` and a `Radius`, while `Square` has a `Center` and a `Length` and we want to calculate the Area of both shapes.

In the end, we will want to get the area of these geometric shapes (We want to have a `GetArea` method on both `Circle` and `Square`, so it would be logical to create the method in the parent class, `Shape`). 

But think for a moment: **does it make sense for a shape with no dimensions** (an entity that denotes the abstract notion of a shape, that only has a central point) **to have an area**?

`Point`
------------
We will create a  class called `Point` that will model a geometric point: it will have X and Y coordinates, a constructor with two parameters, (the two coordinates) and a parameterless one.

It will also override the `ToString` method that it inherits from `System.Object` and it will return the object in the following manner: `(XCoordinate, YCoordinate)`.

    public class Point
    {
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }

        public Point()
        {
        }

        public Point(double xCoordinate, double yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", XCoordinate, YCoordinate);
        }
    }


`Shape`
------------

As we said earlier, we want to have a base class for our geometric shapes, each of them with a Center. We also want to calculate the area in each child class, so the obvious solution is to have the `Center`  and `GetArea` as members in the `Shape` class.

>But think for a moment: **does it make sense for a shape with no dimensions** (an entity that denotes the abstract notion of a shape, that only has a central point) **to have an area**?

We want both `Square` and `Circle`  to inherit `GetArea` from `Shape`, but what implementation should we make for `GetArea` in `Shape`?

>The abstract modifier indicates that the thing being modified has a **missing or incomplete implementation.** 

The best solution is to mark the `GetArea` method in `Shape` as abstract, which will allow us to skip the implementation and only provide the method signature. 

>The moment we make an abstract method, must make the containing class `abstract`. This is because by making the method `abstract`,  we only provide the signature of the method, not an implementation.

>So we are not allowed to instantiate an abstract class, because we might have missing or incomplete implementation for members.

> We are also required that if a non-abstract class implements an abstract class, it must provide implementations for all abstract members.

Let's have a look at the `Shape` class:

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
It has a `Center` point, two constructors and the `abstract` methods `GetArea` and `Print`.


Now that we have the base class, we are ready to start implementing the classes that inherit `Shape`.

`Circle`
--------------
A circle has a central point (which the class inherits from `Shape`) and a radius.  Since `Circle` inherits `Shape`, we must provide functionality for `GetArea` and `Print`, and we will do it by using the `override` keyword.

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
    
Besides the `Radius` property, `GetArea` and `Print` methods, we also implement two constructors and a method specific for a circle, `GetLength` which returns the length of the circle.

`Square`
--------------

The `Square` class has a very similar implementation to the `Circle`, this time with a `Side` property and a `GetDiagonal` method which returns the length of the diagonal of the square.

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

Using the classes
------------------------

As in the other examples where we had some inheritance structure, we will use the base class to create an array that is capable of containing all types of classes that inherit the base class.

        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[] 
            {
                new Circle(xCoordinate: 1, yCoordinate: 2, radius: 4),
                new Square(xCoordinate: 3.5, yCoordinate: 4.6, side: 12)
            };

            foreach (var shape in shapes)
            {
                shape.Print();

                if(shape is Circle)
                {
                    double length = (shape as Circle).GetLength();
                    Console.WriteLine("The length is: {0}\n", length);
                }

                else if(shape is Square)
                {
                    double diagonal = (shape as Square).GetDiagonal();
                    Console.WriteLine("The diagonal is: {0}", diagonal);
                }
            }
                
        }
This is also an example of named parameters:

`new Circle(xCoordinate: 1, yCoordinate: 2, radius: 4)`

>Named arguments free you from the need to remember or to look up the order of parameters in the parameter lists of called methods. The parameter for each argument can be specified by parameter name.

>[More from the Official MSDN Documentation](https://msdn.microsoft.com/en-us/library/dd264739.aspx)

We create an array of `Shape` and we populate it with a `Circle` and a `Square`. Then, we iterate through the array and execute the `Print` method, which has specific implementation for each class.

>[A cast operation between reference types **does not change the run-time type of the underlying object**; it only changes the type of the value that is being used as a reference to that object.](https://github.com/microsoft-dx/csharp-fundamentals/tree/master/CSharpFundamentals/csharp06%20-%20Inheritance#using-a-dog-as-an-animal)

Even though we treat the objects in the array as `Shape`, they still exist in the memory as their initial type from instantiating.

At runtime, we can verify the type of the object and execute the specific method, if it's a `Circle` or a `Square`.

                if(shape is Circle)
                {
                    double length = (shape as Circle).GetLength();
                    Console.WriteLine("The length is: {0}\n", length);
                }

                else if(shape is Square)
                {
                    double diagonal = (shape as Square).GetDiagonal();
                    Console.WriteLine("The diagonal is: {0}", diagonal);
                }
                
`double length = (shape as Circle).GetLength();` is equivalent to:

`Circle c = (Circle)shape;
double length = c.GetLength();`

and allows us to access the members without a cast an an assignment.

>[More information about the `as` operator in C# on the Official MSDN Documentation](https://msdn.microsoft.com/en-us/library/cscsdfbt.aspx)


