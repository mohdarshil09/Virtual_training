using System;

class Program
{
    static int BinarySearch(int[] arr, int low, int high, int key)
    {
        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == key)
                return mid;

            if (arr[mid] < key)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return -1;
    }

    static int ExponentialSearch(int[] arr, int key)
    {
        int n = arr.Length;

        if (arr[0] == key)
            return 0;

        int i = 1;

        while (i < n && arr[i] <= key)
        {
            i *= 2;
        }

        return BinarySearch(arr, i / 2, Math.Min(i, n - 1), key);
    }

    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
        int key = 70;

        int result = ExponentialSearch(arr, key);

        if (result != -1)
            Console.WriteLine("Element found at index: " + result);
        else
            Console.WriteLine("Element not found");
    }
}