using System.Diagnostics.Metrics;

namespace semaphore2
{
    public class Program
    {
        // Create a SemaphoreSlim instance, allowing a maximum of 3 concurrent accesses.
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(3);
        private static int _sharedResourceAccessCount = 0;

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Starting SemaphoreSlim example...");

            List<Task> tasks = new List<Task>();

            // Create 10 tasks that will try to access the shared resource
            for (int i = 1; i <= 10; i++)
            {
                int taskId = i;
                tasks.Add(AccessSharedResourceAsync(taskId));
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);

            Console.WriteLine($"All tasks completed. Total shared resource accesses: {_sharedResourceAccessCount}");
            Console.ReadLine();
        }

        private static async Task AccessSharedResourceAsync(int taskId)
        {
            Console.WriteLine($"Task {taskId} is waiting to access the shared resource.");

            // Wait to enter the semaphore, potentially blocking if the limit is reached
            await _semaphore.WaitAsync();

            try
            {
                Console.WriteLine($"Task {taskId} has entered the semaphore and is accessing the shared resource.");

                // Simulate work being done on the shared resource
                await Task.Delay(TimeSpan.FromSeconds(1));
                Interlocked.Increment(ref _sharedResourceAccessCount);

                Console.WriteLine($"Task {taskId} has finished accessing the shared resource. Current accesses: {_sharedResourceAccessCount}");
            }
            finally
            {
                // Release the semaphore, allowing another waiting task to proceed
                _semaphore.Release();
                Console.WriteLine($"Task {taskId} has released the semaphore.");
            }
        }
    }
}

//Explanation:
//SemaphoreSlim _semaphore = new SemaphoreSlim(3);: This line initializes a SemaphoreSlim instance named _semaphore
//with an initial count and a maximum count of 3. This means that at most 3 tasks can acquire
//the semaphore and access the protected resource concurrently.
//await _semaphore.WaitAsync();: When a task calls WaitAsync(), it attempts to acquire a slot in the semaphore.
//If the current count is greater than 0, the count is decremented, and the task proceeds immediately.
//If the count is 0 (meaning the maximum number of concurrent accesses is reached),
//the task will asynchronously wait until a slot becomes available (i.e., another task calls Release()).
//_semaphore.Release();: After a task has finished accessing the shared resource,
//it calls Release() to increment the semaphore's count, making a slot available for another waiting task.
//try...finally block: The finally block ensures that _semaphore.Release() is always called,
//even if an exception occurs during the shared resource access, preventing deadlocks.
//Interlocked.Increment(ref _sharedResourceAccessCount);: This safely increments a shared counter variable,
//demonstrating that multiple tasks are indeed accessing the resource.
//This example demonstrates how SemaphoreSlim can be used to effectively control
//the degree of concurrency when multiple tasks need to access a shared resource,
//preventing resource exhaustion or race conditions.
