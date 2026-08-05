using System;
using System.Diagnostics;

namespace IntroSort
{
    internal class Program
    {
        const int INSERTION_SORT_THRESHOLD = 16;

        static void InsertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= left && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
        }

        static void Heapify(int[] arr, int n, int i, int offset)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[offset + left] > arr[offset + largest])
                largest = left;

            if (right < n && arr[offset + right] > arr[offset + largest])
                largest = right;

            if (largest != i)
            {
                (arr[offset + i], arr[offset + largest]) =
                (arr[offset + largest], arr[offset + i]);

                Heapify(arr, n, largest, offset);
            }
        }

        static void HeapSort(int[] arr, int low, int high)
        {
            int n = high - low + 1;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i, low);

            for (int i = n - 1; i > 0; i--)
            {
                (arr[low], arr[low + i]) = (arr[low + i], arr[low]);

                Heapify(arr, i, 0, low);
            }
        }

        static void IntroSort(int[] arr, int low, int high, int depthLimit)
        {
            int size = high - low + 1;

            if (size <= INSERTION_SORT_THRESHOLD)
            {
                InsertionSort(arr, low, high);
                return;
            }

            if (depthLimit == 0)
            {
                HeapSort(arr, low, high);
                return;
            }

            int pivot = Partition(arr, low, high);

            IntroSort(arr, low, pivot - 1, depthLimit - 1);
            IntroSort(arr, pivot + 1, high, depthLimit - 1);
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

            int depthLimit = 2 * (int)Math.Log(arr.Length, 2);

            IntroSort(arr, 0, arr.Length - 1, depthLimit);

            stopwatch.Stop();

            Console.WriteLine("After: [" + string.Join(", ", arr) + "]");

            Console.WriteLine("Valid Sort: " + IsSorted(arr));

            Console.WriteLine($"\nExecution Time: {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
        }
    }
}