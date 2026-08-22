using System;
using System.Collections.Generic;

class Lab7
{
    static void Main()
    {
        Console.WriteLine("===== LAB 7 =====");

        // =========================
        // Integer Stack
        // =========================

        FixedSizeStack<int> stack =
            new FixedSizeStack<int>(3);

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine("\nStack top-to-bottom:");

        foreach (int item in stack)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(
            $"\nCount: {stack.Count}");

        Console.WriteLine(
            $"Peek: {stack.Peek()}");

        Console.WriteLine(
            $"Pop: {stack.Pop()}");

        Console.WriteLine(
            $"Peek after Pop: {stack.Peek()}");

        // =========================
        // Full Stack Exception
        // =========================

        Console.WriteLine(
            "\nTesting Push when full:");

        try
        {
            stack.Push(40);
            stack.Push(50);
            stack.Push(60);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(
                $"Exception caught: {ex.Message}");
        }

        // =========================
        // Empty Stack Exceptions
        // =========================

        Console.WriteLine(
            "\nTesting Pop when empty:");

        try
        {
            stack.Pop();
            stack.Pop();
            stack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(
                $"Exception caught: {ex.Message}");
        }

        Console.WriteLine(
            "\nTesting Peek when empty:");

        try
        {
            stack.Peek();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(
                $"Exception caught: {ex.Message}");
        }

        // =========================
        // Extension Method
        // =========================

        List<string> names =
            new List<string>
            {
                "Aman",
                "Rahul",
                "Karan"
            };

        FixedSizeStack<string> nameStack =
            names.ToFixedSizeStack(3);

        Console.WriteLine(
            "\nList<string> converted to FixedSizeStack:");

        foreach (string name in nameStack)
        {
            Console.WriteLine(name);
        }
    }
}