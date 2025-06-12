using System.Diagnostics;

namespace LoggingSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            bool isExit = false;

            while (!isExit)
            {
                CompareSyncAndAsyncLoggers();
                Console.WriteLine("Choose Logging Method:");
                Console.WriteLine("1. Shared Log File (thread-safe)");
                Console.WriteLine("2. Independent Log File Per User");
                Console.Write("Enter choice (1 or 2): ");
                int choice = LoggerUtils.ReadChoice();

                Console.Write("\nEnter number of users to simulate: ");
                int userCount = LoggerUtils.ReadIntInput();

                Console.Write("\nEnter the error message to log: ");
                string errorMessage = Console.ReadLine() ?? "Default Error Message";

                Console.Write("\nEnter the file path to log shared log messages: ");
                string filePath = Console.ReadLine() ?? "logger.log";

                Console.WriteLine("\nLogging in progress...");

                var logger = new Logger(filePath);
                var stopwatch = Stopwatch.StartNew();

                if (choice == 1)
                {
                    var tasks = Enumerable.Range(0, userCount)
                        .Select(i => logger.LogAsyncWithThreadSafety($"User{i}: {errorMessage}{Environment.NewLine}"));
                    await Task.WhenAll(tasks);
                }
                else if (choice == 2)
                {
                    var tasks = Enumerable.Range(0, userCount)
                        .Select(i => logger.LogErrorAsyncInUserSpecificFile($"user{i}", $"{errorMessage}{Environment.NewLine}"));
                    await Task.WhenAll(tasks);
                }
                else
                {
                    isExit = true;
                }

                stopwatch.Stop();

                Console.WriteLine($"\nDone! Logging completed in {stopwatch.ElapsedMilliseconds} ms.");

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.WriteLine("\n\n=========================================================================================\n\n");
            }
        }

        public static void CompareSyncAndAsyncLoggers()
        {
            Console.Write("\nEnter the error message to log: ");
            string errorMessage = Console.ReadLine() ?? "Default Error Message";

            Console.Write("\nEnter the file path to log shared log messages: ");
            string filePath = Console.ReadLine() ?? "logger.log";
            var logger = new Logger(filePath);
            Console.WriteLine("---Sync logger---");
            var stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            logger.LogErrorInefficiently(errorMessage);
            stopwatch.Stop();
            Console.WriteLine("TimeTake: " + stopwatch.ElapsedMilliseconds + "ms");
            Console.WriteLine("---Async logger---");
            var stopwatch2 = Stopwatch.StartNew();
            stopwatch2.Start();
            logger.LogErrorInefficiently(errorMessage);
            stopwatch2.Stop();
            Console.WriteLine("TimeTake: " + stopwatch2.ElapsedMilliseconds + "ms");

        }
    }
}
