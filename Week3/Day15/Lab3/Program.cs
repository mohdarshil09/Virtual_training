using System;

namespace Lab3
{
    public class Subscription
    {
        // Get-only property
        // Can only be assigned inside the constructor
        public string Id { get; }

        // Normal auto-property
        // Can be read and modified from outside
        public string PlanName { get; set; } = string.Empty;

        // Init-only property
        // Can be assigned during object initialization
        // but cannot be changed after construction
        public DateTime StartedAt { get; init; }

        // Public getter + private setter
        // Can be read from outside, but only modified inside this class
        public bool IsActive { get; private set; } = true;

        // Computed property
        // No stored value; calculated whenever accessed
        public int MonthsActive =>
            (DateTime.Now.Year - StartedAt.Year) * 12
            + DateTime.Now.Month - StartedAt.Month;

        public Subscription(string id)
        {
            Id = id;
        }

        public void Cancel()
        {
            IsActive = false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Subscription subscription = new Subscription("SUB-1")
            {
                PlanName = "Pro",
                StartedAt = new DateTime(2026, 1, 1)
            };

            Console.WriteLine(
                $"Id={subscription.Id}, " +
                $"Plan={subscription.PlanName}, " +
                $"Started={subscription.StartedAt:yyyy-MM-dd}, " +
                $"Active={subscription.IsActive}, " +
                $"MonthsActive={subscription.MonthsActive}"
            );

            subscription.Cancel();

            Console.WriteLine(
                $"After Cancel(): Active={subscription.IsActive}"
            );

            // This does NOT compile because IsActive has a private setter:
            // subscription.IsActive = true;

            Console.WriteLine(
                "(subscription.IsActive = true; would NOT compile from outside the class)"
            );

            // This does NOT compile because StartedAt uses init:
            // subscription.StartedAt = DateTime.Now;

            Console.WriteLine(
                "(subscription.StartedAt = DateTime.Now; would NOT compile after construction)"
            );
        }
    }
}