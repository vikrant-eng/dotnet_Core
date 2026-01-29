using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

// ================== IENUMERABLE / COLLECTIONS / TASKS ==================

// ================== IEnumerable ==================

// IEnumerable
// THEORY: Allows sequential read-only iteration over a collection
// REAL WORLD: Reading names from a list one by one
// PURPOSE: Deferred execution, low memory usage
// USE IN .NET: LINQ, EF Core queries
IEnumerable<int> numbers = new List<int> { 1, 2, 3 };

// ================== ICollection ==================

// ICollection
// THEORY: Extends IEnumerable, allows add/remove/count
// REAL WORLD: Editable shopping list
// PURPOSE: Modify collection
// USE IN .NET: In-memory data handling
ICollection<int> collection = new List<int>();

// ================== IList ==================

// IList
// THEORY: Indexed collection with add/remove/update
// REAL WORLD: Playlist where song order matters
// PURPOSE: Random access
// USE IN .NET: Business logic lists
IList<string> list = new List<string>();

// ================== List<T> ==================

// List
// THEORY: Dynamic array
// REAL WORLD: Expanding notebook
// PURPOSE: Fast access, dynamic size
// USE IN .NET: Most common collection
List<int> listData = new List<int> { 1, 2, 3 };

// ================== Dictionary<TKey, TValue> ==================

// Dictionary
// THEORY: Key-value pair collection
// REAL WORLD: Phonebook (Name → Number)
// PURPOSE: Fast lookup
// USE IN .NET: Caching, mapping
Dictionary<int, string> dictionary = new Dictionary<int, string>();

// ================== HashSet ==================

// HashSet
// THEORY: Stores unique values only
// REAL WORLD: Student roll numbers
// PURPOSE: Avoid duplicates
// USE IN .NET: Validation, uniqueness checks
HashSet<int> uniqueItems = new HashSet<int>();

// ================== Queue ==================

// Queue (FIFO)
// THEORY: First In First Out
// REAL WORLD: Line at ticket counter
// PURPOSE: Task processing order
// USE IN .NET: Background jobs
Queue<int> queue = new Queue<int>();

// ================== Stack ==================

// Stack (LIFO)
// THEORY: Last In First Out
// REAL WORLD: Stack of plates
// PURPOSE: Undo/Redo operations
// USE IN .NET: Expression evaluation
Stack<int> stack = new Stack<int>();

// ================== CONCURRENT COLLECTIONS ==================

// ConcurrentDictionary
// THEORY: Thread-safe dictionary
// REAL WORLD: Shared register book with lock
// PURPOSE: High concurrency
// USE IN .NET: Cache in multi-threaded apps
ConcurrentDictionary<int, string> concurrentDict = new ConcurrentDictionary<int, string>();

// ================== TASKS & ASYNC ==================

// Task
// THEORY: Represents asynchronous operation
// REAL WORLD: Ordering food and waiting
// PURPOSE: Non-blocking execution
// USE IN .NET: API calls, background work
Task simpleTask = Task.Run(() => Console.WriteLine("Task running"));

// Task<T>
// THEORY: Async task that returns value
// REAL WORLD: Food delivery returns order
// PURPOSE: Async result
Task<int> valueTask = Task.Run(() => 10);

// async / await
// THEORY: Wait without blocking thread
// REAL WORLD: Doing other work while waiting
async Task AsyncMethod()
{
    await Task.Delay(500);
}

// ================== TYPES OF TASK EXECUTION ==================

// Fire-and-forget Task
// REAL WORLD: Sending email
Task.Run(() => { });

// Parallel Tasks
// REAL WORLD: Multiple workers doing jobs
Task.WhenAll(
    Task.Run(() => { }),
    Task.Run(() => { })
);

// ================== VALUE TASK ==================

// ValueTask
// THEORY: Lightweight Task for high-performance scenarios
// REAL WORLD: Quick reply without full process
// PURPOSE: Reduce memory allocations
// USE IN .NET: High-load APIs
ValueTask<int> fastTask = new ValueTask<int>(5);

// ================== INTERVIEW GOLD SUMMARY ==================
/*
IEnumerable → read-only iteration
List → dynamic array
Dictionary → key-value lookup
HashSet → unique values
Queue → FIFO
Stack → LIFO
ConcurrentDictionary → thread-safe
Task → async work
Task<T> → async with result
ValueTask → high-performance async
*/
