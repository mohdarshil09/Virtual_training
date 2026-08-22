using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    public static class Lab1
    {
        public static void Run()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("LAB 1 - Query Syntax vs Method Syntax");
            Console.WriteLine("======================================");

            List<Product> products = new List<Product>
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

            // (a) Fully method syntax
            var methodSyntax = products
                .Where(p => p.Price < 1000)
                .OrderBy(p => p.Name);

            // (b) Fully query syntax
            var querySyntax =
                from p in products
                where p.Price < 1000
                orderby p.Name
                select p;

            // (c) Query syntax WHERE + method syntax OrderBy
            var queryWhereMethodOrder =
                (from p in products
                 where p.Price < 1000
                 select p)
                .OrderBy(p => p.Name);

            // (d) Method syntax WHERE + query syntax orderby
            var methodWhereQueryOrder =
                from p in products.Where(p => p.Price < 1000)
                orderby p.Name
                select p;

            Console.WriteLine("\n(a) Fully Method Syntax:");
            PrintProducts(methodSyntax);

            Console.WriteLine("\n(b) Fully Query Syntax:");
            PrintProducts(querySyntax);

            Console.WriteLine("\n(c) Query WHERE + Method OrderBy:");
            PrintProducts(queryWhereMethodOrder);

            Console.WriteLine("\n(d) Method WHERE + Query OrderBy:");
            PrintProducts(methodWhereQueryOrder);

            bool same =
                methodSyntax.SequenceEqual(querySyntax) &&
                methodSyntax.SequenceEqual(queryWhereMethodOrder) &&
                methodSyntax.SequenceEqual(methodWhereQueryOrder);

            Console.WriteLine($"\nAll four results are identical: {same}");
        }

        private static void PrintProducts(IEnumerable<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine(
                    $"{p.Id,-3} {p.Name,-15} {p.Category,-15} Rs.{p.Price:F2}");
            }
        }
    }
}