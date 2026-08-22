using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    public static class Lab7
    {
        public static void Run()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("LAB 7 - Deferred vs Immediate Execution");
            Console.WriteLine("======================================");

            // 1. Deferred execution
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Keyboard",
                    Category = "Electronics",
                    Price = 999,
                    InStock = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Mouse",
                    Category = "Electronics",
                    Price = 499,
                    InStock = true
                }
            };

            var deferredQuery =
                products.Where(p => p.Price < 1000);

            Console.WriteLine("\n1. Deferred Execution");
            Console.WriteLine("Query built.");

            products.Add(new Product
            {
                Id = 3,
                Name = "USB Cable",
                Category = "Electronics",
                Price = 299,
                InStock = true
            });

            Console.WriteLine(
                "New matching product added.");

            Console.WriteLine("\nQuery result:");

            foreach (var product in deferredQuery)
            {
                Console.WriteLine(product.Name);
            }

            // 2. Immediate execution
            List<Product> snapshotProducts = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Keyboard",
                    Category = "Electronics",
                    Price = 999,
                    InStock = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Mouse",
                    Category = "Electronics",
                    Price = 499,
                    InStock = true
                }
            };

            var snapshot =
                snapshotProducts
                    .Where(p => p.Price < 1000)
                    .ToList();

            Console.WriteLine("\n2. Immediate Execution Using ToList()");
            Console.WriteLine("Snapshot created.");

            snapshotProducts.Add(new Product
            {
                Id = 3,
                Name = "USB Cable",
                Category = "Electronics",
                Price = 299,
                InStock = true
            });

            Console.WriteLine(
                "New product added after ToList().");

            Console.WriteLine("\nSnapshot result:");

            foreach (var product in snapshot)
            {
                Console.WriteLine(product.Name);
            }

            // 3. Double enumeration
            Console.WriteLine("\n3. Double Enumeration:");

            var expensiveLookingQuery =
                GetProducts().Where(p =>
                {
                    Console.WriteLine(
                        $"Checking {p.Name}");

                    return p.Price < 1000;
                });

            Console.WriteLine("\nFirst enumeration:");

            foreach (var product in expensiveLookingQuery)
            {
                Console.WriteLine($"Result: {product.Name}");
            }

            Console.WriteLine("\nSecond enumeration:");

            foreach (var product in expensiveLookingQuery)
            {
                Console.WriteLine($"Result: {product.Name}");
            }

            // Fix
            Console.WriteLine("\n4. Fixed Using ToList():");

            var materialized =
                GetProducts()
                    .Where(p =>
                    {
                        Console.WriteLine(
                            $"Checking {p.Name}");

                        return p.Price < 1000;
                    })
                    .ToList();

            Console.WriteLine("\nFirst enumeration:");

            foreach (var product in materialized)
            {
                Console.WriteLine($"Result: {product.Name}");
            }

            Console.WriteLine("\nSecond enumeration:");

            foreach (var product in materialized)
            {
                Console.WriteLine($"Result: {product.Name}");
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