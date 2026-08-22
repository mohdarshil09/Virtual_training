using System;
using Microsoft.CSharp.RuntimeBinder;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== LAB 1 =====");

        // 1. Same value using var, explicit type, and dynamic

        var count = 10;
        int countExplicit = 10;
        dynamic countDynamic = 10;

        Console.WriteLine($"var value: {count}");
        Console.WriteLine($"var type: {count.GetType()}");

        Console.WriteLine($"Explicit value: {countExplicit}");
        Console.WriteLine($"Explicit type: {countExplicit.GetType()}");

        Console.WriteLine($"dynamic value: {countDynamic}");
        Console.WriteLine($"dynamic type: {countDynamic.GetType()}");


        // 2. Dynamic runtime exception

        try
        {
            countDynamic = "now text";

            // This is checked at runtime because countDynamic is dynamic.
            Console.WriteLine(countDynamic + 5);
        }
        catch (RuntimeBinderException ex)
        {
            Console.WriteLine($"Runtime exception caught: {ex.Message}");
        }


        // 3. Anonymous type

        var point = new
        {
            X = 3,
            Y = 7
        };

        Console.WriteLine($"\nPoint X: {point.X}");
        Console.WriteLine($"Point Y: {point.Y}");

        // point.X = 10;
        // Compiler error: Property 'X' is read-only.


        /*
         4. dynamic vs var

         var should normally be used when the type is known at compile time
         because it provides compile-time type safety. dynamic is useful when
         working with data whose type or structure is determined at runtime,
         such as COM objects or dynamically shaped data.
        */
    }
}