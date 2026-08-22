using System;
using System.Collections.Generic;

class InsufficientStockException : Exception
{
    public InsufficientStockException(string message)
        : base(message)
    {
    }
}

class Inventory
{
    // Dictionary is suitable because SKU provides direct key-based lookup.
    private Dictionary<string, int> stock =
        new Dictionary<string, int>();

    public void LoadSampleData()
    {
        stock["SKU001"] = 50;
        stock["SKU002"] = 25;
        stock["SKU003"] = 8;
        stock["SKU004"] = 100;
        stock["SKU005"] = 5;
        stock["SKU006"] = 40;
        stock["SKU007"] = 12;
        stock["SKU008"] = 3;
    }

    public void RestockItem(string sku, int quantity)
    {
        if (stock.TryGetValue(sku, out int currentQuantity))
        {
            stock[sku] = currentQuantity + quantity;
        }
        else
        {
            stock[sku] = quantity;
        }

        Console.WriteLine(
            $"Restocked {sku} by {quantity}.");
    }

    public void SellItem(string sku, int quantity)
    {
        if (!stock.TryGetValue(sku, out int currentQuantity))
        {
            Console.WriteLine($"SKU {sku} not found.");
            return;
        }

        if (currentQuantity < quantity)
        {
            throw new InsufficientStockException(
                $"Insufficient stock for {sku}. Available: {currentQuantity}, Requested: {quantity}");
        }

        stock[sku] = currentQuantity - quantity;

        Console.WriteLine(
            $"Sold {quantity} units of {sku}.");
    }

    public void LowStockReport(int threshold)
    {
        Console.WriteLine($"\nLow Stock Items (< {threshold}):");

        foreach (KeyValuePair<string, int> item in stock)
        {
            if (item.Value < threshold)
            {
                Console.WriteLine(
                    $"{item.Key} -> {item.Value}");
            }
        }
    }

    public void PrintInventory()
    {
        foreach (KeyValuePair<string, int> item in stock)
        {
            Console.WriteLine(
                $"{item.Key} -> {item.Value}");
        }
    }
}

class Lab3
{
    static void Main()
    {
        Console.WriteLine("===== LAB 3 =====");

        Inventory inventory = new Inventory();

        inventory.LoadSampleData();

        Console.WriteLine("\nInitial Inventory:");
        inventory.PrintInventory();

        Console.WriteLine("\nSuccessful Restock:");
        inventory.RestockItem("SKU001", 20);

        Console.WriteLine("\nSuccessful Sale:");
        inventory.SellItem("SKU002", 10);

        Console.WriteLine("\nAttempted Oversell:");

        try
        {
            inventory.SellItem("SKU003", 50);
        }
        catch (InsufficientStockException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }

        Console.WriteLine("\nUnknown SKU:");

        try
        {
            inventory.SellItem("SKU999", 5);
        }
        catch (InsufficientStockException ex)
        {
            Console.WriteLine(ex.Message);
        }

        inventory.LowStockReport(10);
    }
}