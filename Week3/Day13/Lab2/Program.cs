using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    // Abstract base class
    public abstract class NotificationChannel
    {
        public bool TrySend(string message)
        {
            try
            {
                return Send(message);
            }
            catch
            {
                return false;
            }
        }

        protected abstract bool Send(string message);
    }

    // Email implementation
    public class EmailChannel : NotificationChannel
    {
        protected override bool Send(string message)
        {
            return true;
        }
    }

    // SMS implementation
    public class SmsChannel : NotificationChannel
    {
        protected override bool Send(string message)
        {
            if (message.Length > 160)
                throw new Exception("SMS message is too long.");

            return true;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create notification channels
            List<NotificationChannel> channels = new List<NotificationChannel>
            {
                new EmailChannel(),
                new SmsChannel(),
                new EmailChannel(),
                new SmsChannel()
            };

            // Short message
            string shortMessage = "Hello, this is a short message.";

            // Long message
            string longMessage = new string('A', 161);

            // Store results
            List<bool> results = new List<bool>();

            // First two channels use short message
            results.Add(channels[0].TrySend(shortMessage));
            results.Add(channels[1].TrySend(shortMessage));

            // Last two channels use long message
            results.Add(channels[2].TrySend(longMessage));
            results.Add(channels[3].TrySend(longMessage));

            // Anonymous-type report using LINQ
            var report = channels
                .Select((channel, index) => new
                {
                    ChannelType = channel.GetType().Name,
                    Success = results[index]
                });

            // Print report
            foreach (var entry in report)
            {
                Console.WriteLine(
                    $"{entry.ChannelType}: {(entry.Success ? "Success" : "Failed")}"
                );
            }

            // Count successes and failures
            int succeeded = report.Count(x => x.Success);
            int failed = report.Count(x => !x.Success);

            Console.WriteLine();
            Console.WriteLine($"Succeeded: {succeeded}, Failed: {failed}");
        }
    }
}