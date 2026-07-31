using System;

using System.Collections.Generic;

namespace SocialNetworkFriendRecommendations
{
    internal class Program
    {
        // Adjacency list to store friendships
        static List<int>[] network = new List<int>[6];

        static void Main(string[] args)
        {
            // Initialize the graph
            for (int i = 0; i < network.Length; i++)
            {
                network[i] = new List<int>();
            }

            // Add friendships
            CreateFriendship(0, 1);
            CreateFriendship(0, 2);
            CreateFriendship(1, 3);
            CreateFriendship(2, 3);
            CreateFriendship(2, 4);
            CreateFriendship(3, 5);
            CreateFriendship(4, 5);

              Console.WriteLine("SOCIAL NETWORK");

             Console.WriteLine("\n1. Friends of User 2");
            PrintFriends(2);

            Console.WriteLine("\n2. User 0 and User 5 Connection");
              Console.WriteLine(AreConnected(0, 5) ? "Connected" : "Not Connected");

            Console.WriteLine("\n3. Shortest Path");
            PrintShortestRoute(0, 5);

            Console.WriteLine("\n4. Users at Distance 2 from User 1");
            PrintDistanceTwo(1);

            Console.WriteLine("\n5. Cycle Check");
            Console.WriteLine(ContainsCycle() ? "Cycle Found" : "No Cycle");

            Console.WriteLine("\n6. Friend Groups");
            ShowGroups();
        }

        // Add friendship between two users
        static void CreateFriendship(int user1, int user2)
        {
            network[user1].Add(user2);
            network[user2].Add(user1);
        }

        // Display all friends of a user
        static void PrintFriends(int user)
        {
            foreach (int friend in network[user])
            {
                Console.Write(friend + " ");
            }

            Console.WriteLine();
        }

        // Check whether two users are connected
        static bool AreConnected(int start, int end)
        {
            bool[] visited = new bool[network.Length];
            Queue<int> queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int user = queue.Dequeue();

                if (user == end)
                    return true;

                foreach (int friend in network[user])
                {
                    if (!visited[friend])
                    {
                        visited[friend] = true;
                        queue.Enqueue(friend);
                    }
                }
            }

            return false;
        }

        // Find the shortest path using BFS
        static void PrintShortestRoute(int start, int end)
        {
            bool[] visited = new bool[network.Length];
              int[] previous = new int[network.Length];

            for (int i = 0; i < previous.Length; i++)
            {
                previous[i] = -1;
            }

            Queue<int> queue = new Queue<int>();
            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                 int user = queue.Dequeue();

                if (user == end)
                    break;

                foreach (int friend in network[user])
                {
                    if (!visited[friend])
                    {
                        visited[friend] = true;
                        previous[friend] = user;
                        queue.Enqueue(friend);
                    }
                }
            }

            List<int> path = new List<int>();
             int current = end;

            while (current != -1)
            {
                path.Add(current);
                current = previous[current];
            }

            path.Reverse();

            foreach (int user in path)
            {
                Console.Write(user);

                if (user != path[path.Count - 1])
                    Console.Write(" -> ");
            }

            Console.WriteLine();
        }

        // Find users at distance 2
        static void PrintDistanceTwo(int start)
        {
            bool[] visited = new bool[network.Length];
            int[] distance = new int[network.Length];

            Queue<int> queue = new Queue<int>();
             visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int user = queue.Dequeue();

                foreach (int friend in network[user])
                {
                    if (!visited[friend])
                    {
                        visited[friend] = true;
                        distance[friend] = distance[user] + 1;
                        queue.Enqueue(friend);
                    }
                }
            }

            for (int i = 0; i < distance.Length; i++)
            {
                 if (distance[i] == 2)
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }

        // Check whether the graph has a cycle
        static bool ContainsCycle()
        {
            bool[] visited = new bool[network.Length];

            for (int i = 0; i < network.Length; i++)
            {
                if (!visited[i])
                {
                    if (CheckCycle(i, -1, visited))
                        return true;
                }
            }

            return false;
        }

        // DFS helper for cycle detection
        static bool CheckCycle(int user, int parent, bool[] visited)
        {
            visited[user] = true;

            foreach (int friend in network[user])
            {
                if (!visited[friend])
                {
                    if (CheckCycle(friend, user, visited))
                        return true;
                }
                else if (friend != parent)
                {
                     return true;
                }
            }

            return false;
        }

        // Display all connected friend groups
        static void ShowGroups()
        {
             bool[] visited = new bool[network.Length];

            for (int i = 0; i < network.Length; i++)
            {
                if (!visited[i])
                {
                    Queue<int> queue = new Queue<int>();
                     queue.Enqueue(i);
                    visited[i] = true;

                    while (queue.Count > 0)
                    {
                        int user = queue.Dequeue();
                        Console.Write(user + " ");

                        foreach (int friend in network[user])
                        {
                            if (!visited[friend])
                            {
                                visited[friend] = true;
                                queue.Enqueue(friend);
                            }
                        }
                    }


                    Console.WriteLine();
                }
            }
        }
    }
}