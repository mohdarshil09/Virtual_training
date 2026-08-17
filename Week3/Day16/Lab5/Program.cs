using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab5
{
    public class LogEntry
    {
        public string Date { get; init; } = string.Empty;
        public string Time { get; init; } = string.Empty;
        public string Level { get; init; } = string.Empty;
        public string Message { get; init; } = string.Empty;
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string rawLog = """
2026-08-14 09:15:00 INFO Service started
2026-08-14 09:16:12 WARN Disk usage high
2026-08-14 09:17:45 ERROR Request failed code=404
2026-08-14 09:18:03 INFO Request completed
2026-08-14 09:19:22 ERROR Upstream error code=500
2026-08-14 09:20:00 INFO Shutdown complete
""";


            // Parse the log
            List<LogEntry> entries =
                ParseLog(rawLog);

            Console.WriteLine(
                $"Parsed {entries.Count} entries."
            );


            // Count entries by Level using LINQ
            var summary = entries
                .GroupBy(entry => entry.Level)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count()
                );

            Console.WriteLine(
                $"Summary: " +
                $"INFO: {summary.GetValueOrDefault("INFO", 0)}, " +
                $"WARN: {summary.GetValueOrDefault("WARN", 0)}, " +
                $"ERROR: {summary.GetValueOrDefault("ERROR", 0)}"
            );


            // Redact error codes
            string redactedLog =
                RedactErrorCodes(rawLog);

            Console.WriteLine();
            Console.WriteLine("--- Redacted log ---");
            Console.WriteLine(redactedLog);
        }


        public static List<LogEntry> ParseLog(string rawLog)
        {
            string pattern =
                @"^(?<date>\d{4}-\d{2}-\d{2})\s+" +
                @"(?<time>\d{2}:\d{2}:\d{2})\s+" +
                @"(?<level>INFO|WARN|ERROR)\s+" +
                @"(?<message>.*)$";

            MatchCollection matches =
                Regex.Matches(
                    rawLog,
                    pattern,
                    RegexOptions.Multiline
                );

            List<LogEntry> entries =
                new List<LogEntry>();

            foreach (Match match in matches)
            {
                LogEntry entry = new LogEntry
                {
                    Date = match.Groups["date"].Value,
                    Time = match.Groups["time"].Value,
                    Level = match.Groups["level"].Value,
                    Message = match.Groups["message"].Value
                };

                entries.Add(entry);
            }

            return entries;
        }


        public static string RedactErrorCodes(string rawLog)
        {
            // Match only ERROR lines and capture code separately.
            string pattern =
                @"^(?<prefix>.*ERROR.*\bcode=)(?<code>\d{3})\b$";

            return Regex.Replace(
                rawLog,
                pattern,
                match =>
                {
                    return match.Groups["prefix"].Value +
                           "###";
                },
                RegexOptions.Multiline
            );
        }


        // Bonus Challenge
        public static IEnumerable<LogEntry> FindErrorsInRange(
            List<LogEntry> entries,
            string startTime,
            string endTime)
        {
            return entries.Where(entry =>
                entry.Level == "ERROR" &&
                string.Compare(
                    entry.Time,
                    startTime,
                    StringComparison.Ordinal
                ) >= 0 &&
                string.Compare(
                    entry.Time,
                    endTime,
                    StringComparison.Ordinal
                ) <= 0
            );
        }
    }
}