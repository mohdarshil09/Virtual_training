using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    public static class Lab3
    {
        public static void Run()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("LAB 3 - Where Filtering");
            Console.WriteLine("======================================");

            List<Product> products = GetProducts();

            // 1. Products under Rs.500
            var under500 =
                products.Where(p => p.Price < 500);

            Console.WriteLine("\n1. Products Under Rs.500:");
            PrintProducts(under500);
            Console.WriteLine($"Count: {under500.Count()}");

            // 2. Category AND InStock
            string category = "Electronics";

            var categoryAndStock =
                products.Where(p =>
                    p.Category == category && p.InStock);

            Console.WriteLine(
                $"\n2. {category} Products In Stock:");

            PrintProducts(categoryAndStock);
            Console.WriteLine($"Count: {categoryAndStock.Count()}");

            // 3. Index-aware Where
            var evenPositions =
                products.Where((p, index) =>
                    index % 2 == 0);

            Console.WriteLine(
                "\n3. Products At Even Positions:");

            PrintProducts(evenPositions);
            Console.WriteLine($"Count: {evenPositions.Count()}");

            // 4. Two Where calls
            var twoWhere =
                products
                    .Where(p => p.Price < 1000)
                    .Where(p => p.InStock);

            // One Where with &&
            var oneWhere =
                products.Where(p =>
                    p.Price < 1000 && p.InStock);

            Console.WriteLine("\n4. Two Where Calls:");
            PrintProducts(twoWhere);

            Console.WriteLine("\nOne Where With &&:");
            PrintProducts(oneWhere);

            Console.WriteLine(
                $"\nResults identical: {twoWhere.SequenceEqual(oneWhere)}");
        }

        private static void PrintProducts(IEnumerable<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine(
                    $"{p.Id,-3} {p.Name,-15} {p.Category,-15} Rs.{p.Price:F2}");
            }
        }

        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 999, InStock = true },
                new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 499, InStock = true },
                new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 8999, InStock = false },
                new Product { Id = 4, Name = "Headphones", Category = "Electronics", Price = 1499, InStock = true },
                new Product { Id = 5, Name = "Notebook", Category = "Stationery", Price = 199, InStock = true },
                new Product { Id = 6, Name = "Pen", Category = "Stationery", Price = 49, InStock = true },
                new Product { Id = 7, Name = "Backpack", Category = "Stationery", Price = 799, InStock = false },
                new Product { Id = 8, Name = "Shirt", Category = "Clothing", Price = 899, InStock = true },
                new Product { Id = 9, Name = "Jeans", Category = "Clothing", Price = 1499, InStock = false },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 2499, InStock = true },
                new Product { Id = 11, Name = "Bottle", Category = "Accessories", Price = 299, InStock = true },
                new Product { Id = 12, Name = "Wallet", Category = "Accessories", Price = 699, InStock = false }
            };
        }
    }
}