/*
 * HackerRank - Dynamic Array
 * Question Link:
 * https://www.hackerrank.com/challenges/dynamic-array/problem?isFullScreen=true
 *
 * Language: C#
 * Concepts Used:
 * - Dynamic Arrays (List)
 * - Bitwise XOR (^)
 * - Modulo Operator (%)
 * - Array Indexing
 *
 * Time Complexity: O(q)
 * Space Complexity: O(n + k)
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Result
{
    /*
     * Complete the 'dynamicArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     * 1. INTEGER n
     * 2. 2D_INTEGER_ARRAY queries
     */

    public static List<int> dynamicArray(int n, List<List<int>> queries)
    {
        // Initialize an array of n empty lists
        List<int>[] arr = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = new List<int>();
        }

        List<int> answers = new List<int>();
        int lastAnswer = 0;

        // Process each query
        foreach (var query in queries)
        {
            int type = query[0];
            int x = query[1];
            int y = query[2];

            // Calculate the sequence index
            int idx = (x ^ lastAnswer) % n;

            if (type == 1)
            {
                // Append y to the selected sequence
                arr[idx].Add(y);
            }
            else if (type == 2)
            {
                // Retrieve the required element
                int targetIndex = y % arr[idx].Count;

                // Update lastAnswer
                lastAnswer = arr[idx][targetIndex];

                // Store the answer
                answers.Add(lastAnswer);
            }
        }

        return answers;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);
        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(
                Console.ReadLine()
                .TrimEnd()
                .Split(' ')
                .Select(int.Parse)
                .ToList()
            );
        }

        List<int> result = Result.dynamicArray(n, queries);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
