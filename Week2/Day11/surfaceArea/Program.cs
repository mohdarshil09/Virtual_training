using System;
using System.Collections.Generic;

class Result
{
    public static int surfaceArea(List<List<int>> A)
    {
        int rows = A.Count;
        int cols = A[0].Count;

        int area = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int h = A[i][j];

                // Top and Bottom
                if (h > 0)
                    area += 2;

                // Front
                if (i == 0)
                    area += h;
                else
                    area += Math.Max(0, h - A[i - 1][j]);

                // Back
                if (i == rows - 1)
                    area += h;
                else
                    area += Math.Max(0, h - A[i + 1][j]);

                // Left
                if (j == 0)
                    area += h;
                else
                    area += Math.Max(0, h - A[i][j - 1]);

                // Right
                if (j == cols - 1)
                    area += h;
                else
                    area += Math.Max(0, h - A[i][j + 1]);
            }
        }

        return area;
    }
}

class Solution
{
    static void Main(string[] args)
    {
        string[] firstLine = Console.ReadLine().Split(' ');

        int H = int.Parse(firstLine[0]);
        int W = int.Parse(firstLine[1]);

        List<List<int>> A = new List<List<int>>();

        for (int i = 0; i < H; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            List<int> row = new List<int>();

            for (int j = 0; j < W; j++)
            {
                row.Add(int.Parse(input[j]));
            }

            A.Add(row);
        }

        int result = Result.surfaceArea(A);

        Console.WriteLine(result);
    }
}