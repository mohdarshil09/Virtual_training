using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RealTimeLogFileProcessor
{
    // 1. LogEntry class
    class LogEntry
    {
        // 2. Properties
        public DateTime Timestamp { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public LogEntry(
            DateTime timestamp,
            string logLevel,
            string message,
            Exception exception = null)
        {
            Timestamp = timestamp;
            LogLevel = logLevel;
            Message = message;
            Exception = exception;
        }
    }

    // 3. LogProcessor class
    class LogProcessor
    {
        private readonly StringBuilder buffer;
        private readonly List<LogEntry> errorLogs;

        private readonly int bufferCapacity;
        private readonly string filePath;

        public LogProcessor(int bufferCapacity, string filePath)
        {
            this.bufferCapacity = bufferCapacity;
            this.filePath = filePath;

            buffer = new StringBuilder();
            errorLogs = new List<LogEntry>();
        }

        // Process one log entry
        public void ProcessLog(LogEntry log)
        {
            // 4. Use StringBuilder to construct log message
            buffer.Append("[");
            buffer.Append(log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
            buffer.Append("] ");

            buffer.Append(log.LogLevel);
            buffer.Append(": ");
            buffer.Append(log.Message);

            // Add exception if available
            if (log.Exception != null)
            {
                buffer.Append(" | Exception: ");
                buffer.Append(log.Exception.Message);
            }

            buffer.AppendLine();

            // 7. Store Error logs separately
            if (log.LogLevel.Equals("ERROR", StringComparison.OrdinalIgnoreCase))
            {
                errorLogs.Add(log);
            }

            // 6. Flush when buffer reaches capacity
            if (buffer.Length >= bufferCapacity)
            {
                FlushBuffer();
            }
        }

        // 5 & 6. Flush buffer to file
        public void FlushBuffer()
        {
            if (buffer.Length == 0)
                return;

            try
            {
                File.AppendAllText(filePath, buffer.ToString());

                Console.WriteLine("Buffer flushed to file.");

                // Clear buffer after writing
                buffer.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while flushing buffer: " + ex.Message);
            }
        }

        // 8. Display error summary
        public void DisplayErrorSummary()
        {
            Console.WriteLine();
            Console.WriteLine("========== ERROR SUMMARY ==========");

            Console.WriteLine("Total Error Logs: " + errorLogs.Count);

            if (errorLogs.Count == 0)
            {
                Console.WriteLine("No errors found.");
                return;
            }

            foreach (LogEntry error in errorLogs)
            {
                Console.WriteLine(
                    $"{error.Timestamp:yyyy-MM-dd HH:mm:ss} - {error.Message}"
                );

                if (error.Exception != null)
                {
                    Console.WriteLine(
                        $"Exception: {error.Exception.Message}"
                    );
                }
            }

            Console.WriteLine("===================================");
        }

        // Make sure remaining logs are written
        public void Close()
        {
            FlushBuffer();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Real-Time Log File Processor ===");
            Console.WriteLine();

            // Output file
            string filePath = "application.log";

            // Buffer capacity
            int bufferCapacity = 200;

            // Create LogProcessor
            LogProcessor processor =
                new LogProcessor(bufferCapacity, filePath);

            // Create log entries
            List<LogEntry> logs = new List<LogEntry>
            {
                new LogEntry(
                    DateTime.Now,
                    "INFO",
                    "Application started."
                ),

                new LogEntry(
                    DateTime.Now,
                    "INFO",
                    "User logged in successfully."
                ),

                new LogEntry(
                    DateTime.Now,
                    "WARNING",
                    "Memory usage is getting high."
                ),

                new LogEntry(
                    DateTime.Now,
                    "ERROR",
                    "Database connection failed.",
                    new Exception("Unable to connect to SQL Server.")
                ),

                new LogEntry(
                    DateTime.Now,
                    "INFO",
                    "Retrying database connection."
                ),

                new LogEntry(
                    DateTime.Now,
                    "ERROR",
                    "File could not be processed.",
                    new Exception("File not found.")
                ),

                new LogEntry(
                    DateTime.Now,
                    "INFO",
                    "Application continues running."
                )
            };

            // Process all logs
            foreach (LogEntry log in logs)
            {
                processor.ProcessLog(log);
            }

            // Flush remaining logs
            processor.Close();

            // Display error summary
            processor.DisplayErrorSummary();

            Console.WriteLine();
            Console.WriteLine("Log processing completed.");
            Console.WriteLine("Log file: " + Path.GetFullPath(filePath));

            Console.ReadLine();
        }
    }
}