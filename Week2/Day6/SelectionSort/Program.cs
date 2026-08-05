using System;
using System.Diagnostics;

namespace SelectionSort
{
    internal class Program
    {
        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };

            Console.WriteLine("Before: [" + string.Join(", ", arr) + "]");

            // Create Stopwatch
            Stopwatch stopwatch = new Stopwatch();

            // Start timing
            stopwatch.Start();

            SelectionSort(arr);

            // Stop timing
            stopwatch.Stop();

            Console.WriteLine("After: [" + string.Join(", ", arr) + "]");

            Console.WriteLine($"\nExecution Time: {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
        }
    }
}