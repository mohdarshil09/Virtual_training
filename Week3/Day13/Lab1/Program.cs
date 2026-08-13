using System;

namespace Lab1
{
    public class InventoryItem
    {
        // Private backing field for Quantity
        private int _quantity;

        // Name can only be set during object construction
        public string Name { get; init; }

        // Quantity with validation
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be negative");

                _quantity = value;
            }
        }

        // UnitPrice with validation
        public decimal UnitPrice { get; set; }

        // Computed property - no backing field
        public decimal TotalValue
        {
            get { return Quantity * UnitPrice; }
        }

        // Constructor
        public InventoryItem(string name, int quantity, decimal unitPrice)
        {
            // Validate Name
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace");

            Name = name;

            // Assign through properties so validation runs
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        // Optional Bonus: Restock method
        public void Restock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Restock amount must be greater than zero");

            Quantity += amount;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a valid InventoryItem
            InventoryItem item = new InventoryItem("Keyboard", 3, 45.00m);

            Console.WriteLine(
                $"Created: {item.Name}, Qty={item.Quantity}, " +
                $"Price=${item.UnitPrice:F2}, Total=${item.TotalValue:F2}"
            );

            // Test Quantity validation
            try
            {
                item.Quantity = -5;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(
                    $"Caught expected error setting Quantity=-5: {ex.Message}"
                );
            }

            // Test UnitPrice validation
            try
            {
                item.UnitPrice = 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(
                    $"Caught expected error setting UnitPrice=0: {ex.Message}"
                );
            }
        }
    }
}