using System;

namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== C# LINQ LABS =====");
            Console.WriteLine("1. Lab 1 - Query Syntax vs Method Syntax");
            Console.WriteLine("2. Lab 2 - Select Projections");
            Console.WriteLine("3. Lab 3 - Where Filtering");
            Console.WriteLine("4. Lab 4 - OfType<T>");
            Console.WriteLine("5. Lab 5 - OrderBy / ThenBy");
            Console.WriteLine("6. Lab 6 - GroupBy and into");
            Console.WriteLine("7. Lab 7 - Deferred vs Immediate Execution");
            Console.WriteLine("8. Lab 8 - Comprehensive Mini Report");

            Console.Write("\nEnter Lab Number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Lab1.Run();
                    break;

                case 2:
                    Lab2.Run();
                    break;

                case 3:
                    Lab3.Run();
                    break;

                case 4:
                    Lab4.Run();
                    break;

                case 5:
                    Lab5.Run();
                    break;

                case 6:
                    Lab6.Run();
                    break;

                case 7:
                    Lab7.Run();
                    break;

                case 8:
                    Lab8.Run();
                    break;

                default:
                    Console.WriteLine("Invalid lab number.");
                    break;
            }
        }
    }
}