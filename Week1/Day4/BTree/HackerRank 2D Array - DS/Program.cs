using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Result
{
    /*
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int hourglassSum(List<List<int>> arr)
    {
        int maxHourglassSum = int.MinValue;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                int currentSum =
                    arr[i][j] + arr[i][j + 1] + arr[i][j + 2] +
                    arr[i + 1][j + 1] +
                    arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];

                if (currentSum > maxHourglassSum)
                {
                    maxHourglassSum = currentSum;
                }
            }
        }

        return maxHourglassSum;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).ToList());
        }

        int result = Result.hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}