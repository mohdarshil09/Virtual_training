using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ParallelQuickSort
{
    internal class Program
    {
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int t = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = t;

            return i + 1;
        }

        static void ParallelQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                Parallel.Invoke(
                    () => ParallelQuickSort(arr, low, pi - 1),
                    () => ParallelQuickSort(arr, pi + 1, high)
                );
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

            ParallelQuickSort(arr, 0, arr.Length - 1);

            stopwatch.Stop();

            Console.WriteLine("After: [" + string.Join(", ", arr) + "]");

            Console.WriteLine("Valid Sort: " + IsSorted(arr));

            Console.WriteLine($"\nExecution Time: {stopwatch.Elapsed.TotalMilliseconds:F6} ms");
        }
    }
}