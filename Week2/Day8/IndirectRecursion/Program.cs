using System;

/// <summary>
/// Demonstrates Indirect Recursion.
/// One function calls another function,
/// which again calls the first function.
/// </summary>
class IndirectRecursion
{
    /// <summary>
    /// Checks if the number is Even.
    /// </summary>
    /// <param name="n">Current number.</param>
    static void IsEven(int n)
    {
        // Base Case
        if (n == 0)
        {
            Console.WriteLine("The number is Even.");
            return;
        }

        // Call another function
        IsOdd(n - 1);
    }

    /// <summary>
    /// Checks if the number is Odd.
    /// </summary>
    /// <param name="n">Current number.</param>
    static void IsOdd(int n)
    {
        // Base Case
        if (n == 0)
        {
            Console.WriteLine("The number is Odd.");
            return;
        }

        // Call first function again
        IsEven(n - 1);
    }

    /// <summary>
    /// Entry point of the program.
    /// </summary>
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nChecking Number...");

        // Start recursion
        IsEven(number);

        Console.ReadKey();
    }
}