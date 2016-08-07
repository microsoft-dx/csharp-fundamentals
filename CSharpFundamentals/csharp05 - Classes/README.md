Introduction to OOP and Classes
----------------------------------------------
One of the base concepts of OOP (Object Oriented Programming) is the concept of a class.


What is a class?
----------------------

> In the real world, you'll often find many individual objects all of the same kind. There may be thousands of other bicycles in existence, all of the same make and model. Each bicycle was built from the same set of blueprints and therefore contains the same components. In object-oriented terms, we say that your bicycle is an instance of the class of objects known as bicycles. **A class is the blueprint from which individual objects are created.** 
> [More information from the Oracle documentation here.](https://docs.oracle.com/javase/tutorial/java/concepts/class.html)

> **A class is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events.** A class is like a blueprint. It defines the data and behavior of a type.
> [More information from the Microsoft documentation here.](https://msdn.microsoft.com/en-us/library/x9afc042.aspx)

As both sources state, a class is like a blueprint from which you can create your own defined objects - called **instances of the class**.

> The real world can be accurately described as a collection of objects that interact.

Classes are essentially templates from which you can create objects. Each object contains data and has methods to manipulate and access that data (members). The class defines what data and what behavior each particular object (called instance) of a class can contain.


[Members](https://msdn.microsoft.com/en-us/library/ms173113.aspx)
-------------

A class can contain fields - **data members** -  which define the state of the object - and **method members** - which are used to make operations using the state of the object.

The data and functions within a class are known as class members. In C#, there is a distinction between data and methods. In addition to these members, classes can also contain other objects like instances of other classes.


When to choose OOP?
-------------------------------
OOP can help you modularize the code.
 **Each class will solve one particular type of problem**, and all attributes and methods will be part of that class.

> Assumptions: 
>   1. Describing large, complex systems as interacting objects make them easier to understand than otherwise. 
>   2. The behaviors of real world objects tend to be stable over time. 
>   3. The different kinds of real world objects tend to be stable. (That is, new kinds appear slowly;  old kinds disappear slowly.) 
>   4. Changes tend to be localized to a few objects.
> [More from the source here.](http://www.cs.olemiss.edu/~hcc/csci581oo/notes/OOintro.html)

When these assumptions are met, then an object-oriented approach for your application might be suitable.

> The need for object-oriented design and the following of [SOLID principles](https://en.wikipedia.org/wiki/SOLID_%28object-oriented_design%29) will be covered in a separate topic.


Declaring a class in C#
------------------------------
```csharp
public class Person
{

}
```

You define a class using the `class` keyword, preceded by the access level (in our case `public`), and followed by the name of the class.


Properties
--------------
> A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field. Properties can be used as if they are public data members, but they are actually special methods called accessors. This enables data to be accessed easily and still helps promote the safety and flexibility of methods.
>
> [More on properties on the official MSDN documentation.](https://msdn.microsoft.com/en-us/library/x9fsa0sw.aspx)

The three members declared in the class

```csharp
public string FirstName { get; set; }

public string LastName { get; set; }

public int Age { get; set; }
```

are a special kind of members called properties (to be more precise, they are [auto-implemented properties](https://msdn.microsoft.com/ro-ro/library/bb384054.aspx)).

While data members are used to hold data, and method members are used to make operations based on the data members, auto-implemented properties are kind of in the middle.

Let's think for a moment at how we would write this class in Java. (I excluded the `Print` method and the constructors)

```java
public class Person
{
    private String firstName;
    private String lastName;
    private Integer age;			

    public String getFirstName(){
        return this.firstName;
    }

    public void setFirstName(String firstName) {
        //some validation
        this.firstName = firstName;
    }

    public String getLastName() {
        return this.lastName;
    }

    public void setLastName(String lastName) {
        //some validation
        this.lasttName = lastName;
    }

    public Integer getAge() {
        return this.age;
    }

    public void setAge(Integer age) {
        //some validation
        this.age = age;
    }
}
```

The best practice in Java is to have private fields (`firstName`, `lastName`, `age`) and public methods for getting and setting the values of the fields called `getter` and `setter`, and they are used in order for entities outside the class not to modify the fields directly, but have an additional layer (where you can do validation for example).

This is exactly what the C# auto-implemented properties do. 

> When you declare a property as shown in the following example, the compiler creates a private, anonymous backing field that can only be accessed through the property's get and set accessors.
>
>[More on auto-implemented properties on the official MSDN documentation.](https://msdn.microsoft.com/ro-ro/library/bb384054.aspx)

Behind the scenes, when you declare an auto-implemented property, the compiler creates a private field that can be accessed through the `get` and `set` methods you define in the property, **making the code a lot easier to read and maintain.**

>The compiler creates backing fields for each auto-implemented property. The fields are not accessible directly from source code.
>
> [For more examples on implementing properties, visit this resource.](https://msdn.microsoft.com/en-us/library/w86s7x04.aspx)

You can initialize auto-implemented properties in the following way:

```csharp
public string FirstName { get; set; } = "Jane";
```

but from our coding convention, the best way is to initialize them in a constructor like this: 

```csharp
public class Person
{
    public string FirstName { get; set; }

    public Person()
    {
        FirstName = "Jane";
    }
}
```


Instantiating an object of the Person class
-----------------------------------------------------------

We created the class, now we want to use it - create objects of the class type.

```csharp
Person person = new Person();
```

`person` is called an **instance** of the `Person` class, and it is created using a **constructor**.

Now, we can start using the class members of the `Person` class and give specific values to them, individualizing this instance of the class.

```csharp
person.FirstName = "Isaac";
person.LastName = "Newton";
```

> Note that when we do this, we actually execute the `set` method declared on the auto-implemented properties `FirstName` and `LastName`.


Constructors
-----------------

A constructor is a method that does not have a return type (it does not return `void`!), it has the same name as the class and it is used to create new objects and initialize values for the class members.

```csharp
public Person()
{

}
```

The easiest implementation for a constructor is the one above. It does nothing special, but allocate memory for the class data members, initializing them with the default value for their types.

This constructor gets called when instantiating a new object of type `Person` without parameters.

```csharp
Person person = new Person();
```

> This type of constructor - called parameterless constructor - or default constructor - is generated automatically by the compiler (only when we do not create custom constructors that have parameters!)

Another type of constructor is one that has arguments for the data members.

```csharp
public Person(string firstName, string lastName, int age)
{
    FirstName = firstName;
    LastName = lastName;
    Age = age;
}
```

This constructor can be used when we want to create a new object and initialize its properties.

```csharp
Person newton = new Person("Isaac", "Newton", 373);
```

> Note that if we create this type of parameter, we are required to also create the default constructor, since it will not get generated by the compiler!


Method members
-------------------------

We can also create method members - methods that **can be accessed using the instance name and operate with the specific data members of each instance.**

In our example, we have the `PrintPerson` method.

```csharp
public void PrintPerson()
{
    Console.WriteLine("First Name: {0}, Last Name: {1}, Age: {2}",
        FirstName, 
        LastName, 
        Age
    );
}
```

It simply prints the details of the person on the console, but does it specifically for every instance of the class.

```csharp
Person newton = new Person("Isaac", "Newton", 373);

person.PrintPerson();
```

This will have the output:

`First Name: Isaac, Last Name: Newton, Age: 373`


OOP Paradigms
----------------------

-   **Encapsulation** – in object-oriented programming, encapsulation means **limiting the access to some data** and allowing the programmer to implement the desired level of abstraction.
Encapsulation keywords
-	**Public** – the information can be accessed and modified from outside
-	**Protected** – the information can be accessed and modified by all children of the class
-	**Private** – the information cannot be accessed or modified from outside

As we continue working with C# and OOP, we will further discuss encapsulation, but in other words, encapsulation is all about hiding complex implementation details and only exposing the minimum necessary elements needed to use some code.

> For a more complete discussion about encapsulation, [view this Microsoft Virtual Academy lecture.](https://mva.microsoft.com/en-US/training-courses/a-guide-to-object-oriented-practices-14329?l=NnQrzk2hB_7804668937)

- **Inheritance** – **allows us to create a new class, based on an existing one**. 

	We will call the class that is inherited from the **base class(parent class)**, and the class that inherits **inherited class(child class)**.
	
	When a class inherits another a base class, **it inherits all the public and protected members** (data and methods).

> [For a complete discussion about inheritance, see this article.](https://github.com/microsoft-dx/csharp-fundamentals/tree/master/CSharpFundamentals/csharp06%20-%20Inheritance)


 -  **Polymorphism** is often referred to as the third pillar of object-oriented programming, after **encapsulation** and **inheritance**. Polymorphism is a Greek word that means "many-shaped" and it has two distinct aspects:
>More on polymorphism in the [method overriding article](https://github.com/microsoft-dx/csharp-fundamentals/tree/master/CSharpFundamentals/csharp07%20-%20Overriding) and on the [Official MSDN Documentation](https://msdn.microsoft.com/en-us/library/ms173152.aspx).

- At run time, objects of a derived class may be treated as objects of a base class in places such as method parameters and collections or arrays. When this occurs, the object's declared type is no longer identical to its run-time type.

- Base classes may define and implement virtual methods, and derived classes can override them, which means they provide their own definition and implementation. At run-time, when client code calls the method, the CLR looks up the run-time type of the object, and invokes that override of the virtual method. Thus in your source code you can call a method on a base class, and cause a derived class's version of the method to be executed.
