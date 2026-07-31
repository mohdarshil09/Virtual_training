using System;

namespace StackImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackArray s = new StackArray();

            s.Push(10);
            s.Push(20);
            s.Push(30);

            Console.WriteLine("Stack Elements:");
            s.Display();

            s.Pop();

            Console.WriteLine("After Pop:");
            s.Display();
        }
    }

    class StackArray
    {
        int[] stack = new int[5];
        int top = -1;

        // Push Operation
        public void Push(int value)
        {
            if (top == stack.Length - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }

            stack[++top] = value;
        }

        // Pop Operation
        public void Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }

            Console.WriteLine("Deleted: " + stack[top--]);
        }

        // Display Operation
        public void Display()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return;
            }

            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(stack[i]);
            }
        }
    }
}