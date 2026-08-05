using System;

class Program
{
    static int JumpSearch(int[] arr, int key)
    {
        int n = arr.Length;
        int step = (int)Math.Sqrt(n);
        int prev = 0;

        // Jump until the correct block is found
        while (prev < n && arr[Math.Min(step, n) - 1] < key)
        {
            prev = step;
            step += (int)Math.Sqrt(n);

            if (prev >= n)
                return -1;
        }

        // Linear search within the block
        while (prev < Math.Min(step, n))
        {
            if (arr[prev] == key)
                return prev;

            prev++;
        }

        return -1;
    }

    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
        int key = 70;

        int result = JumpSearch(arr, key);

        if (result != -1)
            Console.WriteLine("Element found at index: " + result);
        else
            Console.WriteLine("Element not found");
    }
}