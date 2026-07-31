using System;

namespace HospitalQueueManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalQueue h = new HospitalQueue();

            while (true)
            {
                Console.WriteLine("\n====================================");
                Console.WriteLine("ABC Hospital Queue Management System");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Call Next Patient");
                Console.WriteLine("3. View Next Patient");
                Console.WriteLine("4. Display Waiting Patients");
                Console.WriteLine("5. Search Patient");
                Console.WriteLine("6. Count Waiting Patients");
                Console.WriteLine("7. Exit");

                Console.Write("Enter Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Patient Name: ");
                         string name = Console.ReadLine();
                        h.Enqueue(name);
                        break;

                    case 2:
                         h.Dequeue();
                         break;

                    case 3:
                        h.Peek();
                        break;

                    case 4:
                        h.Display();
                        break;

                    case 5:
                        Console.Write("Enter Patient Name to Search: ");
                        string search = Console.ReadLine();
                        h.Search(search);
                        break;

                    case 6:
                        h.Count();
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

    class HospitalQueue
    {
        string[] queue = new string[10];
        int front = 0;
        int rear = -1;

        // Register Patient
        public void Enqueue(string name)
        {
            if (rear == queue.Length - 1)
            {
                Console.WriteLine("Queue Full");
                return;
            }

            queue[++rear] = name;
            Console.WriteLine("Patient Registered");
        }

        // Call Next Patient
        public void Dequeue()
        {
            if (front > rear)
            {
                Console.WriteLine("No Patients");
                return;
            }

            Console.WriteLine("Calling: " + queue[front]);
            front++;
        }

        // View Next Patient
        public void Peek()
        {
            if (front > rear)
            {
                Console.WriteLine("No Patients");
                return;
            }

            Console.WriteLine("Next Patient: " + queue[front]);
        }

        // Display Waiting Patients
        public void Display()
        {
            if (front > rear)
            {
                Console.WriteLine("No Waiting Patients");
                return;
            }

            Console.WriteLine("Waiting Patients:");
            for (int i = front; i <= rear; i++)
            {
                Console.WriteLine(queue[i]);
            }
        }

        // Search Patient
        public void Search(string name)
        {
            bool found = false;

            for (int i = front; i <= rear; i++)
            {
                if (queue[i] == name)
                {
                    found = true;
                    break;
                }
            }

            if (found)
                Console.WriteLine("Patient Found");
            else
                Console.WriteLine("Patient Not Found");
        }

        // Count Waiting Patients
        public void Count()
        {
            Console.WriteLine("Waiting Patients: " + (rear - front + 1));
        }
    }
}