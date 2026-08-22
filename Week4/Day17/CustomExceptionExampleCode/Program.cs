using System;

namespace CustomExceptionExampleCode
{
    class MyException : Exception
    {
        public MyException(string Message) : base(Message) { }

        public MyException() { }

        public MyException(string Message, Exception inner)
            : base(Message, inner) { }
    }

    class Program
    {
        public static void Main()
        {
            try
            {
                int age = 15;

                if (age < 18)
                {
                    throw new MyException("Age must be 18 or above.");
                }

                Console.WriteLine("You are eligible.");
            }
            catch (MyException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
        }
    }
}