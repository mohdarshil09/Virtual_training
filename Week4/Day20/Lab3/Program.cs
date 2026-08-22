using System;

class Program
{
    // 1. Custom delegate
    public delegate void OrderEvent(string orderId);


    // 2. Event handler methods

    static void LogToConsole(string orderId)
    {
        Console.WriteLine(
            $"Console Log: Order {orderId} received.");
    }

    static void SendEmailSimulation(string orderId)
    {
        Console.WriteLine(
            $"Email Simulation: Email sent for {orderId}.");
    }

    static void UpdateInventorySimulation(string orderId)
    {
        Console.WriteLine(
            $"Inventory Simulation: Inventory updated for {orderId}.");
    }


    static void Main()
    {
        Console.WriteLine("===== LAB 3 =====");


        // 3. Create multicast delegate

        OrderEvent orderHandler = LogToConsole;

        orderHandler += SendEmailSimulation;
        orderHandler += UpdateInventorySimulation;

        Console.WriteLine("\nAll handlers:");

        orderHandler("ORD101");


        // 4. Remove one handler

        orderHandler -= SendEmailSimulation;

        Console.WriteLine("\nAfter removing email handler:");

        orderHandler("ORD102");


        // 5. Lambda reference-equality pitfall

        Console.WriteLine("\nLambda unsubscribe pitfall:");

        OrderEvent lambda1 =
            id => Console.WriteLine($"Lambda Handler: {id}");

        OrderEvent lambda2 =
            id => Console.WriteLine($"Lambda Handler: {id}");

        OrderEvent lambdaHandlers = lambda1;

        lambdaHandlers += lambda2;

        Console.WriteLine("\nBefore unsubscribe:");

        lambdaHandlers("ORD103");


        // Fresh lambda.
        // It has the same body but is a different lambda expression.

        lambdaHandlers -=
            id => Console.WriteLine($"Lambda Handler: {id}");

        Console.WriteLine("\nAfter trying to remove with fresh lambda:");

        lambdaHandlers("ORD104");


        // Correct solution:
        // Store the original delegate reference.

        lambdaHandlers -= lambda1;

        Console.WriteLine("\nAfter removing stored lambda reference:");

        lambdaHandlers("ORD105");
    }
}