using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    public class ProductSummaryDto
    {
        public string Name { get; set; }
        public string PriceLabel { get; set; }
    }

    public static class Lab2
    {
        public static void Run()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("LAB 2 - Select Projections");
            Console.WriteLine("======================================");

            List<Product> products = GetProducts();

            // 1. Project only names
            IEnumerable<string> names =
                products.Select(p => p.Name);

            Console.WriteLine("\n1. Product Names:");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            // 2. Anonymous type with PriceWithTax
            var priceWithTax =
                products.Select(p => new
                {
                    p.Name,
                    PriceWithTax = p.Price * 1.18m
                });

            Console.WriteLine("\n2. Name and Price With 18% Tax:");

            foreach (var item in priceWithTax)
            {
                Console.WriteLine(
                    $"{item.Name,-15} Rs.{item.PriceWithTax:F2}");
            }

            // 3. Named DTO
            var summaries =
                products.Select(p => new ProductSummaryDto
                {
                    Name = p.Name,
                    PriceLabel = $"Rs.{p.Price:F2}"
                });

            Console.WriteLine("\n3. ProductSummaryDto:");

            foreach (var item in summaries)
            {
                Console.WriteLine(
                    $"{item.Name,-15} {item.PriceLabel}");
            }

            // 4. Index-aware Select
            var indexedProducts =
                products.Select((p, index) =>
                    $"#{index + 1}: {p.Name}");

            Console.WriteLine("\n4. Index-Aware Select:");

            foreach (var item in indexedProducts)
            {
                Console.WriteLine(item);
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