using System;
using System.Collections.Generic;

class Program
{
    // Generic callback-based processing method

    static void ProcessBatch<T>(
        List<T> items,
        Action<T> onSuccess,
        Action<T, string> onFailure,
        Func<T, bool> validator)
    {
        foreach (T item in items)
        {
            if (validator(item))
            {
                onSuccess(item);
            }
            else
            {
                onFailure(
                    item,
                    "Validation failed."
                );
            }
        }
    }


    static void Main()
    {
        Console.WriteLine("===== LAB 8 =====");


        // Integer batch

        List<int> numbers = new List<int>
        {
            10,
            -5,
            20,
            -2,
            30
        };

        Console.WriteLine("\nInteger Batch:");

        ProcessBatch(
            numbers,

            number =>
                Console.WriteLine(
                    $"Success: {number}"),

            (number, reason) =>
                Console.WriteLine(
                    $"Failure: {number} - {reason}"),

            number => number >= 0
        );


        // String batch

        List<string> names = new List<string>
        {
            "Arshil",
            "",
            "Capgemini",
            "   ",
            "CSharp"
        };

        Console.WriteLine("\nString Batch:");

        ProcessBatch(
            names,

            name =>
                Console.WriteLine(
                    $"Success: '{name}'"),

            (name, reason) =>
                Console.WriteLine(
                    $"Failure: '{name}' - {reason}"),

            name =>
                !string.IsNullOrWhiteSpace(name)
        );
    }
}