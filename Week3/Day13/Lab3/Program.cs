using System;

namespace Lab3
{
    // Base class - can still be inherited
    public class TaxCalculator
    {
        public virtual decimal CalculateTax(decimal amount)
        {
            return amount * 0.1m;
        }
    }

    // Regional calculator
    public class RegionalTaxCalculator : TaxCalculator
    {
        // Sealed override prevents further overriding
        public sealed override decimal CalculateTax(decimal amount)
        {
            return amount * 0.12m;
        }
    }



    // Completely sealed class
    public sealed class FixedDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price * 0.9m;
        }
    }

    
   

    internal class Program
    {
        static void Main(string[] args)
        {
            // Sealed override can still be used normally
            RegionalTaxCalculator regionalTax = new RegionalTaxCalculator();

            decimal tax = regionalTax.CalculateTax(200);

            Console.WriteLine(
                $"RegionalTaxCalculator.CalculateTax(200) -> {tax:F2}"
            );

            // Sealed class can still be used normally
            FixedDiscountCalculator discountCalculator =
                new FixedDiscountCalculator();

            decimal discountedPrice =
                discountCalculator.ApplyDiscount(50);

            Console.WriteLine(
                $"FixedDiscountCalculator.ApplyDiscount(50) -> {discountedPrice:F2}"
            );
        }
    }
}