using System;
using System.Text.RegularExpressions;

namespace Lab4
{
    public static class PatternLibrary
    {
        // Reusable compiled Regex patterns

        public static readonly Regex Email =
            new Regex(
                @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
                RegexOptions.Compiled
            );

        public static readonly Regex UsPhone =
            new Regex(
                @"^\d{3}-\d{3}-\d{4}$",
                RegexOptions.Compiled
            );

        public static readonly Regex HexColor =
            new Regex(
                @"^#[0-9A-Fa-f]{6}$",
                RegexOptions.Compiled
            );


        // Wrapper methods

        public static bool IsValidEmail(string value)
        {
            return Email.IsMatch(value);
        }

        public static bool IsValidPhone(string value)
        {
            return UsPhone.IsMatch(value);
        }

        public static bool IsValidHexColor(string value)
        {
            return HexColor.IsMatch(value);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO 3: IgnoreCase demonstration

            string helloPattern = "hello";

            bool ignoreCaseOff =
                Regex.IsMatch("HELLO", helloPattern);

            bool ignoreCaseOn =
                Regex.IsMatch(
                    "HELLO",
                    helloPattern,
                    RegexOptions.IgnoreCase
                );

            Console.WriteLine(
                $"IgnoreCase off: {ignoreCaseOff}, " +
                $"IgnoreCase on: {ignoreCaseOn}"
            );


            // TODO 4: Multiline demonstration

            string lines =
                "First line\nSecond line\nThird line";

            string linePattern = @"^";

            MatchCollection withoutMultiline =
                Regex.Matches(lines, linePattern);

            MatchCollection withMultiline =
                Regex.Matches(
                    lines,
                    linePattern,
                    RegexOptions.Multiline
                );

            Console.WriteLine(
                $"Line-start matches WITHOUT Multiline: " +
                $"{withoutMultiline.Count}"
            );

            Console.WriteLine(
                $"Line-start matches WITH Multiline: " +
                $"{withMultiline.Count}"
            );


            // TODO 5: PatternLibrary tests

            Console.WriteLine(
                $"IsValidEmail(\"a@b.com\"): " +
                $"{PatternLibrary.IsValidEmail("a@b.com")}, " +
                $"IsValidEmail(\"not-an-email\"): " +
                $"{PatternLibrary.IsValidEmail("not-an-email")}"
            );

            Console.WriteLine(
                $"IsValidPhone(\"555-123-4567\"): " +
                $"{PatternLibrary.IsValidPhone("555-123-4567")}, " +
                $"IsValidPhone(\"5551234567\"): " +
                $"{PatternLibrary.IsValidPhone("5551234567")}"
            );

            Console.WriteLine(
                $"IsValidHexColor(\"#1A2B3C\"): " +
                $"{PatternLibrary.IsValidHexColor("#1A2B3C")}, " +
                $"IsValidHexColor(\"1A2B3C\"): " +
                $"{PatternLibrary.IsValidHexColor("1A2B3C")}"
            );
        }
    }
}