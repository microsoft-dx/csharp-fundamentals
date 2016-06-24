Interfaces
========

> Interfaces are much like abstract classes, they share the fact that no instances of them can be created. 

> However, interfaces are even more conceptual than abstract classes, since no method bodies are allowed at all. So an interface is kind of like an abstract class with nothing but abstract methods, and since there are no methods with actual code, there is no need for any fields. 

> Properties are allowed though, as well as indexers and events. You can **consider an interface as a contract** - a class that implements it is required to implement all of the methods and properties. 

> However, the most important difference is that **while C# doesn't allow multiple inheritance**, where classes inherit more than a single base class, **it does in fact allow for implementation of multiple interfaces!** 

> [More from the article here.](http://csharp.net-tutorials.com/classes/interfaces/)

Interfaces summary
---------------------------

- An interface is like an abstract base class. Any class or struct that implements the interface must implement all its members.

- An interface can't be instantiated directly. Its members are implemented by any class or struct that implements the interface.

- Interfaces can contain events, indexers, methods, and properties.

- Interfaces contain no implementation of methods.

- A class or struct can implement multiple interfaces. A class can inherit a base class and also implement one or more interfaces.
> [More on interfaces in C# from the Official MSDN Documentation.](https://msdn.microsoft.com/en-us/library/ms173156.aspx?f=255&MSPPError=-2147217396)

The outline of interfaces is to consider them as contracts: any class that implements an interface **must** implement the properties and methods enforced by the interface.

They define the `what` part of the contract, letting the classes that implement them to define the `how`, so when you encounter a class that implements some interface, you can be absolutely certain that this class will contain implementations for every method and property defined in the interface.

Using interfaces is a very good way to create loosely coupled systems, making component-based programming much easier.

> The usefulness of defining the interface is obvious when we have a variety of implementations of the action that can be used by a single unchanged piece of code, where the only requirement is that the code be provided with an instance of the desired implementation.

> [The full CodeProject article here.](http://www.codeproject.com/Articles/54917/When-To-Use-Interfaces)

> The naming convention for interfaces requires a preceding "I". So for an interface that describes a vehicle, the name should be `IVehicle`. 

The Interface Segregation Principle (ISP)
---------------------------------------------------------

> The Interface Segregation Principle states that no client should be forced to depend on methods it does not use.

>ISP splits interfaces that are very large into smaller and more specific ones so that clients will only have to know about the methods that are of interest to them. Such shrunken interfaces are also called role interfaces.

>  ISP is intended to keep a system decoupled and thus easier to refactor, change, and redeploy. ISP is one of the five SOLID principles of object-oriented design.

> [More from the Wikipedia article on Interface Segregation Principle.](https://en.wikipedia.org/wiki/Interface_segregation_principle)


At its core, the Interface Segregation Principles states that interfaces should be *small*. Any class that implements an interface **must** provide implementations for every method, event or property defined. So unless *every* class that implements the interface must have all functionality, it does not make sense to have interfaces so large. 

> We must also not overuse the segregation of interfaces. If it makes sense for an interface to have a large number of members, so be it. Breaking interfaces in more and more interfaces can increase the complexity of your app, with no immediate benefits (**until the moment you have a class that does not need all members an interface defines**).

> We will discuss all five SOLID principles in a separate repository.


Declaring and using interfaces
-------------------------------------------

Declaring an interface is very similar to declaring a class. You simply use the keyword `interface`, choose a name and then declare the members.

> Notice that you are not allowed to specify access modifiers to interface members, since an interface is a publicly exposed contract.

    public interface IThing
    {
      void DoSomething();
    }

    public interface IUpdatable
    {
      void Update();
    }

    public class Thing : IThing, IUpdatable
    {
      public void DoSomething()
         {
    			// implementation
         }
      public void Update()
         {
    			// implementation
         }
    }

When you want a class to implement an interface, the same syntax as for inheritance is used. The difference is that your class can implement more interfaces, like in our example.

We will try to explain the usage with the following interfaces: `IFlyable` (for things that fly), `IVechicle` (for vehicles) and `IManualTransmission` (for things that have manual transmission).

> Notice how interfaces can be used to describe the ability (or set of abilities) of something - `IFlyable`, or the thing they represent - `IVechicle`.

These interfaces will be used with the following classes: `Bird` - will implement `IFlyable`, `Car` - will implement `IVehicle` and `IManualTransmission` , `Plane` - will implement `IFlyable` and `IVehicle`.

The `IFlyable` interface
-------------------------------

All things that fly have something in common: they fly at a certain altitude, have the ability to start flying, to increase or decrease altitude. So it makes sense to have the following interface:

     public interface IFlyable
    {
        int Altitude { get; set; }

        void Fly();
        void IncreaseAltitude(int desiredAltitude);
        void DecreaseAltitude(int desiredAltitude);
    }

One of the classes that implement the `IFlyable` interface is `Bird`.

    public class Bird : IFlyable
    {
        public int Altitude { get; set; }

        public void Fly()
        {
            Console.WriteLine("Bird starts flying");
        }

        public void IncreaseAltitude(int desiredAltitude)
        {
            if (desiredAltitude > Altitude)
                Altitude = desiredAltitude;
        }

        public void DecreaseAltitude(int desiredAltitude)
        {
            if (desiredAltitude < Altitude)
                Altitude = desiredAltitude;
        }
    }
The `Bird` class contains simply the implementation of the members declared in the interface.

The `IVehicle` interface
-------------------------------------

Let's consider the basic functionality a vechicle needs: it has to move, accelerate and decelerate, and you need to know what its speed is at certain times.

So any class that at some point is going to be a vehicle (it can be a car, a plane, a boat, bicycle),  it will need at least this functionality.


    public interface IVehicle
    {
        int Speed { get; set; }

        void Move();
        void Accelerate(int desiredSpeed);
        void Decelerate(int desiredSpeed);
    }

We will use this interface when implementing the `Plane` class.

    public class Plane : IVehicle, IFlyable
        {
            public int Speed { get; set; }
            public int Altitude { get; set; }
    
            public void Accelerate(int desiredSpeed)
            {
                if (desiredSpeed > Speed)
                    Speed = desiredSpeed;
            }
    
            public void Decelerate(int desiredSpeed)
            {
                if (desiredSpeed < Speed)
                    Speed = desiredSpeed;
            }
    
            public void Move()
            {
                Console.WriteLine("Plane starts moving");
            }
    
            public void IncreaseAltitude(int desiredAltitude)
            {
                if (desiredAltitude > Altitude)
                    Altitude = desiredAltitude;
            }
    
            public void DecreaseAltitude(int desiredAltitude)
            {
                if (desiredAltitude < Altitude)
                    Altitude = desiredAltitude;
            }
    
            public void Fly()
            {
                Console.WriteLine("Plane starts flying");
            }
        }

The `Plane` class implements both `IFlyable` and the `IVehicle` interfaces (since a plane flies and is a vehicle), so it must provide implementations for all members declared in these interfaces.

The `IManualTransmission` interface
----------------------------------------------------------

    public interface IManualTransmission
    {
        int Gear { get; set; }

        void ShiftGearUp();
        void ShiftGearDown();
    }
This interface tries to define objects that have manual transmission: you need to know the gear it is in, gear up and down.

We will use this interface to model a car - it is a vehicle that has manual transmission, so it is a perfect candidate to implement these two interfaces.

    public class Car : IVehicle, IManualTransmission
    {
        public int Gear { get; set; }
        
        public int Speed { get; set; }

        public void Move()
        {
            Console.WriteLine("Car moving");
        }

        public void Accelerate(int desiredSpeed)
        {
            if (desiredSpeed > Speed)
                Speed = desiredSpeed;
        }

        public void Decelerate(int desiredSpeed)
        {
            if (desiredSpeed < Speed)
                Speed = desiredSpeed;
        }

        public void ShiftGearDown()
        {
            Gear = (Gear > 0) ? Gear -- : 0;
        }

        public void ShiftGearUp()
        {
            Gear++;
        }
    }

Testing the program
----------------------------

    class Program
    {
        static void Main(string[] args)
        {
            IVehicle[] vehicles = new IVehicle[]
            {
                new Car(),
                new Plane()
            };

            IFlyable[] flyingThings = new IFlyable[]
            {
                new Plane(),
                new Bird()
            };

            Console.WriteLine("Iterating through vehicles");

            foreach (var v in vehicles)
                v.Move();

            Console.WriteLine("Iterating through flying things");

            foreach (var f in flyingThings)
                f.Fly();
        }
    }
The utility of using interfaces comes when we start using the classes. 

As in the case of using inheritance, we can group together in data structures (arrays, lists, dictionaries) objects that implement the same interfaces. At that point, you can only use the functionality that interface provides. (The object is upcasted to the type of the interface)

So if I deal with some object (or its parent) implements an interface, you can use the methods and properties from the interface.


> This is a very basic example of creating and using interfaces. [For a more advanced and real-life example of combining abstract classes and interfaces, see this project.](https://github.com/microsoft-dx/csharp-fundamentals/tree/master/CSharpFundamentals/csharp11%20-%20AdvancedGenericsInterfaces)