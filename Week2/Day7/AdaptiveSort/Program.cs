using System;
using System.Diagnostics;

namespace AdaptiveSort
{
    internal class Program
    {
        // ---------------- Insertion Sort ----------------
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

        // ---------------- Selection Sort ----------------
        static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }

                int temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }

        // ---------------- Quick Sort ----------------
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        // ---------------- Merge Sort ----------------
        static void MergeSort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;

            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];

            int i = left;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                    temp[k++] = arr[i++];
                else
                    temp[k++] = arr[j++];
            }

            while (i <= mid)
                temp[k++] = arr[i++];

            while (j <= right)
                temp[k++] = arr[j++];

            for (i = left, k = 0; i <= right; i++, k++)
                arr[i] = temp[k];
        }

        // ---------------- Swap ----------------
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // ---------------- Utility ----------------
        static bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] > arr[i + 1])
                    return false;

            return true;
        }

        // Check if array is nearly sorted
        static bool IsNearlySorted(int[] arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    count++;
            }

            return count <= arr.Length / 5;
        }

        // ---------------- Adaptive Sort ----------------
        static void AdaptiveSort(int[] arr)
        {
            if (IsSorted(arr))
            {
                Console.WriteLine("Already Sorted - No Sorting Needed");
            }
            else if (IsNearlySorted(arr))
            {
                Console.WriteLine("Using Insertion Sort");
                InsertionSort(arr);
            }
            else if (arr.Length < 20)
            {
                Console.WriteLine("Using Selection Sort");
                SelectionSort(arr);
            }
            else if (arr.Length < 100)
            {
                Console.WriteLine("Using Quick Sort");
                QuickSort(arr, 0, arr.Length - 1);
            }
            else
            {
                Console.WriteLine("Using Merge Sort");
                MergeSort(arr, 0, arr.Length - 1);
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };

            Console.WriteLine("Before: [" + string.Join(", ", arr) + "]");

            Stopwatch sw = new Stopwatch();

            sw.Start();
            AdaptiveSort(arr);
            sw.Stop();

            Console.WriteLine("After : [" + string.Join(", ", arr) + "]");

            Console.WriteLine("Valid Sort: " + IsSorted(arr));

            Console.WriteLine($"Execution Time: {sw.Elapsed.TotalMilliseconds:F6} ms");
        }
    }
}