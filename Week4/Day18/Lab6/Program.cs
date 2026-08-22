using System;
using System.Collections.Generic;

class Product : IComparable<Product>
{
    public string Name { get; set; }
    public double Price { get; set; }

    public int CompareTo(Product other)
    {
        return Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return $"{Name} - ₹{Price}";
    }
}

class Pair<TFirst, TSecond>
{
    public TFirst First { get; set; }
    public TSecond Second { get; set; }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }

    public override string ToString()
    {
        return $"First: {First}, Second: {Second}";
    }
}

class MinMaxTracker<T>
    where T : IComparable<T>
{
    public T Min { get; private set; }
    public T Max { get; private set; }

    private bool hasValue = false;

    public void Add(T value)
    {
        if (!hasValue)
        {
            Min = value;
            Max = value;
            hasValue = true;
            return;
        }

        if (value.CompareTo(Min) < 0)
        {
            Min = value;
        }

        if (value.CompareTo(Max) > 0)
        {
            Max = value;
        }
    }
}

class GenericUtilities
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    public static bool AllMatch<T>(
        IEnumerable<T> items,
        Func<T, bool> predicate)
    {
        foreach (T item in items)
        {
            if (!predicate(item))
                return false;
        }

        return true;
    }
}

class Lab6
{
    static void Main()
    {
        Console.WriteLine("===== LAB 6 =====");

        // =========================
        // 1. Swap<T>
        // =========================

        int a = 10;
        int b = 20;

        Console.WriteLine(
            $"Before int swap: a={a}, b={b}");

        GenericUtilities.Swap(ref a, ref b);

        Console.WriteLine(
            $"After int swap: a={a}, b={b}");

        string first = "Hello";
        string second = "World";

        GenericUtilities.Swap(
            ref first,
            ref second);

        Console.WriteLine(
            $"String swap: {first}, {second}");

        // =========================
        // 2. Pair<TFirst,TSecond>
        // =========================

        Pair<int, string> pair1 =
            new Pair<int, string>(
                101,
                "Laptop");

        Pair<string, double> pair2 =
            new Pair<string, double>(
                "Price",
                999.99);

        Console.WriteLine("\nPairs:");
        Console.WriteLine(pair1);
        Console.WriteLine(pair2);

        // =========================
        // 3. MinMaxTracker<T>
        // =========================

        MinMaxTracker<int> intTracker =
            new MinMaxTracker<int>();

        intTracker.Add(50);
        intTracker.Add(10);
        intTracker.Add(90);
        intTracker.Add(30);

        Console.WriteLine("\nInteger MinMax:");
        Console.WriteLine($"Min: {intTracker.Min}");
        Console.WriteLine($"Max: {intTracker.Max}");

        MinMaxTracker<Product> productTracker =
            new MinMaxTracker<Product>();

        productTracker.Add(
            new Product
            {
                Name = "Laptop",
                Price = 80000
            });

        productTracker.Add(
            new Product
            {
                Name = "Mouse",
                Price = 1000
            });

        productTracker.Add(
            new Product
            {
                Name = "Phone",
                Price = 50000
            });

        Console.WriteLine("\nProduct MinMax:");
        Console.WriteLine($"Min: {productTracker.Min}");
        Console.WriteLine($"Max: {productTracker.Max}");

        // =========================
        // 4. AllMatch<T>
        // =========================

        List<int> numbers =
            new List<int> { 2, 4, 6, 8 };

        bool allEven =
            GenericUtilities.AllMatch(
                numbers,
                x => x % 2 == 0);

        Console.WriteLine(
            $"\nAll numbers even: {allEven}");

        List<Product> products =
            new List<Product>
            {
                new Product
                {
                    Name = "A",
                    Price = 100
                },
                new Product
                {
                    Name = "B",
                    Price = 200
                }
            };

        bool allAffordable =
            GenericUtilities.AllMatch(
                products,
                p => p.Price < 500);

        Console.WriteLine(
            $"All products below ₹500: {allAffordable}");
    }
}