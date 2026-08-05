using System;
using System.Collections.Generic;

class Program
{
    static int HashSearch(int[] arr, int key)
    {
        Dictionary<int, int> hashTable = new Dictionary<int, int>();

        // Store element and its index
        for (int i = 0; i < arr.Length; i++)
        {
            hashTable[arr[i]] = i;
        }

        // Search for the key
        if (hashTable.ContainsKey(key))
            return hashTable[key];

        return -1;
    }

    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50, 60, 70 };
        int key = 50;

        int result = HashSearch(arr, key);

        if (result != -1)
            Console.WriteLine("Element found at index: " + result);
        else
            Console.WriteLine("Element not found");
    }
}