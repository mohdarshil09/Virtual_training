using System;
using System.Collections.Generic;

namespace Lab5
{
    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }

    public class Order
    {
        // Get-only: assigned through constructor
        public string OrderId { get; }

        public Address? ShipTo { get; set; }

        // Automatically starts with an empty list
        public List<string> Items { get; set; } = new();

        public decimal Total { get; set; }

        public Order(string orderId)
        {
            OrderId = orderId;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // One object-initializer expression
            Order order1 = new Order("ORD-1")
            {
                ShipTo = new Address
                {
                    Street = "123 Main Street",
                    City = "Springfield",
                    ZipCode = "62701"
                },

                Items =
                {
                    "Laptop",
                    "Mouse"
                },

                Total = 59.98m
            };

            Console.WriteLine(
                $"Order {order1.OrderId} ships to {order1.ShipTo?.City} " +
                $"with {order1.Items.Count} items, Total=${order1.Total:F2}"
            );


            // Second Order with no shipping address
            Order order2 = new Order("ORD-2")
            {
                Total = 25.00m
            };

            if (order2.ShipTo == null)
            {
                Console.WriteLine(
                    $"Order {order2.OrderId} has no shipping address set " +
                    $"(ShipTo is null)"
                );
            }
        }
    }
}