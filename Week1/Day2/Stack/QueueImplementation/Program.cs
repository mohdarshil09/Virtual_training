using System;

namespace QueueImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueueArray q = new QueueArray();

            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);

            Console.WriteLine("Queue Elements:");
            q.Display();

            q.Dequeue();

            Console.WriteLine("\nAfter Dequeue:");
            q.Display();
        }
    }

    class QueueArray
    {
        int[] queue = new int[5];
        int front = 0;
        int rear = -1;

        // Enqueue Operation
        public void Enqueue(int value)
        {
            if (rear == queue.Length - 1)
            {
                Console.WriteLine("Queue Full");
                return;
            }

            queue[++rear] = value;
        }

        // Dequeue Operation
        public void Dequeue()
        {
            if (front > rear)
            {
                Console.WriteLine("Queue Empty");
                return;
            }

            Console.WriteLine("Deleted: " + queue[front++]);
        }

        // Display Operation
        public void Display()
        {
            if (front > rear)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }

            for (int i = front; i <= rear; i++)
            {
                Console.WriteLine(queue[i]);
            }
        }
    }
}