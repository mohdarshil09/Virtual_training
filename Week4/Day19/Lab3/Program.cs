using System;
using System.Collections.Generic;

class Program
{
    static List<string> BreadthFirstSearch(
        Dictionary<string, List<string>> graph,
        string start)
    {
        Queue<string> queue = new();
        HashSet<string> visited = new();
        List<string> result = new();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            string current = queue.Dequeue();

            result.Add(current);

            foreach (string neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }

    static List<string> DepthFirstSearch(
        Dictionary<string, List<string>> graph,
        string start)
    {
        Stack<string> stack = new();
        HashSet<string> visited = new();
        List<string> result = new();

        stack.Push(start);

        while (stack.Count > 0)
        {
            string current = stack.Pop();

            if (visited.Contains(current))
                continue;

            visited.Add(current);
            result.Add(current);

            // Reverse order is used so traversal follows the same
            // neighbor preference as the graph listing.
            List<string> neighbors = graph[current];

            for (int i = neighbors.Count - 1; i >= 0; i--)
            {
                if (!visited.Contains(neighbors[i]))
                    stack.Push(neighbors[i]);
            }
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine("=== Lab 3: BFS and DFS ===");

        Dictionary<string, List<string>> graph = new()
        {
            ["A"] = new List<string> { "B", "C" },
            ["B"] = new List<string> { "D" },
            ["C"] = new List<string> { "D" },
            ["D"] = new List<string> { "E" },
            ["E"] = new List<string>()
        };

        List<string> bfs = BreadthFirstSearch(graph, "A");
        List<string> dfs = DepthFirstSearch(graph, "A");

        Console.WriteLine("BFS: " + string.Join(" -> ", bfs));
        Console.WriteLine("DFS: " + string.Join(" -> ", dfs));

        // BFS explores level-by-level using Queue,
        // while DFS explores deeply using Stack.
    }
}