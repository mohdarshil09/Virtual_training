using System;

namespace Lab3
{
    public class Appointment
    {
        // Properties
        public string Title { get; }
        public DateTime Start { get; }
        public TimeSpan Duration { get; }
        public string Location { get; }

        // Static field
        public static int DefaultDurationMinutes;


        // Static constructor
        static Appointment()
        {
            Console.WriteLine(
                "Appointment type initialized. Default duration set to 30 minutes."
            );

            DefaultDurationMinutes = 30;
        }


        // Full constructor
        public Appointment(
            string title,
            DateTime start,
            TimeSpan duration,
            string location)
        {
            Title = title;
            Start = start;
            Duration = duration;
            Location = location;
        }


        // Two-argument constructor
        // Chains to the full constructor
        public Appointment(string title, DateTime start)
            : this(
                title,
                start,
                TimeSpan.FromMinutes(DefaultDurationMinutes),
                "TBD")
        {
        }


        // One-argument constructor
        // Chains to the two-argument constructor
        public Appointment(string title)
            : this(title, DateTime.Now.AddDays(1))
        {
        }


        // Display appointment details
        public void PrintDetails(string type)
        {
            Console.WriteLine(
                $"{type}: {Title} @ {Start:yyyy-MM-dd HH:mm}, " +
                $"{Duration.TotalMinutes:0} min, {Location}"
            );
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Full constructor
            Appointment fullAppointment = new Appointment(
                "Standup",
                new DateTime(2026, 8, 12, 9, 0, 0),
                TimeSpan.FromMinutes(30),
                "Room 4"
            );

            fullAppointment.PrintDetails("Full");


            // 2. Two-argument constructor
            Appointment twoArgAppointment = new Appointment(
                "Client Call",
                new DateTime(2026, 8, 12, 14, 0, 0)
            );

            twoArgAppointment.PrintDetails("Two-arg");


            // 3. One-argument constructor
            Appointment oneArgAppointment = new Appointment(
                "Follow Up"
            );

            oneArgAppointment.PrintDetails("One-arg");


            // Static field
            Console.WriteLine(
                $"DefaultDurationMinutes: {Appointment.DefaultDurationMinutes}"
            );
        }
    }
}