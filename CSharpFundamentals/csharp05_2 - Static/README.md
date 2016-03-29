The `static` keyword
===================

In general, the `static` keyword denotes an entity that is not bound to an instance. You can have `static` data members (fields, methods, properties) and `static` classes.

> Use the static modifier to declare a static member, which belongs to the type itself rather than to a specific object. The static modifier can be used with classes, fields, methods, properties, operators, events, and constructors, but it cannot be used with indexers, destructors, or types other than classes. 

>[More information on the MSDN documentation](https://msdn.microsoft.com/en-us/library/98f28cdx.aspx)

Instance data members
------------------------------------

Every time you create an object (which is called an instance of a class), each of these objects will have their own data, which can be accessed through the instance name, as we saw in the previous [example for creating and using classes.](https://github.com/microsoft-dx/csharp-fundamentals/tree/master/CSharpFundamentals/csharp05%20-%20Classes)

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person()
        {
        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void PrintPerson()
        {
            Console.WriteLine("First Name: {0}, Last Name: {1}, Age: {2}", FirstName, LastName, Age);
        }
    }
At this point, we can instantiate an object of the `Person` type and assign some values for the properties.

	Person newton = new Person("Isaac", "Newton", 373);

Using the `newton` instance, **we can access the specific properties for this object using the instance name**:

	Console.WriteLine(newton.FirstName);

Or we can execute the member methods:

    newton.PrintPerson();
   
   Which will print on the console the specific information about the `newton` instance.

`static` data members
-----------------------------------
Let us consider the same class, this time with a static property called `Count`.


    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public static int Count { get; private set; }

        public Person()
        {
            Count++;
        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;

            Count++;
        }

        public void PrintPerson()
        {
            Console.WriteLine("First Name: {0}, Last Name: {1}, Age: {2}", FirstName, LastName, Age);
        }

        public static void PrintCount()
        {
            Console.WriteLine("Number of persons: {0}", Count);
        }
    }
    
This property will increment each time a new instance of the `Person` class is created, so we increment the property in both constructors.

> Since we increment the `Count` property in the constructors, it would seem natural to decrement it in a destructor. 

>But since C# is part of the .NET framework, it means it operates in a managed environment where you don't have to worry about destroying objects and it's the [Garbage Collector](https://msdn.microsoft.com/en-us/library/0xy59wtx%28v=vs.110%29.aspx)'s job to destroy objects. 

Being static, it means that this property **is not part of a specific instance**, but it identifies a single memory location. No matter how many instances of the class are created, there is only one copy of a static field, which is created when the program starts.

Accessing a `static` member
--------------------------------------------

While accessing instance members (`FirstName`) is done through the instance name (`newton.FirstName` - natural since the `FirstName` is specific to each instance), **accessing a `static` member is done through the class name itself.**

And this is rather logical, since a property like `Count` is not specific to a single instance, but is linked and has meaning when considered with the class.

Since the `static` members are created when the program starts, it means we can use them even before instantiating an object of the class.


    Console.WriteLine(Person.Count); //prints 0
    Person newton = new Person(firstName: "Isaac", lastName: "Newton", age: 373);
    Console.WriteLine(Person.Count); // prints 1


`static` methods
----------------------------

As is the case with `static` data members, `static` methods are not part of any instance, but can be accessed just like a `static` data member, through the name of the class.

It is important to understand that because a `static` method is not part of an instance, it will not have access to the instance members of the class.

Let's take a look at the `static` method `PrintCount`, which simply print the number of `Person` objects to the console.


        public static void PrintCount()
        {
            Console.WriteLine("Number of persons: {0}", Count);
        }

We can also call this method before instantiating a `Person` object,  using the name of the class.

`Person.PrintCount();`

If we tried to access or modify an instance member of the class it will give you an error, because **a `static` method cannot access or modify instance members** since it is not part of an instance.


`static` classes
--------------------------

A `static` class is basically the same as a non-`static` class, but with one major difference: **a `static` class cannot be instantiated**. In other words, you cannot use the new keyword to create a variable of the class type, and can only have static members.

Because there is no instance of this class, you can access the members of a static class through the class name.

A good example for using static classes represents utility classes, used for grouping related methods that do not operate on an instance. As example, we will consider a class called `MathUtilities` that will have some math-related methods.


    public static class MathUtilities
    {
        public static int Square(int number)
        {
            return number * number;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }
    }

We execute the static methods using the class name:

            Console.WriteLine(MathUtilities.Square(7));
            Console.WriteLine(MathUtilities.Multiply(3, 5));


`static` classes: 
--------------------------

- contain only static members
- cannot be instantiated
- are sealed (**you cannot inherit from a static class**)
