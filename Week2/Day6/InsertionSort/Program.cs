using System;
using System.Diagnostics;

namespace InsertionSort
{
    internal class Program
    {
        static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        static bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };

            Console.WriteLine("Before: [" + string.Join(", ", arr) + "]");

            // Create Stopwatch
            Stopwatch stopwatch = new Stopwatch();

            // Start timing
            stopwatch.Start();

            InsertionSort(arr);

            // Stop timing
            stopwatch.Stop();

            Console.WriteLine("After: [" + string.Join(", ", arr) + "]");

            Console.WriteLine("Valid Sort: " + IsSorted(arr));

            Console.WriteLine($"\nExecution Time: {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
        }
    }
}