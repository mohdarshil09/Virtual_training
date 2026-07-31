using System;

namespace BrowserHistoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BrowserHistory b = new BrowserHistory();

            while (true)
            {


                Console.WriteLine("\n=================================");
                Console.WriteLine("Browser History System");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Visit Page");
                Console.WriteLine("2. Back");
                Console.WriteLine("3. Current Page");
                Console.WriteLine("4. Display History");
                Console.WriteLine("5. Clear History");
                Console.WriteLine("6. Total Pages");
                Console.WriteLine("7. Exit");

                Console.Write("Enter Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Website: ");
                        string page = Console.ReadLine();
                        b.Push(page);
                        break;

                    case 2:
                        b.Pop();
                        break;

                    case 3:
                        b.CurrentPage();
                        break;

                    case 4:
                        b.Display();
                        break;

                    case 5:
                        b.Clear();
                        break;

                    case 6:
                        b.TotalPages();
                        break;

                    case 7:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }

    class BrowserHistory
    {
        string[] history = new string[10];
        int top = -1;

        // Visit Page
        public void Push(string page)
        {
            if (top == history.Length - 1)
            {
                Console.WriteLine("History Full");
                return;
            }

            history[++top] = page;
            Console.WriteLine("Visited: " + page);
        }

        // Back
        public void Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("No History");
                return;
            }

            Console.WriteLine("Back from: " + history[top--]);
        }

        // Current Page
        public void CurrentPage()
        {
            if (top == -1)
            {
                Console.WriteLine("No Current Page");
                return;
            }

            Console.WriteLine("Current Page: " + history[top]);
        }

        // Display History
        public void Display()
        {
            if (top == -1)
            {
                Console.WriteLine("History Empty");
                return;
            }

            Console.WriteLine("History:");
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(history[i]);
            }
        }

        // Clear History
        public void Clear()
        {
            top = -1;
            Console.WriteLine("History Cleared");
        }

        // Total Pages
        public void TotalPages()
        {
            Console.WriteLine("Total Pages: " + (top + 1));
        }
    }
}
