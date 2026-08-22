using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== LAB 5 =====");


        // 1. Anonymous method using delegate keyword

        Action<int> square = delegate (int number)
        {
            Console.WriteLine(
                $"Square of {number}: {number * number}");
        };

        square(5);


        // 2. Anonymous method with closure

        int total = 0;

        Action addToTotal = delegate
        {
            total++;
        };

        for (int i = 0; i < 5; i++)
        {
            addToTotal();
        }

        Console.WriteLine(
            $"Total after anonymous method: {total}");


        // 3. Lambda version of square

        Action<int> squareLambda =
            number =>
                Console.WriteLine(
                    $"Square of {number}: {number * number}");

        squareLambda(5);


        // Lambda version of closure

        int lambdaTotal = 0;

        Action addToLambdaTotal = () =>
        {
            lambdaTotal++;
        };

        for (int i = 0; i < 5; i++)
        {
            addToLambdaTotal();
        }

        Console.WriteLine(
            $"Total after lambda: {lambdaTotal}");


        /*
         Anonymous methods use the delegate keyword.

         Lambda expressions use the => syntax.

         Both forms can capture an outer variable and modify it,
         which demonstrates closure behavior.
        */
    }
}