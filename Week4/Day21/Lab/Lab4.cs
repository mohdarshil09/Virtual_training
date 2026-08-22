
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    public abstract class Shape
    {
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }

    public static class Lab4
    {
        public static void Run()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("LAB 4 - OfType<T>");
            Console.WriteLine("======================================");

            // 1. Mixed object list
            List<object> mixedList = new List<object>
            {
                10,
                "Hello",
                20,
                3.14,
                new Product
                {
                    Id = 1,
                    Name = "Keyboard",
                    Category = "Electronics",
                    Price = 999,
                    InStock = true
                },
                "LINQ",
                new Product
                {
                    Id = 2,
                    Name = "Mouse",
                    Category = "Electronics",
                    Price = 499,
                    InStock = true
                },
                99.5
            };

            var integers = mixedList.OfType<int>();
            var strings = mixedList.OfType<string>();
            var productList = mixedList.OfType<Product>();

            Console.WriteLine("\n1. OfType<int>:");
            foreach (var item in integers)
                Console.WriteLine(item);

            Console.WriteLine("\nOfType<string>:");
            foreach (var item in strings)
                Console.WriteLine(item);

            Console.WriteLine("\nOfType<Product>:");
            foreach (var item in productList)
                Console.WriteLine(item.Name);

            // 2. Shape list
            List<Shape> shapes = new List<Shape>
            {
                new Circle(5),
                new Rectangle(4, 6),
                new Circle(3),
                new Rectangle(10, 2),
                new Circle(2)
            };

            double totalCircleArea =
                shapes
                    .OfType<Circle>()
                    .Sum(c => Math.PI * c.Radius * c.Radius);

            double totalRectangleArea =
                shapes
                    .OfType<Rectangle>()
                    .Sum(r => r.Width * r.Height);

            Console.WriteLine("\n2. Shape Areas:");
            Console.WriteLine($"Total Circle Area: {totalCircleArea:F2}");
            Console.WriteLine(
                $"Total Rectangle Area: {totalRectangleArea:F2}");

            // 3. OfType vs Cast
            Console.WriteLine("\n3. OfType<Rectangle>:");

            var rectangles = shapes.OfType<Rectangle>();

            foreach (var rectangle in rectangles)
            {
                Console.WriteLine(
                    $"Rectangle: {rectangle.Width} x {rectangle.Height}");
            }

            Console.WriteLine("\nCast<Rectangle>:");

            try
            {
                var castRectangles =
                    shapes.Cast<Rectangle>();

                foreach (var rectangle in castRectangles)
                {
                    Console.WriteLine(
                        $"Rectangle: {rectangle.Width} x {rectangle.Height}");
                }
            }
            catch (InvalidCastException)
            {
                Console.WriteLine(
                    "InvalidCastException caught: " +
                    "The list contains a Circle, which cannot be cast to Rectangle.");
            }
        }
    }
}