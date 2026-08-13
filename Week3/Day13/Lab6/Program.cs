using System;
using System.Collections.Generic;

namespace Lab6
{
    // 1. Enum
    public enum ShapeKind
    {
        Circle,
        Rectangle,
        Triangle
    }


    // 2. Abstract base class
    public abstract class Shape
    {
        public ShapeKind Kind { get; protected set; }

        public abstract double Area();

        public abstract double Perimeter();

        public override string ToString()
        {
            return $"{Kind}: Area={Area():F2}, Perimeter={Perimeter():F2}";
        }
    }


    // 3. Circle
    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
            Kind = ShapeKind.Circle;
        }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }


    // 4. Rectangle
    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
            Kind = ShapeKind.Rectangle;
        }

        public override double Area()
        {
            return Width * Height;
        }

        public override double Perimeter()
        {
            return 2 * (Width + Height);
        }
    }


    // 5. Triangle
    public class Triangle : Shape
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            Kind = ShapeKind.Triangle;
        }

        public override double Area()
        {
            // Heron's formula
            double s = (A + B + C) / 2;

            return Math.Sqrt(
                s * (s - A) * (s - B) * (s - C)
            );
        }

        public override double Perimeter()
        {
            return A + B + C;
        }
    }


    // 6. BoundingBox struct
    public struct BoundingBox
    {
        public double Width;
        public double Height;

        public BoundingBox(double w, double h)
        {
            Width = w;
            Height = h;
        }

        // Operator overloading
        public static BoundingBox operator *(
            BoundingBox box,
            double factor)
        {
            return new BoundingBox(
                box.Width * factor,
                box.Height * factor
            );
        }

        public override string ToString()
        {
            return $"({Width:0.##}, {Height:0.##})";
        }
    }


    // 7. ShapeMath
    public static class ShapeMath
    {
        // Total area of all shapes
        public static double TotalArea(IEnumerable<Shape> shapes)
        {
            double total = 0;

            foreach (Shape shape in shapes)
            {
                total += shape.Area();
            }

            return total;
        }


        // Total area of a specific shape type
        public static double TotalArea(
            IEnumerable<Shape> shapes,
            ShapeKind onlyKind)
        {
            double total = 0;

            foreach (Shape shape in shapes)
            {
                if (shape.Kind == onlyKind)
                {
                    total += shape.Area();
                }
            }

            return total;
        }
    }


    // Driver
    internal class Program
    {
        static void Main(string[] args)
        {
            // 8. Create mixed list of shapes
            List<Shape> shapes = new List<Shape>
            {
                new Circle(3),
                new Rectangle(4, 6),
                new Triangle(3, 4, 5)
            };


            // Print each shape using polymorphism
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
            }


            // Total area of all shapes
            double totalArea = ShapeMath.TotalArea(shapes);

            Console.WriteLine();
            Console.WriteLine(
                $"Total area (all shapes): {totalArea:F2}"
            );


            // Total area of circles only
            double circleArea = ShapeMath.TotalArea(
                shapes,
                ShapeKind.Circle
            );

            Console.WriteLine(
                $"Total area (circles only): {circleArea:F2}"
            );


            // BoundingBox operator overload
            BoundingBox box = new BoundingBox(4, 3);

            BoundingBox scaledBox = box * 2;

            Console.WriteLine();
            Console.WriteLine(
                $"Scaled bounding box {box} * 2 -> {scaledBox}"
            );
        }
    }
}