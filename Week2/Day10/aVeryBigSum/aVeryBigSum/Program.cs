using System;
using System.Collections.Generic;

class Result
{
    public static long aVeryBigSum(List<long> ar)
    {
        long sum = 0;

        foreach (long num in ar)
        {
            sum += num;
        }

        return sum;
    }
}

class Solution
{
    static void Main(string[] args)
    {
        int arCount = int.Parse(Console.ReadLine());

        List<long> ar = new List<long>();

        string[] input = Console.ReadLine().Split(' ');

        for (int i = 0; i < arCount; i++)
        {
            ar.Add(long.Parse(input[i]));
        }

        long result = Result.aVeryBigSum(ar);

        Console.WriteLine(result);
    }
}