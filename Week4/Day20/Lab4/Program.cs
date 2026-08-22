using System;
using System.Collections.Generic;

class Program
{
    // 4. Generic Repeat method

    static void Repeat(int times, Action action)
    {
        for (int i = 0; i < times; i++)
        {
            action();
        }
    }


    // Prime checking method

    static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }


    static void Main()
    {
        Console.WriteLine("===== LAB 4 =====");


        // 1. Func for addition and multiplication

        Func<int, int, int> addition =
            (a, b) => a + b;

        Func<int, int, int> multiplication =
            (a, b) => a * b;

        Console.WriteLine(
            $"Addition: {addition(10, 5)}");

        Console.WriteLine(
            $"Multiplication: {multiplication(10, 5)}");


        // 2. Action with timestamp

        Action<string> log =
            message =>
                Console.WriteLine(
                    $"[{DateTime.Now:HH:mm:ss}] {message}");

        log("Application started.");


        // 3. Predicate for prime numbers

        Predicate<int> isPrime = IsPrime;

        List<int> numbers = new List<int>();

        for (int i = 1; i <= 50; i++)
        {
            numbers.Add(i);
        }

        List<int> primes = numbers.FindAll(isPrime);

        Console.WriteLine(
            $"\nPrime numbers from 1 to 50:");

        Console.WriteLine(
            string.Join(", ", primes));


        // 4. Repeat using Action

        Console.WriteLine("\nRepeat:");

        Repeat(
            5,
            () => Console.WriteLine("Tick")
        );
    }
}