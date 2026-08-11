using System;

class Lab1
{
    static void Main()
    {
        // Original string
        string original = "  Hello, Training Team!  ";

        // TODO 1: Trim the string into a new variable
        string trimmed = original.Trim();

        // TODO 2: Compare original and trimmed
        Console.WriteLine(
            "ReferenceEquals(original, trimmed): " +
            object.ReferenceEquals(original, trimmed)
        );

        // TODO 3: Contains / StartsWith / IndexOf / Replace

        // Check whether string contains "Training"
        Console.WriteLine(
            "Contains \"Training\": " +
            trimmed.Contains("Training")
        );

        // Check whether string starts with "Hello"
        Console.WriteLine(
            "StartsWith trimmed \"Hello\": " +
            trimmed.StartsWith("Hello")
        );

        // Find index of first comma
        Console.WriteLine(
            "Index of first comma: " +
            trimmed.IndexOf(',')
        );

        // Replace "Training Team" with "Engineering Team"
        string replaced = trimmed.Replace(
            "Training Team",
            "Engineering Team"
        );

        Console.WriteLine(
            "\"Training Team\" replaced -> " + replaced
        );

        // TODO 4: Split into words
        string[] words = trimmed.Split(
            new char[] { ' ', ',' },
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        // TODO 5: IsNullOrWhiteSpace checks

        string nullString = null;
        string emptyString = "";
        string spaces = "   ";
        string okString = "ok";

        Console.WriteLine(
            "IsNullOrWhiteSpace(null): " +
            string.IsNullOrWhiteSpace(nullString)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"\"): " +
            string.IsNullOrWhiteSpace(emptyString)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"   \"): " +
            string.IsNullOrWhiteSpace(spaces)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"ok\"): " +
            string.IsNullOrWhiteSpace(okString)
        );

        // Bonus Challenge
        string str1 = "HELLO";
        string str2 = "hello";

        int result = string.Compare(
            str1,
            str2,
            StringComparison.OrdinalIgnoreCase
        );

        Console.WriteLine(
            "Compare HELLO and hello: " + result
        );

        // Result is 0 because comparison ignores uppercase/lowercase.
    }
}