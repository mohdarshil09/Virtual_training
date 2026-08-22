using System;

namespace Lab4
{
    internal class Program
    {
        // 1. Low-level method
        static string ReadRawConfigValue(string key)
        {
            if (key == "timeout")
            {
                throw new FormatException(
                    "Value 'abc' is not a valid integer");
            }

            return "dummy-value";
        }

        // 2. Higher-level method
        static int GetTimeoutSetting()
        {
            try
            {
                string raw = ReadRawConfigValue("timeout");

                return int.Parse(raw);
            }
            catch (FormatException ex)
            {
                // Wrap the original exception as InnerException
                throw new InvalidOperationException(
                    "Application configuration is invalid",
                    ex);
            }
        }

        // 3. Print complete exception chain
        static void PrintExceptionChain(Exception ex)
        {
            int depth = 0;

            while (ex != null)
            {
                Console.WriteLine(
                    new string(' ', depth * 2) +
                    ex.GetType().Name + ": " +
                    ex.Message);

                ex = ex.InnerException;
                depth++;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                GetTimeoutSetting();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(
                    "Top-level: " + ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine(
                        "Caused by: " +
                        ex.InnerException.Message);

                    Console.WriteLine(
                        "Inner exception type: " +
                        ex.InnerException.GetType().Name);
                }

                Console.WriteLine();

                Console.WriteLine("-- PrintExceptionChain --");

                PrintExceptionChain(ex);
            }
        }
    }
}