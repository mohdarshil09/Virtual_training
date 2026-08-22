using System;
using System.Collections.Generic;

class Program
{
    // 1. Custom delegate
    public delegate double Discount(double price);


    // 2. Methods matching the delegate signature

    static double NoDiscount(double price)
    {
        return price;
    }

    static double TenPercentOff(double price)
    {
        return price * 0.90;
    }

    static double HalfOff(double price)
    {
        return price * 0.50;
    }


    // 3. Method accepting a delegate

    static double ApplyDiscount(double price, Discount discount)
    {
        return discount(price);
    }


    static void Main()
    {
        Console.WriteLine("===== LAB 2 =====");

        double price = 1000;


        // 4. Direct delegate calls through ApplyDiscount

        Console.WriteLine(
            $"No Discount: {ApplyDiscount(price, NoDiscount):F2}");

        Console.WriteLine(
            $"10% Off: {ApplyDiscount(price, TenPercentOff):F2}");

        Console.WriteLine(
            $"50% Off: {ApplyDiscount(price, HalfOff):F2}");


        // 5. Store methods in a List of delegates

        List<Discount> discounts = new List<Discount>
        {
            NoDiscount,
            TenPercentOff,
            HalfOff
        };

        Console.WriteLine("\nUsing List<Discount>:");

        foreach (Discount discount in discounts)
        {
            Console.WriteLine(
                $"Discounted Price: {discount(price):F2}");
        }
    }
}