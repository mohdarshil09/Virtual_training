using System;
using System.Collections.Generic;

class PrintJob
{
    public string DocumentName { get; set; }
    public int Pages { get; set; }
    public bool IsPriority { get; set; }

    public override string ToString()
    {
        return $"{DocumentName} ({Pages} pages)";
    }
}

class Lab4
{
    // =========================
    // 4A - Balanced Parentheses
    // =========================

    static bool IsBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in expression)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0)
                    return false;

                char opening = stack.Pop();

                if (!IsMatchingPair(opening, c))
                    return false;
            }
        }

        return stack.Count == 0;
    }

    static bool IsMatchingPair(char opening, char closing)
    {
        return (opening == '(' && closing == ')') ||
               (opening == '{' && closing == '}') ||
               (opening == '[' && closing == ']');
    }

    // =========================
    // 4B - Print Job Queue
    // =========================

    static void ProcessPrintQueue(
        Queue<PrintJob> normalQueue,
        Queue<PrintJob> priorityQueue)
    {
        while (priorityQueue.Count > 0 ||
               normalQueue.Count > 0)
        {
            Queue<PrintJob> currentQueue;

            if (priorityQueue.Count > 0)
            {
                currentQueue = priorityQueue;
            }
            else
            {
                currentQueue = normalQueue;
            }

            PrintJob next = currentQueue.Peek();

            Console.WriteLine(
                $"Now printing next: {next}");

            PrintJob job = currentQueue.Dequeue();

            Console.WriteLine(
                $"Printing {job.DocumentName} ({job.Pages} pages)...");
        }
    }

    static void Main()
    {
        Console.WriteLine("===== LAB 4 =====");

        // 4A
        Console.WriteLine("\n--- Balanced Parentheses ---");

        string expression1 = "{[a+(b*c)]-d}";
        string expression2 = "{[(a+b)]";

        Console.WriteLine(
            $"{expression1} -> {IsBalanced(expression1)}");

        Console.WriteLine(
            $"{expression2} -> {IsBalanced(expression2)}");

        // 4B
        Console.WriteLine("\n--- Print Job Queue ---");

        // Queue alone cannot efficiently move a priority job
        // ahead of existing normal jobs.
        // Two queues are used: priority and normal.

        Queue<PrintJob> normalQueue =
            new Queue<PrintJob>();

        Queue<PrintJob> priorityQueue =
            new Queue<PrintJob>();

        normalQueue.Enqueue(new PrintJob
        {
            DocumentName = "Document1",
            Pages = 5
        });

        normalQueue.Enqueue(new PrintJob
        {
            DocumentName = "Document2",
            Pages = 10
        });

        normalQueue.Enqueue(new PrintJob
        {
            DocumentName = "Document3",
            Pages = 3
        });

        normalQueue.Enqueue(new PrintJob
        {
            DocumentName = "Document4",
            Pages = 8
        });

        normalQueue.Enqueue(new PrintJob
        {
            DocumentName = "Document5",
            Pages = 4
        });

        Console.WriteLine("\nPriority job arrives:");

        priorityQueue.Enqueue(new PrintJob
        {
            DocumentName = "UrgentDocument",
            Pages = 2,
            IsPriority = true
        });

        ProcessPrintQueue(
            normalQueue,
            priorityQueue);
    }
}