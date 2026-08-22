using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class Lab1
{
    static void Main()
    {
        Console.WriteLine("===== LAB 1 =====");

        // Part 1: ArrayList
        ArrayList values = new ArrayList();

        values.Add(10);
        values.Add("twenty");
        values.Add(30.5);
        values.Add(true);

        double sum = 0;

        foreach (object item in values)
        {
            if (item is int n)
                sum += n;
            else if (item is double d)
                sum += d;
        }

        Console.WriteLine($"Sum of numeric values: {sum}");

        // Part 2: Generic List<int>
        List<int> numbers = new List<int>();

        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);

        // This would NOT compile:
        // numbers.Add("twenty");

        Console.WriteLine("List<int> accepts only integers.");

        // Part 3: Benchmark
        const int count = 2_000_000;

        Stopwatch stopwatch = new Stopwatch();

        ArrayList arrayList = new ArrayList();

        stopwatch.Start();

        for (int i = 0; i < count; i++)
        {
            arrayList.Add(i);
        }

        stopwatch.Stop();

        Console.WriteLine(
            $"ArrayList insertion time: {stopwatch.ElapsedMilliseconds} ms");

        List<int> intList = new List<int>(count);

        stopwatch.Restart();

        for (int i = 0; i < count; i++)
        {
            intList.Add(i);
        }

        stopwatch.Stop();

        Console.WriteLine(
            $"List<int> insertion time: {stopwatch.ElapsedMilliseconds} ms");
    }
}