using System;

namespace Lab2
{
    internal class Program
    {
        static void Process(int mode)
        {
            Console.WriteLine("Opening");

            try
            {
                if (mode == 1)
                {
                    throw new InvalidOperationException("Simulated failure");
                }

                Console.WriteLine("Working");

                if (mode == 2)
                {
                    return;
                }

                Console.WriteLine("Finishing normally");
            }
            finally
            {
                Console.WriteLine("Closing");
            }
        }

        // Simulated resource class
        class FakeFileHandle : IDisposable
        {
            public FakeFileHandle()
            {
                Console.WriteLine("Handle opened");
            }

            public void Dispose()
            {
                Console.WriteLine("Handle closed");
            }
        }

        static void UseFakeFileHandle()
        {
            using (FakeFileHandle handle = new FakeFileHandle())
            {
                throw new Exception("Simulated resource failure");
            }
        }

        static void Main(string[] args)
        {
            // -----------------------------------------
            // Process(0)
            // -----------------------------------------
            Console.WriteLine("-- Process(0) --");

            Process(0);

            Console.WriteLine();


            // -----------------------------------------
            // Process(1)
            // -----------------------------------------
            Console.WriteLine("-- Process(1) --");

            try
            {
                Process(1);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Caught: " + ex.Message);
            }

            Console.WriteLine();


            // -----------------------------------------
            // Process(2)
            // -----------------------------------------
            Console.WriteLine("-- Process(2) --");

            Process(2);

            Console.WriteLine();


            // -----------------------------------------
            // using / IDisposable
            // -----------------------------------------
            Console.WriteLine("-- using / IDisposable --");

            try
            {
                UseFakeFileHandle();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught: " + ex.Message);
            }
        }
    }
}