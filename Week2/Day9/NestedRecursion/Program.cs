using System;

namespace NestedRecursion
{
    internal class Program
    {
        static int Fun(int n)
        {
            // Base Case
            if (n > 100)
                return n - 10;

            // Nested Recursive Call
            return Fun(Fun(n + 11));
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int result = Fun(number);

            Console.WriteLine("\nResult = " + result);

            Console.ReadKey();
        }
    }
}
