// 🚀 SYSTEM DESIGN – READY TO TEST (C# .NET 10)
// 🧠 1️⃣ LRU CACHE (Most Asked)

// Use case:
// 👉 Caching DB/API results
// 👉 Evict least recently used item

class LRUCache
{
    private readonly int capacity;
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> map;
    private readonly LinkedList<(int key, int value)> list;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        map = new Dictionary<int, LinkedListNode<(int, int)>>();
        list = new LinkedList<(int, int)>();
    }

    // ⏱ O(1)
    public int Get(int key)
    {
        if (!map.ContainsKey(key))
            return -1;

        var node = map[key];
        list.Remove(node);
        list.AddFirst(node);

        return node.Value.value;
    }

    // ⏱ O(1)
    public void Put(int key, int value)
    {
        if (map.ContainsKey(key))
        {
            list.Remove(map[key]);
        }
        else if (map.Count == capacity)
        {
            var last = list.Last.Value;
            map.Remove(last.key);
            list.RemoveLast();
        }

        var newNode = new LinkedListNode<(int, int)>((key, value));
        list.AddFirst(newNode);
        map[key] = newNode;
    }
}

// 🧠 2️⃣ RATE LIMITER (API PROTECTION)

// Use case:
// 👉 Prevent abuse
// 👉 100 requests / minute per user

// Token Bucket–style (Simplified)
class RateLimiter
{
    private readonly int limit;
    private readonly TimeSpan window;
    private Queue<DateTime> requests = new Queue<DateTime>();

    public RateLimiter(int limit, TimeSpan window)
    {
        this.limit = limit;
        this.window = window;
    }

    // ⏱ O(1)
    public bool AllowRequest()
    {
        DateTime now = DateTime.Now;

        while (requests.Count > 0 && now - requests.Peek() > window)
            requests.Dequeue();

        if (requests.Count < limit)
        {
            requests.Enqueue(now);
            return true;
        }
        return false;
    }
}

// 🧠 3️⃣ THREAD-SAFE IN-MEMORY CACHE

// Use case:
// 👉 Application-level caching
// 👉 Avoid DB hits
class MemoryCache
{
    private readonly Dictionary<string, string> cache = new();
    private readonly object lockObj = new();

    public void Set(string key, string value)
    {
        lock (lockObj)
        {
            cache[key] = value;
        }
    }

    public string Get(string key)
    {
        lock (lockObj)
        {
            return cache.ContainsKey(key) ? cache[key] : null;
        }
    }
}


// 🧠 4️⃣ SINGLETON LOGGER (THREAD-SAFE)

// Use case:
// 👉 Centralized logging
// 👉 One instance across app
class Logger
{
    private static Logger instance;
    private static readonly object lockObj = new();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (lockObj)
            {
                return instance ??= new Logger();
            }
        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("===== SYSTEM DESIGN TEST =====\n");

        // LRU Cache
        var lru = new LRUCache(2);
        lru.Put(1, 10);
        lru.Put(2, 20);
        Console.WriteLine(lru.Get(1)); // 10
        lru.Put(3, 30);
        Console.WriteLine(lru.Get(2)); // -1 (evicted)

        // Rate Limiter
        var limiter = new RateLimiter(3, TimeSpan.FromSeconds(5));
        Console.WriteLine("\nRate Limiter:");
        for (int i = 1; i <= 5; i++)
            Console.WriteLine($"Request {i}: {limiter.AllowRequest()}");

        // Memory Cache
        var cache = new MemoryCache();
        cache.Set("user", "Amit");
        Console.WriteLine("\nMemory Cache:");
        Console.WriteLine(cache.Get("user"));

        // Singleton Logger
        Console.WriteLine("\nLogger:");
        Logger.Instance.Log("Application started");
        Logger.Instance.Log("Processing request");

        Console.WriteLine("\n===== END =====");
    }
}
