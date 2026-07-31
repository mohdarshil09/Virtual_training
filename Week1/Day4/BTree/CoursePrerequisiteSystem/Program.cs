using System;
using System.Collections.Generic;

namespace CoursePrerequisiteSystem
{
    internal class Program
    {
        // Graph using adjacency list
        static List<int>[] courses = new List<int>[6];

        static void Main(string[] args)
        {
            // Initialize graph
            for (int i = 0; i < courses.Length; i++)
            {
                courses[i] = new List<int>();
            }

            // Add course prerequisites
            Connect(0, 1);
            Connect(0, 2);
            Connect(1, 3);
            Connect(2, 3);
            Connect(2, 4);
            Connect(3, 5);
            Connect(4, 5);

            Console.WriteLine("COURSE PREREQUISITE SYSTEM");

            Console.WriteLine("\n1. Prerequisites of Course 5");
            ShowAllPrerequisites(5);

            Console.WriteLine("\n2. Direct prerequisites of Course 3");
            ShowDirectPrerequisites(3);

            Console.WriteLine("\n3. Cycle Checking");
            if (CycleExists())
            {
                Console.WriteLine("Cycle Found");
            }
            else
            {
                Console.WriteLine("No Cycle Found");

                Console.WriteLine("\n4. Course Order");
                DisplayTopologicalOrder();
            }

            Console.WriteLine("\n5. Courses with No Prerequisites");
            FirstCourses();

            Console.WriteLine("\n6. Courses depending on Course 2");
            DependentCourses(2);
        }

        // Add an edge to the graph
        static void Connect(int from, int to)
        {
            courses[from].Add(to);
        }

        // Display all direct and indirect prerequisites
        static void ShowAllPrerequisites(int target)
        {
            bool[] found = new bool[6];
            Search(target, found);

            for (int i = 0; i < found.Length; i++)
            {
                if (found[i])
                    Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        // Recursive DFS search
        static void Search(int target, bool[] found)
        {
            for (int i = 0; i < courses.Length; i++)
            {
                if (courses[i].Contains(target))
                {
                    if (!found[i])
                    {
                        found[i] = true;
                        Search(i, found);
                    }
                }
            }
        }

        // Display only direct prerequisites
        static void ShowDirectPrerequisites(int target)
        {
            for (int i = 0; i < courses.Length; i++)
            {
                if (courses[i].Contains(target))
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }

        // Check whether the graph contains a cycle
        static bool CycleExists()
        {
            bool[] visited = new bool[6];
            bool[] stack = new bool[6];

            for (int i = 0; i < 6; i++)
            {
                if (Check(i, visited, stack))
                    return true;
            }

            return false;
        }

        // DFS for cycle detection
        static bool Check(int node, bool[] visited, bool[] stack)
        {
            if (stack[node])
                return true;

            if (visited[node])
                return false;

            visited[node] = true;
            stack[node] = true;

            foreach (int next in courses[node])
            {
                if (Check(next, visited, stack))
                    return true;
            }

            stack[node] = false;
            return false;
        }

        // Display topological order
        static void DisplayTopologicalOrder()
        {
            int[] degree = new int[6];

            for (int i = 0; i < 6; i++)
            {
                foreach (int next in courses[i])
                {
                    degree[next]++;
                }
            }

            Queue<int> q = new Queue<int>();

            for (int i = 0; i < 6; i++)
            {
                if (degree[i] == 0)
                    q.Enqueue(i);
            }

            while (q.Count > 0)
            {
                int current = q.Dequeue();
                Console.Write(current + " ");

                foreach (int next in courses[current])
                {
                    degree[next]--;

                    if (degree[next] == 0)
                        q.Enqueue(next);
                }
            }

            Console.WriteLine();
        }

        // Display courses with no prerequisites
        static void FirstCourses()
        {
            int[] degree = new int[6];

            for (int i = 0; i < 6; i++)
            {
                foreach (int next in courses[i])
                {
                    degree[next]++;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                if (degree[i] == 0)
                    Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        // Count courses that depend on a given course
        static void DependentCourses(int course)
        {
            Console.Write("Courses: ");

            foreach (int item in courses[course])
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Total = " + courses[course].Count);
        }
    }
}