Introduction
==========

We are ready to start learning about **inheritance**. If you want to [remind yourself some introductory notions about classes and OOP, see this repository](https://github.com/microsoft-dx/csharp-fundamentals/tree/master/CSharpFundamentals/csharp05%20-%20Classes).

> **Inheritance**, together with **encapsulation** and **polymorphism**, is one of the three primary characteristics (or pillars) of object-oriented programming. 

> Inheritance enables you to create new classes that reuse, extend, and modify the behavior that is defined in other classes. The class whose members are inherited is called the base class, and the class that inherits those members is called the derived class. 

> A derived class can have only one direct base class. However, inheritance is transitive. If `ClassC` is derived from `ClassB`, and `ClassB` is derived from `ClassA`, `ClassC` inherits the members declared in `ClassB` and `ClassA`.

> [More from the MSDN Official Documentation](https://msdn.microsoft.com/en-us/library/ms173149.aspx)

If we want to indicate that `Dog`  inherits `Animal`, in C# we write `public class Dog : Animal` and **`Dog` will contain all `public` and `protected` members from `Animal`and all members declared in `Dog`.**

    public class Animal
    {
	    public string Color { get; set; }
	}

Inheritance puts in place an ***IS A*** relationship between the constituents. In the terms of our example, each `Dog` ***IS AN*** `Animal` (and we will later see how we will actually use a `Dog` as an `Animal`).

    public class Dog : Animal
    {
	    public string Breed { get; set; }
	}

So `Dog` will contain `Color` and `Breed`.

The `Animal` class
----------------------
Let's take a look at the full implementation of `Animal`.

     public class Animal
        {
            public string Color { get; set; }
    
            public void Eat(string food)
            {
                Console.WriteLine("{0} animal eating {1}", Color, food);
            }
    
            public Animal()
            {
            }
    
            public Animal(string color)
            {
                Color = color;
            }
        }

We have a public property, `Color` , a public method `Eat` that takes as parameter the name of the food.
We also have two constructors, a parameterless one and one that takes the color of the animal as argument.
Every class that will inherit `Animal` will contain these members (because these members are declared as `public` or `protected` in the base class. Members we define as `private` are accessible only in the scope of the current class).

The `Dog` class
-------------------
Let's look at the implementation of `Dog`.

    public class Dog : Animal
    {
        public string Breed { get; set; }
    
        public void Bark()
        {
            Console.WriteLine("{0} {1} dog barking", Color, Breed);
        }
    
        public Dog()
        {
        }
    
        public Dog(string color, string breed) : base(color)
        {
            Breed = breed;
        }
    }

As said earlier, `Dog` ***inherits*** `Color` and `Eat` from `Animal` and adds `Breed` and `Bark`.

`Dog` also implements two constructors, a default one (parameterless) and a one that takes two `string` arguments: the color and the breed of the dog. 

But if we look again at the constructor from `Animal` we see that we already have written code that sets the color of an `Animal`.

        public Dog(string color, string breed) : base(color)
        {
            Breed = breed;
        }

In this case, we use `: base(color)` to call the constructor from `Animal` that takes a color as parameter and execute it.

So in a `Dog` object we will have access to the `Color`and `Breed` properties and to the `Eat` and `Bark` methods.

> There is also a `Snake` class that inherits from `Animal`, but it is very similar to `Dog`.

The `HuntingDog` class
-------------------------------

We can also have a longer chain of inheritance. So far, we have `Animal` --> `Dog`. Let's see how things react if we add a `HuntingDog` class that inherits 	`Dog`.

    public class HuntingDog : Dog
    {
        public double Speed { get; set; }

        public void Hunt()
        {
            Console.WriteLine("{0} {1} hunting dog hunting with {2} mph speed", Color, Breed, Speed);
        }

        public HuntingDog()
        {
        }

        public HuntingDog(string color, string breed, double speed) : base(color, breed)
        {
            Speed = speed;
        }
    }

`HuntingDog` will have every `public` and `protected` member from `Dog`, in addition to the members it declares.

Since in `HuntingDog` we have three properties, `Color`, `Breed` and `Speed`, we declare a constructor that takes three arguments, and just as we did with `Dog`, we call the constructor from the direct parent - in this case `Dog` - by using the `base` keyword.

> [For more information on how constructors are called and how to call them in the context of inheritance, see this article from DotNet Perls.](http://www.dotnetperls.com/base)

Here is how the inheritance structure looks so far:

![enter image description here](https://tb4hlw.bn1301.livefilestore.com/y3mlK16yIY-Y-iq71sQoBeZ1uSmWAVKvYyTBFyiJF9CbVfQ9tQDVLdMOIXM_tJjRvR2M6ttIsSV8VOnGNxb_VW4S6i32BuZiKpzN-RZpz8MMjp7fvTMLiJtbozbKlb7F2UvkWlbLWJkILH25lgCX6J72g?width=581&height=476&cropmode=none)

Let's recall some theory from the MSDN Documentation:

> Inheritance is **transitive**. If **ClassC** is derived from **ClassB**, and **ClassB** is derived from **ClassA**, **ClassC** inherits the members declared in **ClassB** and **ClassA**.

Translated for our case: `HuntingDog` is derived from `Dog`, and `Dog` is derived from `Animal`. Then, `HuntingDog` inherits the members declared in `Dog` and `Animal`.

This means a `HuntingDog` ***IS A*** `Dog` and `HuntingDog` ***IS AN*** `Animal`.
(It also means that `HuntingDog` ***IS AN*** `Animal`!)

Using the classes
------------------------

So far we created `Animal`, `Dog`, `HuntingDog` and `Snake`. If we want to use them, we can simply instantiate objects of the type we want, not caring that the classes inherit other classes:

		Animal animal = new Animal("green");
	    animal.Eat("food");

        Dog dog = new Dog("blue", "bichon");
        dog.Eat("bones");
        dog.Bark();

        Snake snake = new Snake("yellow", false);
        snake.Bite();

        HuntingDog huntingDog = new HuntingDog("pink", "chihuahua", 120);
        huntingDog.Hunt();

And use them like any other classes.

Using a `Dog` as an `Animal`
-------------------------------------------

Remember earlier when discussing the ***IS A*** relationship we said something about using `Dog` as an `Animal`.

Taken logically, it is safe to say that every `Dog` is also an `Animal`, and this also holds true in our inheritance context,

An `Animal` has `Color` and can `Eat`.
**A `Dog` has every public member from `Animal`** and some specific members.

    Dog dog = new Dog("blue", "bichon");
   
   At this point, in memory we have a `Dog` with `Color` and `Breed` and the ability to `Eat` and `Bark`.

Since every `Dog` is an `Animal`, we are allowed to do the following:

    Animal animal = dog;

Behind the curtains, we simply created a new reference, this time of type `Animal`, that points to the same object in memory.

In the `animal` variable we have a reference to the `dog` object from memory, but **we can only use the capabilities of an `Animal`** (since the `animal` reference is of type `Animal`).

It is important to understand that **we do not modify anything in memory**, **the `dog` object still exists with all its members**. When reference by an `Animal` variable,  the compiler will simply ignore all other members that are not part of `Animal`.

> **A cast operation** between reference types **does not change the run-time type of the underlying object**; **it only changes the type of the value that is being used as a reference to that object.**

This operation is called ***upcasting***, or ***implicit conversion***, and can always be done without doing anything special.

> For reference types, **an implicit conversion always exists from a class to any one of its direct or indirect base classes** or interfaces. 

>No special syntax is necessary because a ***derived class always contains all the members of a base class.***

> [More from the MSDN Official Documentation](https://msdn.microsoft.com/en-us/library/ms173105.aspx)


Let's consider the following method:

        public static void PrintColor(Animal animal)
        {
            Console.WriteLine("The animal is: {0}\n", animal.Color);
        }

Besides any object of type `Animal`, any class that inherits `Animal` can be used as parameter for the `PrintColor` method, because, every object that inherits `Animal` ***IS AN*** `Animal`.

So we are allowed to do: 

    PrintColor(animal);
    PrintColor(dog);
    PrintColor(snake);
    PrintColor(huntingDog);
    
And these method calls will simply print the color of the animals and it will consider them all as simply as objects of type `Animal`.

Creating an array of  `Animal`
-------------------------------------------

We understood that we are able to use a `Dog` as an `Animal`. 
In fact, we established that we can use any type that inherits `Animal` as an `Animal` by ignoring any additional members.

One application of doing this is the fact that we can group multiple objects (**that share a base class!**) in the same collection.

			Animal animal = new Animal("green");
			Dog dog = new Dog("blue", "bichon");
			Snake snake = new Snake("yellow", false);
			HuntingDog huntingDog = new HuntingDog("pink", "chihuahua", 120);

            Animal[] animals = new Animal[]
            {
                animal,
                dog,
                snake,
                huntingDog
            };

Now, we can iterate through the `animals` array, but only use the members from `Animal`.

                foreach (var a in animals)
	                a.Eat("food for animals");

Casting back from `Animal` to `Dog`
------------------------------------------------------

So far we managed to use a `Dog` as an `Animal`. But how about doing the opposite operation?
We know that every `Dog` is an `Animal`, and this is **always** true. Is the reciprocal also true?

Is every `Animal` a `Dog`?  Not necessarily. As in our examples, we can also have a `Snake` which is an `Animal`, but not a `Dog`.

>However, **if a conversion cannot be made without a risk of losing information, the compiler requires that you perform an explicit conversion**, which is called a cast. A cast is a way of explicitly informing the compiler that you intend to make the conversion and that you are aware that data loss might occur. To perform a cast, specify the type that you are casting to in parentheses in front of the value or variable to be converted.

> [More from the MSDN Official Documentation](https://msdn.microsoft.com/en-us/library/ms173105.aspx)


    Dog dog = new Dog("blue", "bichon");
    Animal animal  = dog;

We can only cast an `Animal` to a specific implementation if we know for sure that we are able to do it.
For example, we are able to do the following:

    Dog d = (Dog) animal;

**We simply have a new `Dog` reference to our initial object in memory (which still exists as a `Dog`, but we used it as an `Animal`).**
So we are allowed to do this cast since initially, the object was a `Dog`.

This operation is called **downcasting**.

Are we allowed to do the following?

    Snake s = (Snake) animal;

No, because in memory the object exists as a `Dog` and there is no explicit way of mapping the properties of a `Dog` to those of a `Snake`.

Downcasting is only possible when the object you want to convert was at some point a `Dog`.

We have an additional way of doing downcasting:

    Dog dog = new Dog("blue", "bichon");
    Animal animal  = dog;

	var string = (animal as Dog).Breed;

But again, it only works if the object that `animal` points to is really a `Dog`.


Next
------
Next, we will look at overriding and abstract classes.
