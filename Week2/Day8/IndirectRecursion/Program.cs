using System;

namespace IndirectRecursion
{
    internal class Program
    {
        // Handles positive numbers
        static bool IsPositiveChain(int n)
        {
            // Base Case
            if (n == 0)
                return true;

            if (n < 0)
                return false;

            // Alternate by moving to the negative chain
            return IsNegativeChain(n - 1);
        }

        // Handles negative numbers
        static bool IsNegativeChain(int n)
        {
            // Base Case
            if (n == 0)
                return true;

            if (n > 0)
                return false;

            // Alternate by moving to the positive chain
            return IsPositiveChain(n + 1);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            bool result;

            if (number >= 0)
                result = IsPositiveChain(number);
            else
                result = IsNegativeChain(number);

            Console.WriteLine("Reaches Zero: " + result);

            Console.ReadKey();
        }
    }
}

// ﻿using System;

// /// <summary>
// /// Demonstrates Indirect Recursion.
// /// One function calls another function,
// /// which again calls the first function.
// /// </summary>
// class IndirectRecursion
// {
//     /// <summary>
//     /// Checks if the number is Even.
//     /// </summary>
//     /// <param name="n">Current number.</param>
//     static void IsEven(int n)
//     {
//         // Base Case
//         if (n == 0)
//         {
//             Console.WriteLine("The number is Even.");
//             return;
//         }

//         // Call another function
//         IsOdd(n - 1);
//     }

//     /// <summary>
//     /// Checks if the number is Odd.
//     /// </summary>
//     /// <param name="n">Current number.</param>
//     static void IsOdd(int n)
//     {
//         // Base Case
//         if (n == 0)
//         {
//             Console.WriteLine("The number is Odd.");
//             return;
//         }

//         // Call first function again
//         IsEven(n - 1);
//     }

//     /// <summary>
//     /// Entry point of the program.
//     /// </summary>
//     static void Main()
//     {
//         Console.Write("Enter a number: ");
//         int number = Convert.ToInt32(Console.ReadLine());

//         Console.WriteLine("\nChecking Number...");

//         // Start recursion
//         IsEven(number);

//         Console.ReadKey();
//     }
}
