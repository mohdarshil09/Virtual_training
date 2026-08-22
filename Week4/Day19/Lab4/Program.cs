using System;
using System.Collections.Generic;

class Program
{
    static T[] Snapshot<T>(ICollection<T> source)
    {
        T[] result = new T[source.Count];

        source.CopyTo(result, 0);

        return result;
    }

    static bool TryAddAll<T>(
        ICollection<T> target,
        IEnumerable<T> items)
    {
        if (target.IsReadOnly)
            return false;

        foreach (T item in items)
        {
            target.Add(item);
        }

        return true;
    }

    static void TestCollection<T>(
        string name,
        ICollection<T> collection,
        IEnumerable<T> items)
    {
        Console.WriteLine($"\n{name}");

        bool success = TryAddAll(collection, items);

        Console.WriteLine("TryAddAll successful: " + success);

        T[] snapshot = Snapshot(collection);

        Console.WriteLine(
            "Snapshot: " + string.Join(", ", snapshot));
    }

    static void Main()
    {
        Console.WriteLine("=== Lab 4: Collection API ===");

        List<int> list = new();
        HashSet<int> set = new();
        LinkedList<int> linkedList = new();

        int[] values = { 1, 2, 3 };

        TestCollection("List", list, values);
        TestCollection("HashSet", set, values);
        TestCollection("LinkedList", linkedList, values);

        // Read-only wrapper refuses modification.
        IReadOnlyCollection<int> readOnly = new List<int>
        {
            10, 20
        }.AsReadOnly();

        ICollection<int> readOnlyCollection =
            (ICollection<int>)readOnly;

        bool result = TryAddAll(
            readOnlyCollection,
            new[] { 30, 40 });

        Console.WriteLine("\nRead-only collection:");
        Console.WriteLine("TryAddAll successful: " + result);
    }
}