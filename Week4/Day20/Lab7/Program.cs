using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== LAB 7 =====");


        // 1. Buggy for loop

        List<Action> buggyActions = new List<Action>();

        for (int i = 0; i < 3; i++)
        {
            buggyActions.Add(
                () => Console.WriteLine(
                    $"Index: {i}")
            );
        }

        Console.WriteLine("\nBuggy for loop:");

        foreach (Action action in buggyActions)
        {
            action();
        }


        /*
         The lambda captures the loop variable i.

         All delegates refer to the same captured variable.
         After the loop finishes, i is 3, so all delegates print 3.
        */


        // 2. Fixed for loop

        List<Action> fixedActions = new List<Action>();

        for (int i = 0; i < 3; i++)
        {
            int index = i;

            fixedActions.Add(
                () => Console.WriteLine(
                    $"Index: {index}")
            );
        }

        Console.WriteLine("\nFixed for loop:");

        foreach (Action action in fixedActions)
        {
            action();
        }


        /*
         index is a new local variable for every iteration.

         Each lambda captures its own index variable,
         so the output is 0, 1, and 2.
        */


        // 3. Foreach loop

        List<Action> foreachActions = new List<Action>();

        foreach (int number in new[] { 0, 1, 2 })
        {
            foreachActions.Add(
                () => Console.WriteLine(
                    $"Index: {number}")
            );
        }

        Console.WriteLine("\nForeach loop:");

        foreach (Action action in foreachActions)
        {
            action();
        }


        /*
         Modern C# creates a separate iteration variable
         for each foreach iteration.

         Therefore, each lambda captures the expected value.
        */
    }
}