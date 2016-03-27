Hello C#
=======

Introduction to C#
-------------------------

When first starting to learn most programming languages, the first example you are introduced is ["Hello, World!"](https://en.wikipedia.org/wiki/%22Hello,_World!%22_program), since it is a very simple program that only prints a `string` to the console.

The purpose of it is to make sure the machine can actually run the code and to show the developer how to print a `string` on the console.

The Code
-------------

    using System;
    
    namespace HelloWorld
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello, Universe!");
            }
        }
    }


Namespaces
-----------------
Namespaces are a way to group related classes and help you organize classes. 

They provide a logical manner in which to organize your code and while it is considered good practice that your namespaces correspond to the actual folders in your file system, you are not required to do so.

They also allow you to have multiple classes with the same name, but in different namespaces.

If you want to use classes from other namespaces, you simply specify them with a `using` statement.

The `using` keyword
-------------------------------

The `using` keyword specifies a namespace where the compiler should search for any classes that might be used in your code.

It has the same purpose as the `import` statement in Java and`using namespace` in C++.

`using System;`
-------------------------

The first line of code is `using System;`. The reason for that is because we are going to use a library class called `System.Console`, and the `using System;` statement allows us to refer to it simply as `Console`.

Without this statement, every time you needed to print something on the console, you would have to call the full name, that is `System.Console.WriteLine()`.

C# code and classes
----------------------------

All C# code must be inside a class. You cannot have executable code living outside the definition of a class.

When you are creating a console application, Visual Studio creates a class for you named `Program.cs`.

The class declaration consists of the `class` keyword, followed by the name of the class and braces. The code must be inside the braces.

We will discuss more about classes later. For now, it is enough to remember that all C# code must live inside a class.

The `Main` method
----------------------------
The `Main` method is the entry point of a C# console application  and there can only be one entry point in an application.

> Note: You can have multiple classes with a `Main` method, but you have to specify which one is going to be used as entry point.

`static void Main(string[] args)`

The `static` keyword in a method specifies that you can call the method without having an instance of that class. 

We established that you need an entry point into your program. Since `Main` is going to be this entry point, it means that you can call it before instantiating an object of type `Program`.

> More on static methods, classes and instantiating objects later.

One of the possible arguments for the `Main` method is `string[] args`. It is an array of `string` and can contain any number of command line arguments to pass when executing the program.


Printing a string to the console
--------------------------------------------

    Console.WriteLine("Hello, Universe!");

	
Here, we simply call the `WriteLine` method from the `Console` class that resides in the `System` namespace.

It will print the `string` we provide as parameter to the console.

> We are able to call methods without instantiating an object of the
> class first because this is a static method.