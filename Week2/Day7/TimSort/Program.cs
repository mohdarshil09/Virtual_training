using System;
using System.Diagnostics;

namespace TimSort
{
    internal class Program
    {
        const int RUN = 32;

        static void InsertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = temp;
            }
        }

        static void Merge(int[] arr, int l, int m, int r)
        {
            int len1 = m - l + 1;
            int len2 = r - m;

            int[] left = new int[len1];
            int[] right = new int[len2];

            Array.Copy(arr, l, left, 0, len1);
            Array.Copy(arr, m + 1, right, 0, len2);

            int i = 0, j = 0, k = l;

            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                    arr[k++] = left[i++];
                else
                    arr[k++] = right[j++];
            }

            while (i < len1)
                arr[k++] = left[i++];

            while (j < len2)
                arr[k++] = right[j++];
        }

        static void TimSort(int[] arr)
        {
            int n = arr.Length;

            // Sort small runs using Insertion Sort
            for (int i = 0; i < n; i += RUN)
                InsertionSort(arr, i, Math.Min(i + RUN - 1, n - 1));

            // Merge sorted runs
            for (int size = RUN; size < n; size *= 2)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = Math.Min(left + size - 1, n - 1);
                    int right = Math.Min(left + 2 * size - 1, n - 1);

                    if (mid < right)
                        Merge(arr, left, mid, right);
                }
            }
        }

        static bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] > arr[i + 1])
                    return false;

            return true;
        }

        static void Main(string[] args)
        {
            int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };

            Console.WriteLine("Before: [" + string.Join(", ", arr) + "]");

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            TimSort(arr);

            stopwatch.Stop();

            Console.WriteLine("After: [" + string.Join(", ", arr) + "]");

            Console.WriteLine("Valid Sort: " + IsSorted(arr));

            Console.WriteLine($"\nExecution Time: {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
        }
    }
}