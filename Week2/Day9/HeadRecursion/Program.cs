using System;

namespace HeadRecursionExample
{
    internal class Program
    {
        static void SumDigitsReversed(int n)
        {
            // Base Case
            if (n == 0)
                return;

            // Recursive Call
            SumDigitsReversed(n / 10);

            // Print digit while returning
            Console.Write(n % 10 + " ");
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nDigits in Reverse Order:");

            SumDigitsReversed(number);

            Console.ReadKey();
        }
    }
}
