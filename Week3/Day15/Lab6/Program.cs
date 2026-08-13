using System;
using System.Collections.Generic;

namespace Lab6
{
    public class CacheEntryOptions
    {
        public string Label { get; set; } = string.Empty;
        public bool Pinned { get; set; }
    }

    public class TypedCache<TKey, TValue> where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _store = new();

        private static int _totalInstances;

        public TypedCache()
        {
            _totalInstances++;
        }

        // Indexer
        public TValue this[TKey key]
        {
            get
            {
                if (!_store.TryGetValue(key, out TValue? value))
                {
                    throw new KeyNotFoundException(
                        $"The given key '{key}' was not present in the cache."
                    );
                }

                return value;
            }

            set
            {
                _store[key] = value;
            }
        }

        // Read-only expression-bodied property
        public int Count => _store.Count;

        // Static property
        public static int TotalCacheInstances => _totalInstances;

        // Static method
        public static void PrintGlobalStats()
        {
            Console.WriteLine(
                $"Global TypedCache<{typeof(TKey).Name},{typeof(TValue).Name}> " +
                $"instances created: {TotalCacheInstances}"
            );
        }

        // Add method
        public void Add(
            TKey key,
            TValue value,
            CacheEntryOptions? options = null)
        {
            _store[key] = value;

            // Metadata is optional in this basic version.
            if (options != null)
            {
                Console.WriteLine(
                    $"Added '{key}': Label={options.Label}, Pinned={options.Pinned}"
                );
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // First cache
            TypedCache<string, int> cache1 =
                new TypedCache<string, int>();

            cache1.Add("a", 1);

            cache1.Add(
                "b",
                2,
                new CacheEntryOptions
                {
                    Label = "Important",
                    Pinned = true
                }
            );

            // Second cache
            TypedCache<string, int> cache2 =
                new TypedCache<string, int>();

            cache2.Add("x", 100);
            cache2.Add("y", 200);


            // Read using indexer
            Console.WriteLine(
                $"cache1[\"a\"] = {cache1["a"]}"
            );

            Console.WriteLine(
                $"cache1 Count: {cache1.Count}"
            );


            // Missing key
            try
            {
                Console.WriteLine(cache1["z"]);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(
                    $"Missing key caught: {ex.Message}"
                );
            }


            // Global statistics
            TypedCache<string, int>.PrintGlobalStats();
        }
    }
}