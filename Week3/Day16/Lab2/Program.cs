using System;
using System.Text.RegularExpressions;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO 1: Matches + IgnoreCase
            string text =
                "Order #4521 was shipped. order   #99 is pending. " +
                "ORDER #12345 was cancelled.";

            string orderPattern = @"Order\s+#(\d+)";

            MatchCollection orders =
                Regex.Matches(text, orderPattern, RegexOptions.IgnoreCase);

            Console.Write("Order numbers found: ");

            for (int i = 0; i < orders.Count; i++)
            {
                Console.Write(orders[i].Groups[1].Value);

                if (i < orders.Count - 1)
                    Console.Write(", ");
            }

            Console.WriteLine();


            // TODO 2: Replace to mask all but the last 4 digits
            string cardText = "Card on file:   4111-1111-1111-1234";

            string cardPattern = @"\b(\d{4})[- ](\d{4})[- ](\d{4})[- ](\d{4})\b";

            string maskedCard = Regex.Replace(
                cardText,
                cardPattern,
                "XXXX-XXXX-XXXX-$4"
            );

            Console.WriteLine($"Masked card: {maskedCard.Substring(maskedCard.IndexOf("XXXX"))}");


            // TODO 3: Replace with capturing groups
            string names = "Smith, John";

            string namePattern = @"^([^,]+),\s*(.+)$";

            string reformattedName = Regex.Replace(
                names,
                namePattern,
                "$2 $1"
            );

            Console.WriteLine($"Reformatted name: {reformattedName}");


            // TODO 4: Split into clean array of trimmed tags
            string tags = "red, blue;green , yellow";

            string[] rawTags = Regex.Split(tags, @"[,;]");

            Console.Write("Tags: [");

            for (int i = 0; i < rawTags.Length; i++)
            {
                string cleanTag = rawTags[i].Trim();

                Console.Write(cleanTag);

                if (i < rawTags.Length - 1)
                    Console.Write(", ");
            }

            Console.WriteLine("]");
        }
    }
}