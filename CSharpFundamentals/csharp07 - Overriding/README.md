Overriding
=========

Introduction
-----------------

We [started learning about inheritance in the previous project](https://github.com/microsoft-dx/csharp-fundamentals/tree/master/CSharpFundamentals/csharp06%20-%20Inheritance) where we created an inheritance structure made of `Animal`, `Dog`, `HuntingDog` and `Snake`.

In that project we demonstrated how to create base and derived classes and the properties of inheritance.

We also began to see a basic form of *[polymorphism](https://msdn.microsoft.com/en-us/library/ms173152.aspx)* - using objects of a derived class as objects of the base class.

> At run time, objects of a derived class may be treated as objects of a base class in places such as method parameters and collections or arrays. When this occurs, the object's declared type is no longer identical to its run-time type.

> [More from the Official MSDN Documentation](https://msdn.microsoft.com/en-us/library/ms173152.aspx)

Overriding
--------------

In this project, we have the same inheritance structure, but a little simplified: we only have: `Animal` --> `Dog`, `Snake`.

 >Overriding is a language feature that **allows a subclass or child class to provide a specific implementation of a method that is already provided by one of its superclasses or parent classes.**

> The implementation in the subclass overrides (replaces) the implementation in the superclass by providing a method that has same name, same parameters or signature, and same return type as the method in the parent class. 

>**The version of a method that is executed will be determined by the object that is used to invoke** it.

>If an object of a parent class is used to invoke the method, then the version in the parent class will be executed, but if an object of the subclass is used to invoke the method, then the version in the child class will be executed.

> [More from Wikipedia - Method overriding](https://en.wikipedia.org/wiki/Method_overriding)


**Overriding** - principle that allows you to **change the functionality of a method in a child class** – methods in the inherited class with the same name and same parameters as in the base class, but with different behavior and implementation, with the use of the `virtual` keyword (in C#).


Let's analyze our case and see why we would want to use overriding.

In the last project, we had objects of type `Animal`, `Dog`, `HuntingDog` and `Snake`.
But regardless of the type of the object, since all of them inherit `Animal`, when we called the `Eat` method, this was executed every time:

    Console.WriteLine("{0} animal eating {1}", Color, food); 

What if we would like to still have the same method name and parameters, but have different functionality for some (or all) classes in the inheritance structure?

In other words, when I execute `Eat` on a `Dog` I want a specific output for a `Dog`, when I execute `Eat` on a `Snake` I want specific output for a `Snake` and so on.


Implementing method overriding in C#
--------------------------------------------------------

In order to implement method overriding in C# there are two steps we need to follow:

1. When implementing the method in the base class, we need to add the `virtual` keyword. 

2. When implementing the method in the child class, we need to add the `override` keyword.

>When dealing with inheritance, one must understand the difference between using `override` and `new`. 

>For more information about this, [read this article](https://msdn.microsoft.com/en-us/library/6fawty39.aspx) and [this article from MSDN.](https://msdn.microsoft.com/en-us/library/ms173153.aspx)



The `Animal` class
-----------------------------

Let's have a look at a simplified version  of the `Animal` class (the constructors are missing because they don't add anything new to this topic, but they are still present in the repository):

    public class Animal
    {
        public string Color { get; set; }

        public virtual void Eat(string food)
        {
            Console.WriteLine("{0} animal eating {1}", Color, food);
        }
    }

We said earlier that we want the `Eat` method to have specific functionality for every class that inherits `Animal`. So, according to our two steps, we added the `virtual` modifier to the method.

The `Dog` class
-----------------------

    public class Dog : Animal
    {
        public string Breed { get; set; }

        public override void Eat(string food)
        {
            Console.WriteLine("{0} {1} dog eating {2}", Color, Breed, food);
        }

        public void Bark()
        {
            Console.WriteLine("{0} {1} dog barking", Color, Breed);
        }
    }

The second step requires us to create the `Eat` method in the `Dog` class with the same name and parameters, adding the `override` modifier.

This completes the overriding of the `Eat` method and will enable the use of the specific version of the method accordingly, based on the object calling the method.


Testing the code
-----------------------

    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal("green");
            Dog dog = new Dog("blue", "bichon");
            Snake snake = new Snake("yellow", false);
            
            Console.WriteLine("\nArray of animals eating: ");
            Animal[] animals = new Animal[] 
            {
                animal,
                dog,
                snake
            };

            foreach (var a in animals)
                a.Eat("food for everybody");
        }
    }

Basically, at the core we have the same structure for testing our implementation: we instantiate some objects, all of types inheriting from `Animal`, put them in an array, iterate through it and execute the common method - `Eat`.

But this time, because we used overriding, when we do:

            foreach (var a in animals)
                a.Eat("food for everybody");
the output will be specific for each `Animal` type.
             
(_Knowledge from the last project_):
Even though we treat each object as an `Animal`, they still exist as the specific type they were created with.

So when we call `a.Eat("something")`, we actually call the specific implementation of the overridden method, allowing us to have specific functionality for each child class.
