using System;
using System.Collections;
using System.Collections.Generic;

public class FixedSizeStack<T> :
    IEnumerable<T>,
    IReadOnlyCollection<T>
{
    private readonly T[] items;

    private int top = -1;

    public int Count { get; private set; }

    public int Capacity => items.Length;

    public FixedSizeStack(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException(
                "Capacity must be greater than zero.");
        }

        items = new T[capacity];
    }

    public void Push(T item)
    {
        if (Count == Capacity)
        {
            throw new InvalidOperationException(
                "Stack is full.");
        }

        top++;
        items[top] = item;
        Count++;
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException(
                "Stack is empty.");
        }

        T item = items[top];

        items[top] = default(T);

        top--;
        Count--;

        return item;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException(
                "Stack is empty.");
        }

        return items[top];
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = top; i >= 0; i--)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}