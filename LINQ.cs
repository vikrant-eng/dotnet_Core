using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ================== LINQ DEEP DIVE ==================

// LINQ = Language Integrated Query
// THEORY: Query collections using SQL-like syntax in C#
// REAL WORLD: Searching books in library using filters
// PURPOSE: Simplifies data manipulation and querying
// USE IN .NET: Query Lists, Arrays, Entity Framework (DB)

class LINQExample
{
    public void Run()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        // 1️⃣ LINQ Query Syntax
        var evenNumbersQuery = from n in numbers
                               where n % 2 == 0
                               select n;

        // 2️⃣ LINQ Method Syntax
        var evenNumbersMethod = numbers.Where(n => n % 2 == 0)
                                       .Select(n => n);

        foreach (var n in evenNumbersQuery)
            Console.WriteLine(n); // 2,4,6
    }
}

// ================== IENUMERABLE vs IQUERYABLE ==================

// IEnumerable<T>
// THEORY: Iterates over in-memory collection (LINQ to Objects)
// REAL WORLD: Reading books already on your desk
// PURPOSE: Works with local data, deferred execution
// USE IN .NET: Lists, Arrays, Collections
class IEnumerableExample
{
    public void Run()
    {
        IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        var evens = numbers.Where(x => x % 2 == 0); // deferred execution
    }
}

// IQueryable<T>
// THEORY: Represents queryable data source (can translate to SQL/remote source)
// REAL WORLD: Searching library catalog online → only fetches needed books
// PURPOSE: Executes query at remote source (DB) efficiently
// USE IN .NET: Entity Framework, LINQ to SQL
class IQueryableExample
{
    public void Run(MyDbContext db)
    {
        IQueryable<User> adults = db.Users.Where(u => u.Age >= 18); // executed in DB
    }
}

// ================== KEY DIFFERENCES ==================
/*
Feature            | IEnumerable           | IQueryable
-------------------|--------------------|------------------------
Execution          | In-memory           | Database/remote
Deferred           | Yes                 | Yes
Use                | LINQ to Objects     | LINQ to SQL/EF
Performance        | Medium              | High for DB queries
Methods supported  | LINQ to Objects     | LINQ to SQL
*/

// ================== ADVANCED LINQ OPERATORS ==================

// Filtering → Where
// Projection → Select
// Sorting → OrderBy, OrderByDescending
// Aggregation → Count, Sum, Average, Min, Max
// Joining → Join
// Grouping → GroupBy
// Quantifiers → Any, All
// Element operators → First, Last, Single, ElementAt
// Partitioning → Skip, Take

// ================== DEFERRED vs IMMEDIATE EXECUTION ==================

// Deferred: Query is not executed until iterated
// REAL WORLD: Reserving tickets but not paying until checkout
IEnumerable<int> deferredQuery = numbers.Where(n => n % 2 == 0);

// Immediate: Forces execution
// REAL WORLD: Paying for ticket immediately
List<int> immediateQuery = numbers.Where(n => n % 2 == 0).ToList();

// ================== INTERVIEW GOLD SUMMARY ==================
/*
LINQ → Query collections with SQL-like syntax
IEnumerable → in-memory, local, deferred
IQueryable → remote, DB, efficient
Use IQueryable for EF Core to avoid pulling all data into memory
*/
