The `ref` keyword
=========

Passing value types parameters to methods
-------------------------

We saw in the [previous example](https://github.com/microsoft-dx/csharp-fundamentals/tree/master/CSharpFundamentals/csharp02%20-%20ValueReference) how passing a value type to a method actually works: **the method actually receives a copy of the object**, so any **modifications made inside the method will not persist.**

But what happens if we want to modify a value type parameter inside a method?

The `ref` keyword
-------------------------

The `ref` keyword **allows you to pass a value type parameter by reference**, meaning that the method will work with the actual reference to the object used as parameter, so **modifications made inside the method will actually persist.**

The Code
-------------

    using System;
    
    namespace RefKeyword
    {
        class Program
        {
            static void Main(string[] args)
            {
                int number = 3;
                Increment(number);
                Console.WriteLine("After calling the Increment method, the value of number is: {0}", number);
    
                int num = 0;
                ReferenceIncrement(ref num);
                Console.WriteLine("After calling the ReferenceIncrement method, the value of num is: {0}", num);
            }
    
            public static void Increment(int number)
            {
                number = number + 1;
            }
    
            public static void ReferenceIncrement(ref int number)
            {
                number = number + 1;
            }
        }
    }


What the first part of the code does
--------------------------------------------------

We first create an `int` and initialize it with the value 3. Then, we pass it as a parameter to the `Increment` method that, well, increments the value of the parameter received.

But since an `int` is passed by value, the new value assigned to the parameter will not persist in the `Main` method context.



What the second part of the code does
------------------------------------------------------

Let's have a look at the `ReferenceIncrement` method.

    public static void ReferenceIncrement(ref int number)
    {
        number = number + 1;
    }

It accepts a `ref int` as parameter, returns `void` and increments the parameter it received. But since that parameter was passed with the `ref` keyword,  the modification is made on the actual parameter in memory, which is what happens when passing a reference type parameter to a method.


When calling the method, it is enough to call it by adding the `ref` keyword before the parameter and it will be passed by reference.