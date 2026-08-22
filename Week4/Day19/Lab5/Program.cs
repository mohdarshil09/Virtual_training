using System;
using System.Collections;
using System.Collections.Generic;

public class MyList<T> : IEnumerable<T>
{
    private T[] items;
    private int count;

    public MyList(int capacity = 4)
    {
        items = new T[capacity];
    }

    public int Count
    {
        get { return count; }
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            T[] newItems = new T[items.Length * 2];

            Array.Copy(items, newItems, items.Length);

            items = newItems;
        }

        items[count] = item;
        count++;
    }

    public void RemoveAt(int index)
    {
        CheckIndex(index);

        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        items[count - 1] = default!;
        count--;
    }

    public T this[int index]
    {
        get
        {
            CheckIndex(index);
            return items[index];
        }

        set
        {
            CheckIndex(index);
            items[index] = value;
        }
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Employee
{
    public string Name { get; set; } = "";
    public int Id { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Lab 5: MyList<T> ===");

        // 1. Test with int
        MyList<int> numbers = new();

        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);

        Console.WriteLine("Integer list:");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        // 2. Test with reference type
        MyList<Employee> employees = new();

        employees.Add(new Employee
        {
            Id = 1,
            Name = "Arshil"
        });

        employees.Add(new Employee
        {
            Id = 2,
            Name = "Rahul"
        });

        Console.WriteLine("\nEmployees:");

        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee);
        }

        // 3. Collection initializer
        MyList<int> initialized = new()
        {
            1, 2, 3
        };

        Console.WriteLine("\nInitializer:");

        foreach (int number in initialized)
        {
            Console.WriteLine(number);
        }

        // Indexer
        initialized[1] = 200;

        Console.WriteLine("\nAfter indexer update:");
        Console.WriteLine(initialized[1]);

        // RemoveAt
        initialized.RemoveAt(0);

        Console.WriteLine("\nAfter RemoveAt:");
        foreach (int number in initialized)
        {
            Console.WriteLine(number);
        }

        // 4. Deliberate exception
        try
        {
            Console.WriteLine("\nInvalid access:");
            Console.WriteLine(initialized[100]);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Caught: Index is outside the valid range.");
        }
    }
}