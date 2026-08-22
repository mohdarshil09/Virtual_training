using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    public static class Lab5
    {
        public static void Run()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("LAB 5 - OrderBy / ThenBy");
            Console.WriteLine("======================================");

            List<Product> products = GetProducts();

            // 1. Correct multi-key sort
            var correctSort =
                products
                    .OrderBy(p => p.Category)
                    .ThenByDescending(p => p.Price);

            Console.WriteLine(
                "\n1. Category Ascending + Price Descending:");

            PrintProducts(correctSort);

            // 2. Bug version
            var bugSort =
                products
                    .OrderBy(p => p.Category)
                    .OrderBy(p => p.Price);

            Console.WriteLine(
                "\n2. BUG: OrderBy(Category).OrderBy(Price):");

            PrintProducts(bugSort);

            // The second OrderBy becomes the new primary ordering.
            // Therefore, Category ordering is lost.

            // 3. Fixed version
            var fixedSort =
                products
                    .OrderBy(p => p.Category)
                    .ThenBy(p => p.Price);

            Console.WriteLine(
                "\n3. FIXED: OrderBy(Category).ThenBy(Price):");

            PrintProducts(fixedSort);

            // 4. Three-key sort
            var threeKeySort =
                products
                    .OrderByDescending(p => p.InStock)
                    .ThenBy(p => p.Category)
                    .ThenBy(p => p.Name);

            Console.WriteLine(
                "\n4. InStock -> Category -> Name:");

            PrintProducts(threeKeySort);
        }

        private static void PrintProducts(IEnumerable<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine(
                    $"{p.Name,-15} {p.Category,-15} Rs.{p.Price,-8:F2} " +
                    $"{(p.InStock ? "In Stock" : "Out of Stock")}");
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