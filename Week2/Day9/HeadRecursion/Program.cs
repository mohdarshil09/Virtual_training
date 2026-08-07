using System;

namespace HeadRecursion
{
    internal class Program
    {
        static void Head(int n)
        {
            // Base Case
            if (n == 0)
                return;

            // Recursive Call
            Head(n - 1);

            // Work after recursion
            Console.Write(n + " ");
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nHead Recursion Output:");

            Head(number);

            Console.ReadKey();
        }
    }
}