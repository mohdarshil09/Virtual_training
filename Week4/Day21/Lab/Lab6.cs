using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    public static class Lab6
    {
        public static void Run()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("LAB 6 - GroupBy and into");
            Console.WriteLine("======================================");

            List<Product> products = GetProducts();

            // 1. Group by Category
            var groups =
                products.GroupBy(p => p.Category);

            Console.WriteLine("\n1. Category Counts:");

            foreach (var group in groups)
            {
                Console.WriteLine(
                    $"{group.Key}: {group.Count()} products");
            }

            // 2. Group + into + where + orderby
            var largeCategories =
                from p in products
                group p by p.Category into categoryGroup
                where categoryGroup.Count() >= 3
                orderby categoryGroup.Sum(p => p.Price) descending
                select categoryGroup;

            Console.WriteLine(
                "\n2. Categories With 3 Or More Products:");

            foreach (var group in largeCategories)
            {
                Console.WriteLine(
                    $"{group.Key} -> Rs.{group.Sum(p => p.Price):F2}");
            }

            // 3. Aggregations
            Console.WriteLine("\n3. Detailed Category Report:");

            foreach (var group in groups)
            {
                int count = group.Count();

                decimal totalValue =
                    group.Sum(p => p.Price);

                decimal averagePrice =
                    group.Average(p => p.Price);

                Product expensiveProduct =
                    group.OrderByDescending(p => p.Price)
                         .First();

                Console.WriteLine($"\nCategory: {group.Key}");
                Console.WriteLine($"Count: {count}");
                Console.WriteLine(
                    $"Total Value: Rs.{totalValue:F2}");
                Console.WriteLine(
                    $"Average Price: Rs.{averagePrice:F2}");
                Console.WriteLine(
                    $"Most Expensive: {expensiveProduct.Name}");
            }

            // 4. Composite key
            var compositeGroups =
                products.GroupBy(p => (p.Category, p.InStock));

            Console.WriteLine("\n4. Category + InStock:");

            foreach (var group in compositeGroups)
            {
                Console.WriteLine(
                    $"Category: {group.Key.Category}, " +
                    $"InStock: {group.Key.InStock}, " +
                    $"Count: {group.Count()}");
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