using System;

namespace TreeRecursion
{
    internal class Program
    {
        static int CountPaths(int rows, int cols)
        {
            // Base Case
            if (rows == 1 || cols == 1)
                return 1;

            // Tree Recursion
            return CountPaths(rows - 1, cols) + CountPaths(rows, cols - 1);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of columns: ");
            int cols = Convert.ToInt32(Console.ReadLine());

            int paths = CountPaths(rows, cols);

            Console.WriteLine($"\nNumber of Paths = {paths}");

            Console.ReadKey();
        }
    }
}
