using System;
using System.Diagnostics;

namespace HeapSort
{
    internal class Program
    {
        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
                largest = left;

            if (right < n && arr[right] > arr[largest])
                largest = right;

            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                Heapify(arr, n, largest);
            }
        }

        static void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // Build Max Heap
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            // Extract elements from heap
            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0);
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

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            HeapSort(arr);

            stopwatch.Stop();

            Console.WriteLine("After: [" + string.Join(", ", arr) + "]");

            Console.WriteLine("Valid Sort: " + IsSorted(arr));

            Console.WriteLine($"\nExecution Time: {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
        }
    }
}