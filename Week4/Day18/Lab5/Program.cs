using System;
using System.Collections.Generic;
using System.Linq;

class Lab5
{
    static void Main()
    {
        Console.WriteLine("===== LAB 5 =====");

        // HashSet is used because duplicate customers
        // should automatically be removed.

        HashSet<string> NewsletterSubscribers =
            new HashSet<string>
            {
                "a@gmail.com",
                "b@gmail.com",
                "c@gmail.com",
                "d@gmail.com"
            };

        HashSet<string> AppUsers =
            new HashSet<string>
            {
                "b@gmail.com",
                "c@gmail.com",
                "e@gmail.com",
                "f@gmail.com"
            };

        // Intersection
        HashSet<string> both =
            new HashSet<string>(NewsletterSubscribers);

        both.IntersectWith(AppUsers);

        Console.WriteLine("\nBoth Subscriber and App User:");

        foreach (string email in both)
        {
            Console.WriteLine(email);
        }

        // Difference
        HashSet<string> subscribersOnly =
            new HashSet<string>(NewsletterSubscribers);

        subscribersOnly.ExceptWith(AppUsers);

        Console.WriteLine(
            "\nSubscribers but not App Users:");

        foreach (string email in subscribersOnly)
        {
            Console.WriteLine(email);
        }

        // Union
        HashSet<string> allCustomers =
            new HashSet<string>(NewsletterSubscribers);

        allCustomers.UnionWith(AppUsers);

        Console.WriteLine("\nAll Unique Customers:");

        foreach (string email in allCustomers)
        {
            Console.WriteLine(email);
        }

        // Subset
        bool isSubset =
            NewsletterSubscribers.IsSubsetOf(AppUsers);

        Console.WriteLine(
            $"\nNewsletterSubscribers subset of AppUsers: {isSubset}");

        // Deduplication
        List<string> emails = new List<string>();

        Random random = new Random();

        for (int i = 0; i < 100; i++)
        {
            int number = random.Next(1, 51);

            emails.Add($"customer{number}@gmail.com");
        }

        HashSet<string> uniqueEmails =
            new HashSet<string>(emails);

        int duplicatesRemoved =
            emails.Count - uniqueEmails.Count;

        Console.WriteLine("\nDeduplication:");
        Console.WriteLine($"Original emails: {emails.Count}");
        Console.WriteLine($"Unique emails: {uniqueEmails.Count}");
        Console.WriteLine(
            $"Duplicates removed: {duplicatesRemoved}");
    }
}