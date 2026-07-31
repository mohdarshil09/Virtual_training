using System;
using System.Collections.Generic;

namespace CustomerSupportTicketManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Queue to store support tickets
            Queue<string> tickets = new Queue<string>();

            // Add tickets
            tickets.Enqueue("T001|John|Login Issue");
            tickets.Enqueue("T002|Alice|Payment Failed");
            tickets.Enqueue("T003|David|Account Locked");
            tickets.Enqueue("T004|Sara|Login Issue");
            tickets.Enqueue("T005|Mike|Password Reset");

            Console.WriteLine("CUSTOMER SUPPORT TICKET MANAGEMENT");

            // Task 1
            Console.WriteLine("\n1. Tickets Added Successfully.");

            // Task 2
            Console.WriteLine("\n2. All Tickets");
            foreach (string ticket in tickets)
            {
                Console.WriteLine(ticket);
            }

            // Task 3
            Console.WriteLine("\n3. Processing First Ticket");
            if (tickets.Count > 0)
            {
                Console.WriteLine("Processed: " + tickets.Dequeue());
            }

            // Task 4
            Console.WriteLine("\n4. Next Ticket");
            if (tickets.Count > 0)
            {
                Console.WriteLine(tickets.Peek());
            }

            // Task 5
            Console.WriteLine("\n5. Queue Count");
            Console.WriteLine("Total Tickets: " + tickets.Count);

            // Task 6
            Console.WriteLine("\n6. Search Ticket by ID");
            string searchId = "T003";
            bool found = false;

            foreach (string ticket in tickets)
            {
                string[] data = ticket.Split('|');

                if (data[0] == searchId)
                {
                    Console.WriteLine("Ticket Found: " + ticket);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Ticket Not Found");
            }

            // Task 7
            Console.WriteLine("\n7. Count Tickets by Issue Type");

            Dictionary<string, int> issueCount = new Dictionary<string, int>();

            foreach (string ticket in tickets)
            {
                string[] data = ticket.Split('|');
                string issue = data[2];

                if (issueCount.ContainsKey(issue))
                {
                    issueCount[issue]++;
                }
                else
                {
                    issueCount[issue] = 1;
                }
            }

            foreach (var item in issueCount)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }

            // Task 8
            Console.WriteLine("\n8. Removing All Remaining Tickets");

            while (tickets.Count > 0)
            {
                Console.WriteLine("Removed: " + tickets.Dequeue());
            }

            Console.WriteLine("Remaining Tickets: " + tickets.Count);
        }
    }
}