using System;
using System.Diagnostics;
using System.Text;

class Lab2
{
    // Build string using normal string concatenation
    static string BuildWithString(int count)
    {
        string result = "";

        for (int i = 0; i < count; i++)
        {
            result += i.ToString();
        }

        return result;
    }

    // Build string using StringBuilder
    static string BuildWithStringBuilder(int count)
    {
        // Give StringBuilder an initial capacity
        StringBuilder sb = new StringBuilder(count * 2);

        for (int i = 0; i < count; i++)
        {
            sb.Append(i.ToString());
        }

        return sb.ToString();
    }

    static void Main()
    {
        int count = 50000;

        // -------------------------------
        // Test String concatenation
        // -------------------------------

        Stopwatch stopwatch = Stopwatch.StartNew();

        BuildWithString(count);

        stopwatch.Stop();

        long stringTime = stopwatch.ElapsedMilliseconds;


        // -------------------------------
        // Test StringBuilder
        // -------------------------------

        stopwatch.Restart();

        BuildWithStringBuilder(count);

        stopwatch.Stop();

        long stringBuilderTime = stopwatch.ElapsedMilliseconds;


        // -------------------------------
        // Print results
        // -------------------------------

        Console.WriteLine(
            $"String concatenation ({count:N0} items): {stringTime} ms"
        );

        Console.WriteLine(
            $"StringBuilder ({count:N0} items): {stringBuilderTime} ms"
        );


        // Calculate ratio
        if (stringBuilderTime > 0)
        {
            double ratio =
                (double)stringTime / stringBuilderTime;

            Console.WriteLine(
                $"StringBuilder is roughly {ratio:F1}x faster"
            );
        }


        // -------------------------------
        // Test with 200,000
        // -------------------------------

        count = 200000;

        stopwatch.Restart();

        BuildWithString(count);

        stopwatch.Stop();

        stringTime = stopwatch.ElapsedMilliseconds;


        stopwatch.Restart();

        BuildWithStringBuilder(count);

        stopwatch.Stop();

        stringBuilderTime = stopwatch.ElapsedMilliseconds;


        Console.WriteLine();
        Console.WriteLine("----- 200,000 Items -----");

        Console.WriteLine(
            $"String concatenation ({count:N0} items): {stringTime} ms"
        );

        Console.WriteLine(
            $"StringBuilder ({count:N0} items): {stringBuilderTime} ms"
        );

        if (stringBuilderTime > 0)
        {
            double ratio =
                (double)stringTime / stringBuilderTime;

            Console.WriteLine(
                $"StringBuilder is roughly {ratio:F1}x faster"
            );
        }
    }
}