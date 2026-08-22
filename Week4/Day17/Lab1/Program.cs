using System;

namespace Lab1
{
    internal class Program
    {
        static int ParseAge(string input)
        {
            Console.WriteLine("Step 1");

            int age = int.Parse(input);

            if (age < 0 || age > 150)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(input),
                    "Age must be between 0 and 150");
            }

            Console.WriteLine("Step 2 (only if valid)");

            return age;
        }

        static void Main(string[] args)
        {
            // ParseAge("abc")
            Console.WriteLine("-- ParseAge(\"abc\") --");

            try
            {
                int result = ParseAge("abc");
                Console.WriteLine("Result: " + result);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(
                    "Caught FormatException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Caught general Exception: " + ex.Message);
            }

            Console.WriteLine();


            // ParseAge("200")
            Console.WriteLine("-- ParseAge(\"200\") --");

            try
            {
                int result = ParseAge("200");
                Console.WriteLine("Result: " + result);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(
                    "Caught ArgumentOutOfRangeException " +
                    "(most specific, ran first): " +
                    ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(
                    "Caught ArgumentException: " +
                    ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Caught general Exception: " +
                    ex.Message);
            }

            Console.WriteLine();


            // WRONG ORDER - will not compile

            /*
            try
            {
                int result = ParseAge("200");
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument Exception");
            }

            // This does not compile because Exception is the
            // base class of ArgumentException. The Exception
            // catch block can already catch ArgumentException,
            // so the later ArgumentException block is unreachable.
            */


            // ParseAge("30")
            Console.WriteLine("-- ParseAge(\"30\") --");

            try
            {
                int result = ParseAge("30");
                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Caught Exception: " + ex.Message);
            }
        }
    }
}