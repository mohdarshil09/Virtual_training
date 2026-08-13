using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    // Base identification contract
    public interface IIdentifiable
    {
        string Id { get; }
    }

    // Payment contract inherits IIdentifiable
    public interface IPaymentMethod : IIdentifiable
    {
        string DisplayName { get; }

        PaymentResult Charge(decimal amount);
    }

    // Encapsulated payment result
    public class PaymentResult
    {
        public bool Success { get; }
        public string Message { get; }

        public PaymentResult(bool success, string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            Success = success;
            Message = message;
        }
    }

    // Abstract base payment class
    public abstract class PaymentMethodBase : IPaymentMethod
    {
        public string Id { get; }
        public string DisplayName { get; }

        protected PaymentMethodBase(string id, string displayName)
        {
            Id = id;
            DisplayName = displayName;
        }

        public abstract PaymentResult Charge(decimal amount);
    }

    // Credit card implementation
    public class CreditCardPayment : PaymentMethodBase
    {
        public CreditCardPayment(string id, string displayName)
            : base(id, displayName)
        {
        }

        public override PaymentResult Charge(decimal amount)
        {
            if (amount > 5000)
            {
                return new PaymentResult(
                    false,
                    "Credit card limit exceeded."
                );
            }

            return new PaymentResult(
                true,
                "Credit card payment successful."
            );
        }
    }

    // Sealed cash payment implementation
    public sealed class CashPayment : PaymentMethodBase
    {
        public CashPayment(string id, string displayName)
            : base(id, displayName)
        {
        }

        public override PaymentResult Charge(decimal amount)
        {
            return new PaymentResult(
                true,
                "Cash payment successful."
            );
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // List uses the interface type
            List<IPaymentMethod> paymentMethods = new List<IPaymentMethod>
            {
                new CreditCardPayment("CC-1", "Visa ...1234"),
                new CashPayment("CASH-1", "Cash Drawer")
            };

            // Amounts to process
            decimal[] amounts = { 1500m, 6000m };

            // Anonymous-type settlement report
            var settlementReport = paymentMethods
                .SelectMany(payment => amounts.Select(amount =>
                {
                    PaymentResult result = payment.Charge(amount);

                    return new
                    {
                        Id = payment.Id,
                        DisplayName = payment.DisplayName,
                        AmountAttempted = amount,
                        Success = result.Success
                    };
                }))
                .ToList();

            // Print report
            foreach (var entry in settlementReport)
            {
                Console.WriteLine(
                    $"{entry.Id}  {entry.DisplayName,-15} " +
                    $"Attempted={entry.AmountAttempted:F2}  " +
                    $"Success={entry.Success}"
                );
            }

            // Calculate total successfully settled amount
            decimal totalSettled = settlementReport
                .Where(x => x.Success)
                .Sum(x => x.AmountAttempted);

            Console.WriteLine();
            Console.WriteLine(
                $"Total successfully settled: {totalSettled:F2}"
            );
        }
    }
}