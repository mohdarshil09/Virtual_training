using System;
using System.Collections.Generic;

public static class StackExtensions
{
    public static FixedSizeStack<T> ToFixedSizeStack<T>(
        this IEnumerable<T> source,
        int capacity)
    {
        if (source == null)
        {
            throw new ArgumentNullException(
                nameof(source));
        }

        FixedSizeStack<T> stack =
            new FixedSizeStack<T>(capacity);

        foreach (T item in source)
        {
            stack.Push(item);
        }

        return stack;
    }
}