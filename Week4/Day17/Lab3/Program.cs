using System;

namespace Lab3
{
    internal class Program
    {
        static int DivideInternal(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException(
                    "Cannot divide by zero in DivideInternal");
            }

            return a / b;
        }

        static int CallSiteGood(int a, int b)
        {
            try
            {
                return DivideInternal(a, b);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("[Good] Logging before rethrow...");

                throw;
            }
        }

        static int CallSiteBad(int a, int b)
        {
            try
            {
                return DivideInternal(a, b);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("[Bad] Logging before rethrow...");

                throw ex;
            }
        }

        static void Validate(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Value cannot be negative.");
            }
        }

        static void Main(string[] args)
        {
            // CallSiteGood
            try
            {
                CallSiteGood(10, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(
                    "Good stack trace mentions: " +
                    ex.StackTrace.Contains("DivideInternal"));

                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine();

            // CallSiteBad
            try
            {
                CallSiteBad(10, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(
                    "Bad stack trace mentions DivideInternal: " +
                    ex.StackTrace.Contains("DivideInternal"));

                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine();

            // Validate
            try
            {
                Validate(-5);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(
                    "Validate(-5) threw: " + ex.Message);
            }
        }
    }
}