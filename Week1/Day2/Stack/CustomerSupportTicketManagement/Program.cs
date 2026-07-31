using System;
using System.Collections.Generic;

namespace CustomerSupportTicketManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> ticketQueue = new Queue<string>();

            // Task 1: Enqueue Tickets
            ticketQueue.Enqueue("T001|John|Login Issue");
            ticketQueue.Enqueue("T002|Alice|Payment Failed");
            ticketQueue.Enqueue("T003|David|Account Locked");
            ticketQueue.Enqueue("T004|Emma|Refund Request");
            ticketQueue.Enqueue("T005|James|Password Reset");

            Console.WriteLine("Task 1: Enqueue Tickets");
            Console.WriteLine("Expected Output\n");

            foreach (string ticket in ticketQueue)
            {
                string[] data = ticket.Split('|');
                Console.WriteLine(data[0]);
            }

            Console.WriteLine();

            // Task 2: Display All Tickets
            Console.WriteLine("Task 2: Display All Tickets");
            Console.WriteLine("Expected Output\n");

            foreach (string ticket in ticketQueue)
            {
                string[] data = ticket.Split('|');
                Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
            }

            Console.WriteLine();

            // Task 3: Process First Ticket
            Console.WriteLine("Task 3: Process First Ticket");
            Console.WriteLine("Expected Output\n");

            string ticketProcessed = ticketQueue.Dequeue();
            string[] data1 = ticketProcessed.Split('|');

            Console.WriteLine(data1[0] + " " + data1[1] + " " + data1[2]);

            Console.WriteLine();

           Console.WriteLine("Task 5: Check queue count");
            Console.WriteLine("Pending tickets:" + ticketQueue.Count);

            Console.WriteLine();

            Console.WriteLine("Task 6: Search Ticket by ID");
            String searchId = "T004";
            bool found = false;
            foreach (string ticket in ticketQueue)
            {
                string[] data = ticket.Split("|");
                if(data[0] == searchId)
                {
                    Console.WriteLine("Ticket Found");
                    Console.WriteLine("Customer :" + data[1]);
                    Console.WriteLine("Issue :" + data[2]);
                    found = true;
                    break;
                }

            }

        }
    }
}