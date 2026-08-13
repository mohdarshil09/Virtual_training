using System;

namespace Lab5
{
    // 1. Method Overloading
    public class Formatter
    {
        // Format(int)
        public string Format(int value)
        {
            return value.ToString();
        }

        // Format(double)
        public string Format(double value)
        {
            return value.ToString("F2");
        }

        // Format(int, int)
        public string Format(int numerator, int denominator)
        {
            return $"{numerator}/{denominator}";
        }
    }


    // 2. Base class
    public class Notifier
    {
        // Virtual method
        public virtual void Send()
        {
            Console.WriteLine("Notifier: generic send");
        }

        // Non-virtual method
        public void Log()
        {
            Console.WriteLine("Notifier: generic log");
        }
    }


    // 3. Derived class
    public class EmailNotifier : Notifier
    {
        // Method overriding
        public override void Send()
        {
            Console.WriteLine("EmailNotifier: sending email");
        }

        // Method hiding
        public new void Log()
        {
            Console.WriteLine("EmailNotifier: logging to email log");
        }
    }


    // 4. Operator Overloading
    public struct Vector2
    {
        public double X, Y;

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Operator +
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(
                a.X + b.X,
                a.Y + b.Y
            );
        }

        // Operator * for scalar multiplication
        public static Vector2 operator *(Vector2 vector, double scalar)
        {
            return new Vector2(
                vector.X * scalar,
                vector.Y * scalar
            );
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------------------
            // 1. METHOD OVERLOADING
            // ---------------------------------------

            Formatter formatter = new Formatter();

            Console.WriteLine(
                $"Format(7) -> \"{formatter.Format(7)}\""
            );

            Console.WriteLine(
                $"Format(3.5) -> \"{formatter.Format(3.5)}\""
            );

            Console.WriteLine(
                $"Format(3, 4) -> \"{formatter.Format(3, 4)}\""
            );


           
            // 2. OVERRIDE VS HIDE

            EmailNotifier email = new EmailNotifier();

            Console.WriteLine();
            Console.WriteLine("-- through EmailNotifier variable --");

            email.Send();
            email.Log();


            // Base-class reference pointing to same object
            Notifier notifier = email;

            Console.WriteLine();
            Console.WriteLine(
                "-- through Notifier variable, same object --"
            );

            notifier.Send();
            notifier.Log();


            
            // 3. OPERATOR OVERLOADING

            Console.WriteLine();

            Vector2 v1 = new Vector2(1, 2);
            Vector2 v2 = new Vector2(3, 4);

            Vector2 sum = v1 + v2;

            Console.WriteLine(
                $"{v1} + {v2} = {sum}"
            );


            Vector2 v3 = new Vector2(2, 2);

            Vector2 scaled = v3 * 3;

            Console.WriteLine(
                $"{v3} * 3 = {scaled}"
            );
        }
    }
}