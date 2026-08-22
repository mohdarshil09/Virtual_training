using System;
using System.Collections;
using System.Collections.Generic;

public interface IEntity
{
    int Id { get; }
}

public interface IRepository<T>
    where T : class
{
    void Add(T item);

    T? GetById(int id);

    IEnumerable<T> GetAll();
}

public class InMemoryRepository<T> : IRepository<T>
    where T : class, IEntity
{
    private readonly Dictionary<int, T> data = new();

    public void Add(T item)
    {
        data[item.Id] = item;
    }

    public T? GetById(int id)
    {
        if (data.TryGetValue(id, out T? item))
            return item;

        return null;
    }

    public IEnumerable<T> GetAll()
    {
        return data.Values;
    }
}

public class User : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
}

public class TagList : IEnumerable<string>
{
    private readonly List<string> tags = new();

    // Add overload 1: normal tag.
    public void Add(string tag)
    {
        tags.Add(tag);
    }

    // Add overload 2: highlighted tag.
    public void Add(string tag, bool highlighted)
    {
        if (highlighted)
            tags.Add($"[HIGHLIGHTED] {tag}");
        else
            tags.Add(tag);
    }

    public IEnumerator<string> GetEnumerator()
    {
        return tags.GetEnumerator();
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
        Console.WriteLine("=== Lab 7: Generic Repository ===");

        InMemoryRepository<User> repository = new();

        repository.Add(new User
        {
            Id = 1,
            Name = "Arshil"
        });

        repository.Add(new User
        {
            Id = 2,
            Name = "Rahul"
        });

        User? user = repository.GetById(1);

        Console.WriteLine("Retrieved user:");

        if (user != null)
            Console.WriteLine(user);

        Console.WriteLine("\nAll users:");

        foreach (User item in repository.GetAll())
        {
            Console.WriteLine(item);
        }

        // Collection initializer uses both Add overloads.
        TagList tags = new()
        {
            "C#",
            { "Generics", true },
            "Collections",
            { "Iterators", true }
        };

        Console.WriteLine("\nTags:");

        foreach (string tag in tags)
        {
            Console.WriteLine(tag);
        }
    }
}