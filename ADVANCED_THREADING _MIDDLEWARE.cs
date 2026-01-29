using System;
using System.Threading;
using System.Threading.Tasks;

// ================== ADVANCED THREADING + MIDDLEWARE ==================

// 🔹 CASE 1: Async Middleware with Thread-safe request handling
// THEORY: Middleware executes asynchronously without blocking threads
// REAL WORLD: Toll booth with multiple lanes — cars pass in parallel
// PURPOSE: High performance, non-blocking request processing
// USE IN .NET CORE: Logging, Auth, Rate limiting
class AsyncMiddleware
{
    public async Task InvokeAsync()
    {
        await Task.Delay(10); // async non-blocking call
    }
}

// 🔹 CASE 2: SemaphoreSlim (Concurrency Control)
// THEORY: Limits number of threads accessing a resource
// REAL WORLD: Parking lot with limited slots
// PURPOSE: Prevent DB overload, API throttling
// USE IN .NET CORE: Rate limiting, file access
class LimitedAccess
{
    private static SemaphoreSlim semaphore = new SemaphoreSlim(2); // allow 2 threads

    public async Task AccessAsync()
    {
        await semaphore.WaitAsync(); // lock entry
        try
        {
            await Task.Delay(1000); // critical section
        }
        finally
        {
            semaphore.Release(); // unlock
        }
    }
}

// 🔹 CASE 3: Background Worker (Fire-and-Forget)
// THEORY: Long-running task runs in background thread
// REAL WORLD: Kitchen preparing food after order is placed
// PURPOSE: Keep request fast, move heavy work to background
// USE IN .NET CORE: Email sending, report generation
class BackgroundWorker
{
    public void Start()
    {
        Task.Run(() =>
        {
            Thread.Sleep(2000); // heavy work
        });
    }
}

// 🔹 CASE 4: CancellationToken (Graceful Shutdown)
// THEORY: Allows safe cancellation of running threads
// REAL WORLD: Emergency stop button
// PURPOSE: Stop tasks when app shuts down
// USE IN .NET CORE: API timeout, app shutdown
class CancellableTask
{
    public async Task RunAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(500);
        }
    }
}

// 🔹 CASE 5: Thread-safe Singleton using Lazy<T>
// THEORY: Ensures only one instance across threads
// REAL WORLD: One central power switch
// PURPOSE: Safe shared resources
// USE IN .NET CORE: Cache, Config manager
class SafeSingleton
{
    private static readonly Lazy<SafeSingleton> instance =
        new Lazy<SafeSingleton>(() => new SafeSingleton());

    public static SafeSingleton Instance => instance.Value;

    private SafeSingleton() { }
}

// 🔹 CASE 6: Parallel Processing
// THEORY: Executes tasks in parallel on multiple threads
// REAL WORLD: Multiple workers packing boxes
// PURPOSE: Faster processing of large data
// USE IN .NET CORE: Data processing, batch jobs
class ParallelExample
{
    public void Run()
    {
        Parallel.For(0, 5, i =>
        {
            Console.WriteLine($"Task {i}");
        });
    }
}

// 🔹 CASE 7: Thread-safe Middleware Counter
// THEORY: Shared data protected using lock
// REAL WORLD: Token counter at bank
// PURPOSE: Avoid race condition
// USE IN .NET CORE: Metrics, request counters
class RequestCounterMiddleware
{
    private static int count = 0;
    private static readonly object locker = new object();

    public void Increment()
    {
        lock (locker)
        {
            count++;
        }
    }
}
// 🔹 CASE 8: Using AsyncLocal for per-request data
// THEORY: Data scoped to async context
// REAL WORLD: Personal locker for each gym member
// PURPOSE: Store request-specific data safely
// USE IN .NET CORE: User context, correlation IDs
class RequestContext
{
    private static AsyncLocal<string> _correlationId = new AsyncLocal<string>();
    public static string CorrelationId
    {
        get => _correlationId.Value;
        set => _correlationId.Value = value;
    }
}
// 🔹 CASE 9: Custom Middleware Pipeline
// THEORY: Chain of middleware components processing requests
// REAL WORLD: Assembly line with multiple stations
// PURPOSE: Modular request processing
// USE IN .NET CORE: Auth, Logging, Routing
class CustomMiddleware
{
    private readonly Func<Task> _next;
    public CustomMiddleware(Func<Task> next)
    {
        _next = next;
    }
    public async Task InvokeAsync()
    {
        // Pre-processing
        await _next(); // Call next middleware
        // Post-processing
    }
}
// 🔹 CASE 10: Using ReaderWriterLockSlim for read-heavy scenarios
// THEORY: Allows multiple concurrent reads but exclusive writes
// REAL WORLD: Library reading room with one librarian
// PURPOSE: Optimize read performance while ensuring data integrity
// USE IN .NET CORE: Caching, Configuration management
class ReadWriteExample
{
    private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    private int _data;  
    public int ReadData()
    {
        _lock.EnterReadLock();
        try
        {
            return _data;
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }
    public void WriteData(int value)
    {
        _lock.EnterWriteLock();
        try
        {
            _data = value;
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
}
// ================== END OF ADVANCED THREADING + MIDDLEWARE ==================