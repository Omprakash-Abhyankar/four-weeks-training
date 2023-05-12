namespace AsyncAwaitBasics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Call PerformCalculations and measure time taken using Stopwatch
            int numberOfTasks = 5;
            Console.WriteLine($"Starting {numberOfTasks} long-running tasks...");
            Stopwatch stopwatch = Stopwatch.StartNew();
            await PerformCalculations(numberOfTasks);
            stopwatch.Stop();
            Console.WriteLine($"Time taken to complete all tasks: {stopwatch.Elapsed}");

        }

        static async Task SimulateLongRunningTask(int delayInSeconds)
        {
            // Implement long-running task simulation
            Console.WriteLine($"Starting long-running task with delay of {delayInSeconds} seconds...");
            await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
            Console.WriteLine($"Long-running task with delay of {delayInSeconds} seconds completed.");

        }

        static async Task PerformCalculations(int numberOfTasks)
        {
            // Start long-running tasks concurrently and wait for them to complete

            Console.WriteLine($"Starting {numberOfTasks} long-running tasks...");
            Task[] tasks = new Task[numberOfTasks];
            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks[i] = SimulateLongRunningTask(i + 1);
            }
            await Task.WhenAll(tasks);
            Console.WriteLine($"All {numberOfTasks} long-running tasks completed.");


        }
    }
}