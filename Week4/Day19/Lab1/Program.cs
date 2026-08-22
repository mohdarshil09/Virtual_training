using System;
using System.Collections.Generic;

class Program
{
    static (double Average, double Min, double Max) GetStats(
        IEnumerable<double> values)
    {
        double sum = 0;
        double min = double.MaxValue;
        double max = double.MinValue;
        int count = 0;

        foreach (double value in values)
        {
            sum += value;

            if (value < min)
                min = value;

            if (value > max)
                max = value;

            count++;
        }

        if (count == 0)
            return (0, 0, 0);

        return (sum / count, min, max);
    }

    static (bool Success, string? ErrorMessage) TryParseAge(string input)
    {
        if (!int.TryParse(input, out int age))
            return (false, "Input is not a valid number.");

        if (age < 0 || age > 150)
            return (false, "Age must be between 0 and 150.");

        return (true, null);
    }

    static void Main()
    {
        Console.WriteLine("=== Lab 1: Tuples ===");

        // 1 & 2. Get aggregate statistics
        List<double> values = new() { 10, 20, 30, 40, 50 };

        var (avg, min, max) = GetStats(values);

        Console.WriteLine($"Average: {avg}");
        Console.WriteLine($"Minimum: {min}");
        Console.WriteLine($"Maximum: {max}");

        // 3. TryParseAge
        var result = TryParseAge("25");

        if (result.Success)
            Console.WriteLine("Age parsed successfully.");
        else
            Console.WriteLine($"Error: {result.ErrorMessage}");

        // 4. Tic-Tac-Toe board
        Dictionary<(int Row, int Col), string> board = new();

        board[(0, 0)] = "X";
        board[(1, 1)] = "O";
        board[(2, 2)] = "X";

        Console.WriteLine("\nTic-Tac-Toe Board:");

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board.TryGetValue((row, col), out string? value))
                    Console.Write(value + " ");
                else
                    Console.Write("- ");
            }

            Console.WriteLine();
        }
    }
}