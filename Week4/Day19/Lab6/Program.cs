using System;
using System.Collections;
using System.Collections.Generic;

public class MyDictionary<TKey, TValue> :
    IEnumerable<KeyValuePair<TKey, TValue>>
    where TKey : notnull
{
    private class Entry
    {
        public TKey Key;
        public TValue Value;
        public Entry? Next;

        public Entry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    private readonly List<Entry>[] buckets;

    public MyDictionary(int bucketCount = 5)
    {
        buckets = new List<Entry>[bucketCount];

        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new List<Entry>();
        }
    }

    private int GetBucketIndex(TKey key)
    {
        return (key.GetHashCode() & 0x7FFFFFFF)
               % buckets.Length;
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetBucketIndex(key);

        foreach (Entry entry in buckets[index])
        {
            if (EqualityComparer<TKey>.Default.Equals(
                entry.Key, key))
            {
                throw new ArgumentException(
                    "A key with the same value already exists.");
            }
        }

        buckets[index].Add(new Entry(key, value));
    }

    public TValue this[TKey key]
    {
        get
        {
            if (TryGetValue(key, out TValue? value))
                return value;

            throw new KeyNotFoundException(
                $"Key '{key}' was not found.");
        }

        set
        {
            int index = GetBucketIndex(key);

            foreach (Entry entry in buckets[index])
            {
                if (EqualityComparer<TKey>.Default.Equals(
                    entry.Key, key))
                {
                    entry.Value = value;
                    return;
                }
            }

            buckets[index].Add(new Entry(key, value));
        }
    }

    public bool TryGetValue(
        TKey key,
        out TValue value)
    {
        int index = GetBucketIndex(key);

        foreach (Entry entry in buckets[index])
        {
            if (EqualityComparer<TKey>.Default.Equals(
                entry.Key, key))
            {
                value = entry.Value;
                return true;
            }
        }

        value = default!;
        return false;
    }

    public IEnumerator<KeyValuePair<TKey, TValue>>
        GetEnumerator()
    {
        foreach (List<Entry> bucket in buckets)
        {
            foreach (Entry entry in bucket)
            {
                yield return new KeyValuePair<TKey, TValue>(
                    entry.Key,
                    entry.Value);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Lab 6: MyDictionary<TKey,TValue> ===");

        MyDictionary<int, string> myDictionary =
            new MyDictionary<int, string>(5);

        Dictionary<int, string> realDictionary = new();

        // Add 20 values.
        for (int i = 1; i <= 20; i++)
        {
            string value = $"Value-{i}";

            myDictionary.Add(i, value);
            realDictionary.Add(i, value);
        }

        // Verify every key.
        bool correct = true;

        for (int i = 1; i <= 20; i++)
        {
            if (!myDictionary.TryGetValue(
                    i,
                    out string? myValue))
            {
                correct = false;
                break;
            }

            if (myValue != realDictionary[i])
            {
                correct = false;
                break;
            }
        }

        Console.WriteLine(
            "Correctness check: " +
            (correct ? "PASS" : "FAIL"));

        // Index initializer
        MyDictionary<int, string> dictionary =
            new MyDictionary<int, string>
            {
                [1] = "One",
                [2] = "Two",
                [3] = "Three"
            };

        Console.WriteLine("\nIndex initializer:");

        foreach (KeyValuePair<int, string> pair in dictionary)
        {
            Console.WriteLine(
                $"{pair.Key} = {pair.Value}");
        }

        // Missing key
        try
        {
            Console.WriteLine(dictionary[999]);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine(
                "Caught: Key was not found.");
        }
    }
}