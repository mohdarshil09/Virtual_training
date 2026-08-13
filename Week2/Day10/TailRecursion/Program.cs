using System;

namespace TailRecursion
{
    internal class Program
    {
        static void Tail(int n)
        {
            // Base Case
            if (n == 0)
                return;

            // Work before recursion
            Console.Write(n + " ");

            // Recursive Call
            Tail(n - 1);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nTail Recursion Output:");

            Tail(number);

            Console.ReadKey();
        }
    }
}
