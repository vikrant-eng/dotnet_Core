
class Program
{
    static void Main()
    {
        Console.WriteLine("========== NEXT LEVEL ALGORITHMS TEST ==========\n");

        // Sliding Window
        Console.WriteLine("1. Longest Unique Substring:");
        Console.WriteLine(LongestUniqueSubstring("abcabcbb")); // 3

        // Dynamic Programming
        Console.WriteLine("\n2. Fibonacci:");
        Console.WriteLine(Fibonacci(10)); // 55

        Console.WriteLine("\n3. Climbing Stairs:");
        Console.WriteLine(ClimbStairs(5)); // 8

        // Backtracking
        Console.WriteLine("\n4. Generate Subsets:");
        GenerateSubsets(new int[] { 1, 2, 3 });

        // Stack
        Console.WriteLine("\n5. Valid Parentheses:");
        Console.WriteLine(IsValidParentheses("({[]})")); // True

        // Greedy
        Console.WriteLine("\n6. Activity Selection:");
        Console.WriteLine(ActivitySelection(
            new int[] { 1, 3, 0, 5, 8, 5 },
            new int[] { 2, 4, 6, 7, 9, 9 })); // 4

        // Bit Manipulation
        Console.WriteLine("\n7. Single Number:");
        Console.WriteLine(SingleNumber(new int[] { 4, 1, 2, 1, 2 })); // 4

        // Hashing
        Console.WriteLine("\n8. Two Sum:");
        Console.WriteLine(TwoSum(new int[] { 2, 7, 11, 15 }, 9)); // True

        // Kadane
        Console.WriteLine("\n9. Max Subarray Sum:");
        Console.WriteLine(MaxSubArraySum(new int[] { -2,1,-3,4,-1,2,1,-5,4 })); // 6

        // Stock
        Console.WriteLine("\n10. Max Stock Profit:");
        Console.WriteLine(MaxProfit(new int[] { 7,1,5,3,6,4 })); // 5

        // Graph
        Console.WriteLine("\n11. DFS Traversal:");
        var graph = new Dictionary<int, List<int>>
        {
            { 0, new List<int>{1,2} },
            { 1, new List<int>{0,3} },
            { 2, new List<int>{0} },
            { 3, new List<int>{1} }
        };
        DFS(0, graph, new HashSet<int>());
        Console.WriteLine();

        Console.WriteLine("\n12. BFS Traversal:");
        BFS(0, graph);

        Console.WriteLine("\n\n========== END ==========");
    }

    // ---------------------------------------------------------
    // Sliding Window – Longest Unique Substring
    // ⏱ O(n) | 🧠 O(n)
    static int LongestUniqueSubstring(string s)
    {
        HashSet<char> set = new HashSet<char>();
        int left = 0, maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            while (set.Contains(s[right]))
                set.Remove(s[left++]);

            set.Add(s[right]);
            maxLen = Math.Max(maxLen, right - left + 1);
        }
        return maxLen;
    }

    // ---------------------------------------------------------
    // Dynamic Programming – Fibonacci
    // ⏱ O(n) | 🧠 O(1)
    static int Fibonacci(int n)
    {
        if (n <= 1) return n;

        int a = 0, b = 1;
        for (int i = 2; i <= n; i++)
        {
            int c = a + b;
            a = b;
            b = c;
        }
        return b;
    }

    // ---------------------------------------------------------
    // Dynamic Programming – Climbing Stairs
    // ⏱ O(n) | 🧠 O(1)
    static int ClimbStairs(int n)
    {
        if (n <= 2) return n;

        int a = 1, b = 2;
        for (int i = 3; i <= n; i++)
        {
            int c = a + b;
            a = b;
            b = c;
        }
        return b;
    }

    // ---------------------------------------------------------
    // Backtracking – Generate Subsets
    // ⏱ O(2^n) | 🧠 O(n)
    static void GenerateSubsets(int[] nums)
    {
        void Backtrack(int index, List<int> current)
        {
            Console.WriteLine("[" + string.Join(",", current) + "]");
            for (int i = index; i < nums.Length; i++)
            {
                current.Add(nums[i]);
                Backtrack(i + 1, current);
                current.RemoveAt(current.Count - 1);
            }
        }
        Backtrack(0, new List<int>());
    }

    // ---------------------------------------------------------
    // Stack – Valid Parentheses
    // ⏱ O(n) | 🧠 O(n)
    static bool IsValidParentheses(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(' || c == '{' || c == '[')
                stack.Push(c);
            else
            {
                if (stack.Count == 0) return false;
                char top = stack.Pop();
                if ((c == ')' && top != '(') ||
                    (c == '}' && top != '{') ||
                    (c == ']' && top != '['))
                    return false;
            }
        }
        return stack.Count == 0;
    }

    // ---------------------------------------------------------
    // Greedy – Activity Selection
    // ⏱ O(n) | 🧠 O(1)
    static int ActivitySelection(int[] start, int[] end)
    {
        int count = 1;
        int lastEnd = end[0];

        for (int i = 1; i < start.Length; i++)
        {
            if (start[i] >= lastEnd)
            {
                count++;
                lastEnd = end[i];
            }
        }
        return count;
    }

    // ---------------------------------------------------------
    // Bit Manipulation – Single Number
    // ⏱ O(n) | 🧠 O(1)
    static int SingleNumber(int[] nums)
    {
        int res = 0;
        foreach (int n in nums)
            res ^= n;
        return res;
    }

    // ---------------------------------------------------------
    // Hashing – Two Sum
    // ⏱ O(n) | 🧠 O(n)
    static bool TwoSum(int[] nums, int target)
    {
        HashSet<int> set = new HashSet<int>();
        foreach (int n in nums)
        {
            if (set.Contains(target - n))
                return true;
            set.Add(n);
        }
        return false;
    }

    // ---------------------------------------------------------
    // Kadane’s Algorithm – Max Subarray Sum
    // ⏱ O(n) | 🧠 O(1)
    static int MaxSubArraySum(int[] nums)
    {
        int max = nums[0], curr = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            curr = Math.Max(nums[i], curr + nums[i]);
            max = Math.Max(max, curr);
        }
        return max;
    }

    // ---------------------------------------------------------
    // Greedy – Stock Buy Sell
    // ⏱ O(n) | 🧠 O(1)
    static int MaxProfit(int[] prices)
    {
        int min = int.MaxValue, profit = 0;
        foreach (int p in prices)
        {
            min = Math.Min(min, p);
            profit = Math.Max(profit, p - min);
        }
        return profit;
    }

    // ---------------------------------------------------------
    // Graph – DFS
    // ⏱ O(V + E) | 🧠 O(V)
    static void DFS(int node, Dictionary<int, List<int>> graph, HashSet<int> visited)
    {
        if (visited.Contains(node)) return;
        visited.Add(node);
        Console.Write(node + " ");
        foreach (var n in graph[node])
            DFS(n, graph, visited);
    }

    // ---------------------------------------------------------
    // Graph – BFS
    // ⏱ O(V + E) | 🧠 O(V)
    static void BFS(int start, Dictionary<int, List<int>> graph)
    {
        Queue<int> q = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();

        q.Enqueue(start);
        visited.Add(start);

        while (q.Count > 0)
        {
            int node = q.Dequeue();
            Console.Write(node + " ");
            foreach (var n in graph[node])
            {
                if (!visited.Contains(n))
                {
                    visited.Add(n);
                    q.Enqueue(n);
                }
            }
        }
    }
}