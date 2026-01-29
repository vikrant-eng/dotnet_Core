using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

// ================== DEADLOCK vs RACE CONDITION ==================

// 🟠 RACE CONDITION
// THEORY: Multiple threads modify shared data at same time → wrong result
// REAL WORLD: Two people editing same file simultaneously
// FIX: lock / atomic operations / thread-safe collections
class RaceCondition
{
    private int count = 0;

    public void Increment() // ❌ Not thread-safe
    {
        count++;
    }
}

class RaceConditionFixed
{
    private int count = 0;
    private readonly object locker = new object();

    public void Increment() // ✅ Thread-safe
    {
        lock (locker)
        {
            count++;
        }
    }
}

// 🔴 DEADLOCK
// THEORY: Threads wait forever for each other's locks
// REAL WORLD: Two cars blocking each other on narrow road
// FIX: Consistent lock order
class Deadlock
{
    private readonly object lockA = new object();
    private readonly object lockB = new object();

    public void Method1()
    {
        lock (lockA)
        {
            Thread.Sleep(100);
            lock (lockB) { }
        }
    }

    public void Method2()
    {
        lock (lockB)
        {
            Thread.Sleep(100);
            lock (lockA) { }
        }
    }
}

class DeadlockFixed
{
    private readonly object lockA = new object();
    private readonly object lockB = new object();

    public void SafeMethod()
    {
        lock (lockA)
        {
            lock (lockB)
            {
                // safe execution
            }
        }
    }
}

// ================== HIGH-LOAD PRODUCTION BEST PRACTICES ==================

// 1️⃣ Use async/await (non-blocking)
// REAL WORLD: Ordering food while doing other work
class AsyncBestPractice
{
    public async Task RunAsync()
    {
        await Task.Delay(1000); // ✅ non-blocking
    }
}

// 2️⃣ Limit concurrency using SemaphoreSlim
// REAL WORLD: Limited parking slots
class ConcurrencyLimiter
{
    private static SemaphoreSlim semaphore = new SemaphoreSlim(3);

    public async Task AccessAsync()
    {
        await semaphore.WaitAsync();
        try
        {
            await Task.Delay(500);
        }
        finally
        {
            semaphore.Release();
        }
    }
}

// 3️⃣ Use CancellationToken (graceful shutdown)
// REAL WORLD: Emergency stop button
class CancellableWork
{
    public async Task DoWork(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(200, token);
        }
    }
}

// 4️⃣ Use thread-safe collections
// REAL WORLD: Organized storage
class SafeCollection
{
    ConcurrentDictionary<int, string> cache = new ConcurrentDictionary<int, string>();
}

// 5️⃣ Avoid shared static state
// REAL WORLD: Shared notebook causes confusion
class BadPractice
{
    static int globalCounter; // ❌ avoid in production
}

// 6️⃣ Background processing (fire-and-forget)
// REAL WORLD: Kitchen prepares food after order
class BackgroundTask
{
    public void Start()
    {
        Task.Run(() =>
        {
            Thread.Sleep(2000); // heavy work
        });
    }
}

// 7️⃣ Thread-safe Singleton
// REAL WORLD: One control room
class SafeSingleton
{
    private static readonly Lazy<SafeSingleton> instance =
        new Lazy<SafeSingleton>(() => new SafeSingleton());

    public static SafeSingleton Instance => instance.Value;
    private SafeSingleton() { }
}

// ================== INTERVIEW GOLD LINES ==================
// Race Condition → wrong data
// Deadlock → program stuck
// async/await → scalability
// SemaphoreSlim → protect DB
// CancellationToken → graceful shutdown
// Thread-safe collections → high concurrency
// Avoid static state → prevent data corruption
// Background tasks → keep requests fast
// Thread-safe Singleton → single instance across threads
