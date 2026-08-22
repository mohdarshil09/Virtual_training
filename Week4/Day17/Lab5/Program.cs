using System;

namespace Lab5
{
    // Base custom exception
    public class OrderValidationException : Exception
    {
        public string FieldName { get; }

        public OrderValidationException()
            : base()
        {
        }

        public OrderValidationException(string message)
            : base(message)
        {
        }

        public OrderValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public OrderValidationException(string message, string fieldName)
            : base(message)
        {
            FieldName = fieldName;
        }
    }


    // More specific exception
    public class MissingFieldException : OrderValidationException
    {
        public MissingFieldException(string fieldName)
            : base("Required field is missing", fieldName)
        {
        }
    }


    // More specific exception
    public class InvalidQuantityException : OrderValidationException
    {
        public InvalidQuantityException(string fieldName)
            : base("Quantity must be greater than zero", fieldName)
        {
        }
    }


    internal class Program
    {
        // Validate order
        static decimal ValidateOrder(
            string customerName,
            int quantity,
            decimal unitPrice)
        {
            if (string.IsNullOrEmpty(customerName))
            {
                throw new MissingFieldException("customerName");
            }

            if (quantity <= 0)
            {
                throw new InvalidQuantityException("quantity");
            }

            if (unitPrice < 0)
            {
                throw new OrderValidationException(
                    "Unit price cannot be negative",
                    "unitPrice");
            }

            return quantity * unitPrice;
        }


        // Simulate database failure
        static void SaveOrder(
            string customerName,
            int quantity,
            decimal unitPrice)
        {
            throw new InvalidOperationException(
                "Database unavailable");
        }


        // Process order
        static void ProcessOrder(
            string customerName,
            int quantity,
            decimal unitPrice)
        {
            try
            {
                decimal total = ValidateOrder(
                    customerName,
                    quantity,
                    unitPrice);

                try
                {
                    SaveOrder(
                        customerName,
                        quantity,
                        unitPrice);

                    Console.WriteLine(
                        $"Order total: ${total:F2}");
                }
                catch (InvalidOperationException ex)
                {
                    // Create a NEW exception containing the original
                    // database exception as InnerException.
                    //
                    // throw; cannot be used here because throw;
                    // rethrows the exception currently being caught.
                    // We are throwing a NEW OrderValidationException,
                    // so we must use "throw new ...".

                    throw new OrderValidationException(
                        "Could not save order",
                        ex);
                }
            }
            catch (MissingFieldException ex)
            {
                Console.WriteLine(
                    "Missing field: " + ex.FieldName);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine(
                    "Invalid quantity for field: " +
                    ex.FieldName);
            }
            catch (OrderValidationException ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine(
                        "Order validation failed: " +
                        ex.Message +
                        " (caused by: " +
                        ex.InnerException.Message +
                        ")");
                }
                else
                {
                    Console.WriteLine(
                        "Order validation failed: " +
                        ex.Message);
                }
            }
            finally
            {
                Console.WriteLine(
                    "Order attempt complete.");
            }
        }


        static void Main(string[] args)
        {
            // -----------------------------------------
            // Missing customer name
            // -----------------------------------------
            Console.WriteLine("-- Missing customer name --");

            ProcessOrder("", 2, 99.98m);

            Console.WriteLine();


            // -----------------------------------------
            // Zero quantity
            // -----------------------------------------
            Console.WriteLine("-- Zero quantity --");

            ProcessOrder("John", 0, 99.98m);

            Console.WriteLine();


            // -----------------------------------------
            // Negative price
            // -----------------------------------------
            Console.WriteLine("-- Negative price --");

            ProcessOrder("John", 2, -10m);

            Console.WriteLine();


            // -----------------------------------------
            // Valid order, SaveOrder fails
            // -----------------------------------------
            Console.WriteLine(
                "-- Valid order, SaveOrder fails --");

            ProcessOrder("John", 2, 99.98m);

            Console.WriteLine();


            // -----------------------------------------
            // Fully valid order
            // -----------------------------------------
            Console.WriteLine("-- Fully valid order --");

            // SaveOrder always fails in this lab, so this
            // demonstrates validation success followed by
            // the simulated database failure.
            ProcessOrder("Alice", 2, 99.98m);
        }
    }
}