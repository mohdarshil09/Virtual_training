using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    public class CategorySummary
    {
        public string Category { get; set; }
        public int ItemCount { get; set; }
        public decimal TotalValue { get; set; }
        public string TopProduct { get; set; }
    }

    public static class Lab8
    {
        public static void Run()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("LAB 8 - Comprehensive Mini Report");
            Console.WriteLine("======================================");

            List<Product> products = GetProducts();

            // Query Syntax
            var queryReport =
                from p in products
                where p.InStock
                group p by p.Category into categoryGroup
                let orderedProducts =
                    categoryGroup.OrderByDescending(p => p.Price)
                let totalValue =
                    categoryGroup.Sum(p => p.Price)
                orderby totalValue descending
                select new CategorySummary
                {
                    Category = categoryGroup.Key,
                    ItemCount = categoryGroup.Count(),
                    TotalValue = totalValue,
                    TopProduct = orderedProducts.First().Name
                };

            Console.WriteLine("\nQUERY SYNTAX REPORT");
            PrintReport(queryReport);

            // Method Syntax
            var methodReport =
                products
                    .Where(p => p.InStock)
                    .GroupBy(p => p.Category)
                    .Select(group => new CategorySummary
                    {
                        Category = group.Key,
                        ItemCount = group.Count(),
                        TotalValue = group.Sum(p => p.Price),
                        TopProduct = group
                            .OrderByDescending(p => p.Price)
                            .First()
                            .Name
                    })
                    .OrderByDescending(x => x.TotalValue);

            Console.WriteLine("\nMETHOD SYNTAX REPORT");
            PrintReport(methodReport);

            bool match =
                queryReport.Select(x => x.Category)
                    .SequenceEqual(
                        methodReport.Select(x => x.Category))
                &&
                queryReport.Select(x => x.ItemCount)
                    .SequenceEqual(
                        methodReport.Select(x => x.ItemCount))
                &&
                queryReport.Select(x => x.TotalValue)
                    .SequenceEqual(
                        methodReport.Select(x => x.TotalValue))
                &&
                queryReport.Select(x => x.TopProduct)
                    .SequenceEqual(
                        methodReport.Select(x => x.TopProduct));

            Console.WriteLine(
                $"\nQuery and Method reports match: {match}");
        }

        private static void PrintReport(
            IEnumerable<CategorySummary> report)
        {
            foreach (var category in report)
            {
                Console.WriteLine(
                    "\n--------------------------------------");

                Console.WriteLine(
                    $"Category    : {category.Category}");

                Console.WriteLine(
                    $"Item Count  : {category.ItemCount}");

                Console.WriteLine(
                    $"Total Value : Rs.{category.TotalValue:F2}");

                Console.WriteLine(
                    $"Top Product : {category.TopProduct}");
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