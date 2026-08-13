using System;

namespace Lab1
{
    // Struct
    public struct RgbColor
    {
        public byte R, G, B;

        public RgbColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        // Print color as #RRGGBB
        public override string ToString()
        {
            return $"#{R:X2}{G:X2}{B:X2}";
        }
    }

    // Enum
    public enum NamedColor
    {
        Red,
        Green,
        Blue,
        White,
        Black
    }

    // Class
    public class Pixel
    {
        public RgbColor Color;
    }

    internal class Program
    {
        // Convert NamedColor to RgbColor
        static RgbColor FromNamed(NamedColor name)
        {
            switch (name)
            {
                case NamedColor.Red:
                    return new RgbColor(255, 0, 0);

                case NamedColor.Green:
                    return new RgbColor(0, 255, 0);

                case NamedColor.Blue:
                    return new RgbColor(0, 0, 255);

                case NamedColor.White:
                    return new RgbColor(255, 255, 255);

                case NamedColor.Black:
                    return new RgbColor(0, 0, 0);

                default:
                    throw new ArgumentException("Invalid color");
            }
        }

        static void Main(string[] args)
        {
            
            // STRUCT COPY
           

            Console.WriteLine("-- struct copy --");

            RgbColor a = FromNamed(NamedColor.Red);

            // Copy struct
            RgbColor b = a;

            // Modify b
            b.R = 1;

            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");


            
            // CLASS / REFERENCE COPY
            

            Console.WriteLine();
            Console.WriteLine("-- class/reference copy --");

            Pixel p1 = new Pixel();

            p1.Color = FromNamed(NamedColor.Green);

            // Copy reference
            Pixel p2 = p1;

            // Modify p2
            p2.Color = new RgbColor(0, 255, 0);

            Console.WriteLine($"p1.Color = {p1.Color}");
            Console.WriteLine($"p2.Color = {p2.Color}");
        }
    }
}