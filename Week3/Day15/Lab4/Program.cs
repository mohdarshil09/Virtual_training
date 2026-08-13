using System;

namespace Lab4
{
    // Static class
    public static class StringUtils
    {
        public static bool IsPalindrome(string s)
        {
            string reversed = Reverse(s);
            return s == reversed;
        }

        public static string Reverse(string s)
        {
            char[] characters = s.ToCharArray();
            Array.Reverse(characters);

            return new string(characters);
        }

        public static int WordCount(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            return s.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries
            ).Length;
        }
    }

    // Normal instance class
    public class TrackedWidget
    {
        // Instance property
        // Every object gets its own InstanceId
        public Guid InstanceId { get; }

        // Static property
        // Shared by ALL TrackedWidget objects
        public static int LiveCount { get; private set; }

        public TrackedWidget()
        {
            InstanceId = Guid.NewGuid();
            LiveCount++;
        }

        public void Dispose()
        {
            LiveCount--;
        }

        public void PrintInfo()
        {
            Console.WriteLine(
                $"Widget {InstanceId}: LiveCount={LiveCount}"
            );
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------
            // StringUtils
            // -------------------------

            Console.WriteLine(
                $"IsPalindrome(\"racecar\") -> " +
                $"{StringUtils.IsPalindrome("racecar")}"
            );

            Console.WriteLine(
                $"Reverse(\"Hello\") -> " +
                $"{StringUtils.Reverse("Hello")}"
            );

            Console.WriteLine(
                $"WordCount(\"the quick brown fox\") -> " +
                $"{StringUtils.WordCount("the quick brown fox")}"
            );

            // This does NOT compile because StringUtils is static:
            // StringUtils utils = new StringUtils();

            Console.WriteLine(
                "(new StringUtils() would not compile)"
            );


            // -------------------------
            // TrackedWidget
            // -------------------------

            TrackedWidget widget1 = new TrackedWidget();
            TrackedWidget widget2 = new TrackedWidget();
            TrackedWidget widget3 = new TrackedWidget();

            Console.WriteLine(
                $"LiveCount after creating 3 widgets: " +
                $"{TrackedWidget.LiveCount}"
            );

            //widget1.PrintInfo();
            //widget2.PrintInfo();
            //widget3.PrintInfo();


            // Dispose two widgets
            widget1.Dispose();
            widget2.Dispose();

            Console.WriteLine(
                $"LiveCount after disposing 2: " +
                $"{TrackedWidget.LiveCount}"
            );
        }
    }
}