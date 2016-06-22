Method overloading
================

Introduction
-----------------
We continue our learning of the C# language with a new topic: method overloading.

What is method overloading?
-----------------------------------------
[Method overloading (or function overloading)](https://en.wikipedia.org/wiki/Function_overloading) means having multiple methods in the same scope, with the same name, but different signatures (different number of arguments, different types).

Based on the parameters used to call the method, the compiler figures out which one to execute at **compile time.**

> While there are some other things happening with overloading in the inheritance context, we will not get into this subject here, but approach it after having already worked with inheritance.

The important thing to note for overloading is that **two methods cannot differ only by the return type** because when calling one of them, you are calling using the name and the list of parameters and the compiler cannot make the difference between the two.


The Code
-------------

    namespace MethodOverloading
    {
        class Program
        {
            static void Main(string[] args)
            {
                Add(2, 3);
                Add(2, 3, 4);
    
                Add(2.1, 3.0);
                Add(2.0, 3.2, 4.0);
    
                Add(2, 3.0);
                Add(2.0, 3, 4.5);
            }
    
            public static int Add(int a, int b)
            {
                return a + b;
            }
    
            public static int Add(int a, int b, int c)
            {
                return a + b + c;
            }
    
            public static double Add(double a, double b)
            {
                return a + b;
            }
    
            public static double Add(double a, double b, double c)
            {
                return a + b + c;
            }
    
            /*
            public static void Add(int a, int b)
            {
                //Not allowed since two overloaded methods cannot differ only by the return type
            }
            */
        }
    }

The overloaded methods
-----------------------------------

Here you can see multiple `Add` methods that take `int` and `double` and add the two values.

        public static int Add(int a, int b)
        {
            return a + b;
        }
When called with two `int` parameters, the compiler will execute the above method.

`Add(2, 3);`

        public static int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        Add(2, 3, 4);

These two methods are overloaded : they have a different number of parameters, so based on the number of arguments used to call, the compiler will choose the appropriate one.


Now let's introduce the `Add` method that takes two `double` parameters.

        public static double Add(double a, double b)
        {
            return a + b;
        }
        
       Add(2.1, 3.2);

If called with two `double` arguments, you have no problem. But what happens if we do:

    Add(1, 4.6);

The `Add(double a, double b)` method gets executed, since there is an implicit cast from `int` to `double`.

You can also create a method:

    public static double Add(int a, double b)
    {
    	return a + b;
    }
This way, not implicit cast gets made.

        public static double Add(double a, double b, double c)
        {
            return a + b + c;
        }
        
    Add(2.0, 3.2, 4.5);
	Add(2.0, 3, 4.5);
Both of these calls will get mapped to the `Add(double a, double b, double c)` method.


Two overloaded methods cannot differ only by the return type
---------------------------------------------------------------------------------------

Consider the following methods:

    public static void Add(int a, int b)
    {
        return a + b;
    }


    public static int Add(int a, int b)
    {
        return a + b;
    }

Can these two methods exist in the same scope? Let's see how we call them: 

    Add(1,2);
    
We call them exactly the same, so the compiler has no idea which we want to execute.
