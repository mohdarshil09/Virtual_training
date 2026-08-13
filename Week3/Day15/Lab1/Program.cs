using System;
using System.Collections.Generic;

namespace Lab1
{
    // Generic class: works with any data type
    public class Box<T>
    {
        private T _value;

        public Box(T value)
        {
            _value = value;
        }

        public T GetValue()
        {
            return _value;
        }

        public void Replace(T newValue)
        {
            _value = newValue;
        }

        // Generic method with new() constraint
        public static Box<T> CreateEmpty<T>() where T : new()
        {
            return new Box<T>(new T());
        }
    }

    // Generic class with two different types
    public class Pair<TFirst, TSecond>
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
            return $"({First}, {Second})";
        }
    }

    // Generic class requiring comparable elements
    public class SortedBox<T> where T : IComparable<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
            _items.Sort();
        }

        public List<T> GetItems()
        {
            return _items;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Box<int>
            Box<int> intBox = new Box<int>(42);
            Console.WriteLine($"Box<int>: {intBox.GetValue()}");

            // 2. Box<string>
            Box<string> stringBox = new Box<string>("Hello");
            Console.WriteLine($"Box<string>: {stringBox.GetValue()}");

            // 3. Box<DateTime>
            Box<DateTime> dateBox = new Box<DateTime>(
                new DateTime(2026, 8, 12)
            );
            Console.WriteLine($"Box<DateTime>: {dateBox.GetValue():yyyy-MM-dd}");

            // Replace value
            intBox.Replace(100);
            Console.WriteLine($"After Replace: {intBox.GetValue()}");

            // 4. CreateEmpty<T>()
            Box<int> emptyIntBox = Box<int>.CreateEmpty<int>();
            Console.WriteLine($"CreateEmpty<int>: {emptyIntBox.GetValue()}");

            // 5. Pair<string, int>
            Pair<string, int> pair = new Pair<string, int>("Age", 30);
            Console.WriteLine($"Pair: {pair}");

            // 6. SortedBox<int>
            SortedBox<int> sortedBox = new SortedBox<int>();

            sortedBox.Add(5);
            sortedBox.Add(1);
            sortedBox.Add(3);

            Console.WriteLine(
                $"SortedBox after adding 5, 1, 3: {string.Join(", ", sortedBox.GetItems())}"
            );
        }
    }
}