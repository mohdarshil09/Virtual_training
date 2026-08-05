using System;

class Program
{
    static int LinearSearch(int[] arr, int key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
            {
                return i; // Element found
            }
        }

        return -1; // Element not found
    }

    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50 };
        int key = 30;

        int result = LinearSearch(arr, key);

        if (result != -1)
            Console.WriteLine("Element found at index: " + result);
        else
            Console.WriteLine("Element not found");
    }
}