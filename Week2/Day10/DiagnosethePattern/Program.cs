using System;

namespace DiagnosethePattern
{
    internal class Program
    {
        // Head Recursion
        static void Head(int n)
        {
            if (n == 0)
                return;

            Head(n - 1);
            Console.Write(n + " ");
        }

        // Tail Recursion
        static void Tail(int n)
        {
            if (n == 0)
                return;

            Console.Write(n + " ");
            Tail(n - 1);
        }

        // Tree Recursion
        static int Tree(int n)
        {
            if (n <= 1)
                return 1;

            return Tree(n - 1) + Tree(n - 2);
        }

        // Indirect Recursion
        static void Even(int n)
        {
            if (n == 0)
            {
                Console.WriteLine("Even");
                return;
            }

            Odd(n - 1);
        }

        static void Odd(int n)
        {
            if (n == 0)
            {
                Console.WriteLine("Odd");
                return;
            }

            Even(n - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Head Recursion:");
            Head(5);

            Console.WriteLine("\n");

            Console.WriteLine("Tail Recursion:");
            Tail(5);

            Console.WriteLine("\n");

            Console.WriteLine("Tree Recursion:");
            Console.WriteLine(Tree(5));

            Console.WriteLine();

            Console.WriteLine("Indirect Recursion:");
            Even(5);

            Console.ReadKey();
        }
    }
}
