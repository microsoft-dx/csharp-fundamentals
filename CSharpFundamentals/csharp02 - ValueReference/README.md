Passing Parameters to Methods
=========================


The C# types
------------------

In C# there are two kinds of types : reference types and value types.

> There is also a [pointer type](https://msdn.microsoft.com/en-us/library/y31yhkeb.aspx), but it is only used in unsafe contexts

Value types contain the value directly, while the reference types contain a reference to the data.


[Value Types](https://msdn.microsoft.com/en-us/library/s1ax56ch.aspx)
----------------

When passing a variable of value type as parameter, the method receives a **copy** of the original object, **so any modifications made inside the method will not persist.**

Value types consist of all numerical types, `bool`, `enum` and `structs` you define yourself.

> Actually, the main value types are `structs` and `enums`, since the numerical values and the `bool` are implemented as `struct`.
[> Take a look at the implementation of an `int`.](https://msdn.microsoft.com/en-us/library/system.int32%28v=vs.110%29.aspx)

[Reference types](https://msdn.microsoft.com/en-us/library/490f96s2.aspx)
----------------------

When passing a reference type as a parameter, the method receives a copy of the reference, so it will work with the same object, meaning that **any modifications made inside the method will persist.**

Every user-defined class, interface and delegate is passed by reference, and, as we will see in the example, every array is also passed by reference.

>In C#, `string` has a special behavior. **It is passed by reference** and is **immutable** (that is it cannot be modified - behind the scenes, when you modify a `string`, the new value is copied into an another object and your old variable references the new one).


The Code
-------------

   
    using System;
    
    
    namespace ValueReference
    {
        class Program
        {
            static void Main(string[] args)
            {
                int number = 5;
                Console.WriteLine("Initially, the value of the number is: {0}", number);
    
                ModifyNumber(number);
                Console.WriteLine("After calling the ModifyNumber method, the value of number is: {0}", number);
    
                int[] numbers = new int[5];
                Console.WriteLine("Initially, the value of numbers[0] is: {0}", numbers[0]);
    
                ModifyArray(numbers);
                Console.WriteLine("After calling the ModifyArray method, the value of numbers[0] is :{0}", numbers[0]);
            }
    
            public static void ModifyArray(int[] array)
            {
                array[0] = 100;
            }
    
            public static void ModifyNumber(int number)
            {
                number = 1000;
            }
        }
    }


What the first part does
-------------------------
 
 We first declare an `int` that we initialize with the value 5.
Then, we pass it `ModifyNumber` method which modifies the parameter to 1000.

Let's see what happens here. We established that an `int` is a **value type**, so when passed as parameter to a method, the respective **method will receive a copy of the object** that will only be in scope as long as the containing method will. 

This means the assignment to 1000 will be made on a local copy of the parameter, which will be out of scope by the time the method finishes executing.

So in the `Main` method, the value of `number` will be unchanged.


What the second part does
-------------------------


We declare and instantiate a new array of 5 `int`. By default, the compiler initializes each element of the array with the default value of the type, in our case with 0.

Then, we pass the `numbers` array to the `ModifyArray` method.

We established earlier that **arrays are passed by reference**, so any modifications made inside the method will reflect on the original method.

In this case, the method modifies the first element of the array to 100.

Then, we simply print the first element of `numbers` to console to verify our affirmation.


Conclusion
---------------

We saw how passing a parameter of value or reference type influences the desired output, and how modifications made inside a method can be seen (or not) outside that method.