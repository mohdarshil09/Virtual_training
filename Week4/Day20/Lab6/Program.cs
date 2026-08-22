using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; } = "";
    public double Price { get; set; }
    public double DiscountPercent { get; set; }
    public bool InStock { get; set; }

    public double DiscountedPrice
    {
        get
        {
            return Price * (1 - DiscountPercent / 100);
        }
    }
}


class Order
{
    public int OrderId { get; set; }
    public string Customer { get; set; } = "";
    public double Total { get; set; }
}


class Program
{
    static void PrintProducts(List<Product> products)
    {
        foreach (Product product in products)
        {
            Console.WriteLine(
                $"{product.Name} | " +
                $"Price: {product.Price:F2} | " +
                $"Discounted: {product.DiscountedPrice:F2} | " +
                $"In Stock: {product.InStock}");
        }
    }


    static void Main()
    {
        Console.WriteLine("===== LAB 6 =====");


        // 1. Expression-bodied lambda

        Func<double, double, double> rectangleArea =
            (w, h) => w * h;

        Console.WriteLine(
            $"Rectangle Area: {rectangleArea(10, 5)}");


        // 2. Statement-bodied lambda

        Action<Order> printReceipt = order =>
        {
            Console.WriteLine("\n----- RECEIPT -----");
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Customer: {order.Customer}");
            Console.WriteLine($"Total: {order.Total:F2}");
            Console.WriteLine("-------------------");
        };

        Order order = new Order
        {
            OrderId = 101,
            Customer = "Arshil",
            Total = 1250
        };

        printReceipt(order);


        // Products

        List<Product> products = new List<Product>
        {
            new Product
            {
                Name = "Laptop",
                Price = 80000,
                DiscountPercent = 10,
                InStock = true
            },

            new Product
            {
                Name = "Mouse",
                Price = 1000,
                DiscountPercent = 20,
                InStock = true
            },

            new Product
            {
                Name = "Keyboard",
                Price = 3000,
                DiscountPercent = 15,
                InStock = false
            }
        };


        Console.WriteLine("\nOriginal products:");

        PrintProducts(products);


        // 3. Sort by price ascending

        products.Sort(
            (a, b) => a.Price.CompareTo(b.Price)
        );

        Console.WriteLine("\nPrice Ascending:");

        PrintProducts(products);


        // Sort by name descending

        products.Sort(
            (a, b) => string.Compare(
                b.Name,
                a.Name,
                StringComparison.OrdinalIgnoreCase)
        );

        Console.WriteLine("\nName Descending:");

        PrintProducts(products);


        // Sort by discounted price

        products.Sort(
            (a, b) =>
                a.DiscountedPrice.CompareTo(
                    b.DiscountedPrice)
        );

        Console.WriteLine(
            "\nDiscounted Price Ascending:");

        PrintProducts(products);


        // 4. Remove out-of-stock products

        int removed = products.RemoveAll(
            product => !product.InStock
        );

        Console.WriteLine(
            $"\nRemoved products: {removed}");

        Console.WriteLine("\nAfter RemoveAll:");

        PrintProducts(products);
    }
}