using System;

namespace mergeArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = { 1, 2, 3, 4, 5 };
            int[] secondArray = { 6, 7, 8, 9, 10 };

            int[] mergedArray = new int[firstArray.Length + secondArray.Length];

            for (int i = 0; i < firstArray.Length; i++)
            {
                mergedArray[i] = firstArray[i];
            }

            for (int i = 0; i < secondArray.Length; i++)
            {
                mergedArray[firstArray.Length + i] = secondArray[i];
            }

            Console.Write("Merged Array: ");

            foreach (int num in mergedArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
