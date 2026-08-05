using System;

class Program
{
    static int BinarySearch(int[] arr, int key)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == key)
            {
                return mid; // Element found
            }
            else if (arr[mid] < key)
            {
                low = mid + 1; // Search right half
            }
            else
            {
                high = mid - 1; // Search left half
            }
        }

        return -1; // Element not found
    }

    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50, 60, 70 };
        int key = 50;

        int result = BinarySearch(arr, key);

        if (result != -1)
            Console.WriteLine("Element found at index: " + result);
        else
            Console.WriteLine("Element not found");
    }
}