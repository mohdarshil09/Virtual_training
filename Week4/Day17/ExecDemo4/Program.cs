using System;

class ExecDemo4
{
    public static void Main()
    {
        // Here, numer is longer than denom.
        int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
        int[] denom = { 2, 0, 4, 4, 0, 8 };

        for (int i = 0; i < numer.Length; i++)
        {
            try
            {
                Console.WriteLine(
                    numer[i] + " / " +
                    denom[i] + " is " +
                    numer[i] / denom[i]);
            }
            catch (DivideByZeroException)
            {
                // Catch the exception
                Console.WriteLine("can't divide by zero!");
            }
            catch (IndexOutOfRangeException)
            {
                // Catch the exception
                Console.WriteLine("No matching element found.");
            }
            finally
            {
                Console.WriteLine("Finally block reached."); 
            }
        }
    }
}