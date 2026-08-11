using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

static class StringToolkit
{
    // 1. Reverse a string
    public static string Reverse(string input)
    {
        StringBuilder result = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            result.Append(input[i]);
        }

        return result.ToString();
    }


    // 2. Count occurrences of a character
    public static int CountChar(string text, char searchChar)
    {
        int count = 0;

        foreach (char c in text)
        {
            if (c == searchChar)
            {
                count++;
            }
        }

        return count;
    }


    // 3. Remove duplicate characters
    public static string RemoveDuplicates(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (!result.ToString().Contains(c.ToString()))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }


    // 4. Check palindrome ignoring case and spaces
    public static bool IsPalindrome(string input)
    {
        // Remove spaces and convert to lowercase
        string cleaned = input
            .Replace(" ", "")
            .ToLower();

        int left = 0;
        int right = cleaned.Length - 1;

        while (left < right)
        {
            if (cleaned[left] != cleaned[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }


    // 5. Convert string to Title Case
    public static string ToTitleCase(string input)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        return textInfo.ToTitleCase(input.ToLower());
    }


    // 6. Extract only digits
    public static string ExtractNumbers(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }


    // Bonus: Word frequency
    public static Dictionary<string, int> WordFrequency(string text)
    {
        Dictionary<string, int> frequency =
            new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase
            );

        StringBuilder cleaned = new StringBuilder();

        // Replace punctuation with spaces
        foreach (char c in text)
        {
            if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
            {
                cleaned.Append(c);
            }
            else
            {
                cleaned.Append(' ');
            }
        }

        string[] words = cleaned
            .ToString()
            .Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries
            );

        foreach (string word in words)
        {
            if (frequency.ContainsKey(word))
            {
                frequency[word]++;
            }
            else
            {
                frequency[word] = 1;
            }
        }

        return frequency;
    }
}


class Program
{
    static void Main()
    {
        // Reverse
        Console.WriteLine(
            "Reverse(\"Hello\") -> " +
            StringToolkit.Reverse("Hello")
        );


        // CountChar
        Console.WriteLine(
            "CountChar(\"banana\", 'a') -> " +
            StringToolkit.CountChar("banana", 'a')
        );


        // RemoveDuplicates
        Console.WriteLine(
            "RemoveDuplicates(\"mississippi\") -> " +
            StringToolkit.RemoveDuplicates("mississippi")
        );


        // IsPalindrome
        Console.WriteLine(
            "IsPalindrome(\"race car\") -> " +
            StringToolkit.IsPalindrome("race car")
        );


        // ToTitleCase
        Console.WriteLine(
            "ToTitleCase(\"hello training team\") -> " +
            StringToolkit.ToTitleCase("hello training team")
        );


        // ExtractNumbers
        Console.WriteLine(
            "ExtractNumbers(\"Order #4521, qty 3\") -> " +
            StringToolkit.ExtractNumbers("Order #4521, qty 3")
        );


        // Bonus
        Console.WriteLine();
        Console.WriteLine("Word Frequency:");

        Dictionary<string, int> result =
            StringToolkit.WordFrequency(
                "Hello world! Hello C# world."
            );

        foreach (var item in result)
        {
            Console.WriteLine(
                item.Key + " -> " + item.Value
            );
        }
    }
}