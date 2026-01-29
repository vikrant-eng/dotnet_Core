
class Program
{
    static void Main()
    {
        ReverseArray();
        FindMaxMin();
        BubbleSort();
        LinearSearch();
        BinarySearch();
        MergeSortedArrays();
        RemoveDuplicatesFromSortedArray();
        RotateArrayRight();
        FirstNonRepeatingElement();
        CheckIfArraySorted();
        SumOfArray();
        SecondLargestElement();
        PairWithGivenSum();
        MoveZerosToEnd();

         Console.WriteLine("---- ADVANCED ALGORITHMS ----");

        Console.WriteLine("1. Kadane's Algorithm (Max Subarray Sum)");
        Console.WriteLine(MaxSubArraySum(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));

        Console.WriteLine("\n2. Two Sum (Optimized)");
        Console.WriteLine(TwoSum(new int[] { 2, 7, 11, 15 }, 9));

        Console.WriteLine("\n3. Longest Common Prefix");
        Console.WriteLine(LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));

        Console.WriteLine("\n4. Valid Parentheses");
        Console.WriteLine(IsValidParentheses("({[]})"));

        Console.WriteLine("\n5. Rotate Matrix 90 Degree");
        int[,] matrix =
        {
            {1,2,3},
            {4,5,6},
            {7,8,9}
        };
        RotateMatrix(matrix);
        PrintMatrix(matrix);

        Console.WriteLine("\n6. Find Missing Number");
        Console.WriteLine(FindMissingNumber(new int[] { 1, 2, 4, 5 }));

        Console.WriteLine("\n7. Peak Element");
        Console.WriteLine(FindPeakElement(new int[] { 1, 3, 20, 4, 1, 0 }));

        Console.WriteLine("\n8. Majority Element");
        Console.WriteLine(MajorityElement(new int[] { 2, 2, 1, 1, 2, 2, 2 }));

        Console.WriteLine("\n9. String Palindrome (Two Pointer)");
        Console.WriteLine(IsPalindrome("madam"));

        Console.WriteLine("\n10. Stock Buy Sell (Max Profit)");
        Console.WriteLine(MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));

        Console.ReadLine();
    }

    // 🧪 Algorithm 1 – Reverse an Array
    // Definition: Reverse elements in-place using two pointers
    // ⏱ Time: O(n) | 🧠 Space: O(1)
    static void ReverseArray()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        int left = 0, right = arr.Length - 1;

        while (left < right)
        {
            (arr[left], arr[right]) = (arr[right], arr[left]);
            left++;
            right--;
        }

        Console.WriteLine("Reverse Array: " + string.Join(", ", arr));
    }

    // 🧪 Algorithm 2 – Find Max & Min
    // Definition: Traverse once and track max & min
    // ⏱ Time: O(n) | 🧠 Space: O(1)
    static void FindMaxMin()
    {
        int[] arr = { 3, 5, 1, 8, 2 };
        int max = arr[0], min = arr[0];

        foreach (int n in arr)
        {
            if (n > max) max = n;
            if (n < min) min = n;
        }

        Console.WriteLine($"Max: {max}, Min: {min}");
    }

    // 🧪 Algorithm 3 – Bubble Sort
    // Definition: Repeatedly swap adjacent elements if out of order
    // ⏱ Time: O(n²) | 🧠 Space: O(1)
    static void BubbleSort()
    {
        int[] arr = { 5, 2, 8, 1, 9 };

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }
        }

        Console.WriteLine("Bubble Sort: " + string.Join(", ", arr));
    }

    // 🧪 Algorithm 4 – Linear Search
    // Definition: Scan each element until target is found
    // ⏱ Time: O(n) | 🧠 Space: O(1)
    static void LinearSearch()
    {
        int[] arr = { 4, 2, 7, 1, 9 };
        int target = 7;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                Console.WriteLine("Linear Search Index: " + i);
                return;
            }
        }

        Console.WriteLine("Linear Search Index: -1");
    }

    // 🧪 Algorithm 5 – Binary Search
    // Definition: Divide search space by half (array must be sorted)
    // ⏱ Time: O(log n) | 🧠 Space: O(1)
    static void BinarySearch()
    {
        int[] arr = { 1, 2, 4, 7, 9 };
        int target = 7;
        int low = 0, high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == target)
            {
                Console.WriteLine("Binary Search Index: " + mid);
                return;
            }
            else if (arr[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }

        Console.WriteLine("Binary Search Index: -1");
    }

    // 🧪 Algorithm 6 – Merge Two Sorted Arrays
    // Definition: Merge two sorted arrays into one sorted array
    // ⏱ Time: O(n+m) | 🧠 Space: O(n+m)
    static void MergeSortedArrays()
    {
        int[] a = { 1, 3, 5 };
        int[] b = { 2, 4, 6 };
        int[] merged = new int[a.Length + b.Length];

        int i = 0, j = 0, k = 0;

        while (i < a.Length && j < b.Length)
            merged[k++] = a[i] < b[j] ? a[i++] : b[j++];

        while (i < a.Length) merged[k++] = a[i++];
        while (j < b.Length) merged[k++] = b[j++];

        Console.WriteLine("Merged Array: " + string.Join(", ", merged));
    }

    // 🧪 Algorithm 7 – Remove Duplicates from Sorted Array
    // Definition: Shift unique elements forward
    // ⏱ Time: O(n) | 🧠 Space: O(1)
    static void RemoveDuplicatesFromSortedArray()
    {
        int[] arr = { 1, 1, 2, 3, 3, 4 };
        int write = 1;

        for (int read = 1; read < arr.Length; read++)
        {
            if (arr[read] != arr[read - 1])
                arr[write++] = arr[read];
        }

        Console.WriteLine("Remove Duplicates: " +
            string.Join(", ", arr[..write]));
    }

    // 🧪 Algorithm 8 – Rotate Array Right by K
    // Definition: Reverse parts of the array
    // ⏱ Time: O(n) | 🧠 Space: O(1)
    static void RotateArrayRight()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        int k = 2 % arr.Length;

        Reverse(arr, 0, arr.Length - 1);
        Reverse(arr, 0, k - 1);
        Reverse(arr, k, arr.Length - 1);

        Console.WriteLine("Rotate Right: " + string.Join(", ", arr));
    }

    static void Reverse(int[] arr, int start, int end)
    {
        while (start < end)
            (arr[start++], arr[end--]) = (arr[end], arr[start]);
    }

    // 🧪 Algorithm 9 – First Non-Repeating Element
    // Definition: Use Dictionary for frequency counting
    // ⏱ Time: O(n) | 🧠 Space: O(n)
    static void FirstNonRepeatingElement()
    {
        int[] arr = { 4, 5, 1, 2, 0, 4 };
        Dictionary<int, int> freq = new();

        foreach (int n in arr)
            freq[n] = freq.ContainsKey(n) ? freq[n] + 1 : 1;

        foreach (int n in arr)
        {
            if (freq[n] == 1)
            {
                Console.WriteLine("First Non-Repeating: " + n);
                return;
            }
        }
    }

    // 🧪 Algorithm 10 – Check if Array is Sorted
    // Definition: Compare adjacent elements
    // ⏱ Time: O(n) | 🧠 Space: O(1)
    static void CheckIfArraySorted()
    {
        int[] arr = { 1, 2, 3, 4, 5 };

        for (int i = 1; i < arr.Length; i++)
            if (arr[i] < arr[i - 1])
            {
                Console.WriteLine("Is Sorted: False");
                return;
            }

        Console.WriteLine("Is Sorted: True");
    }

    // 🧪 Algorithm – Sum of Array
    static void SumOfArray()
    {
        int[] arr = { 5, 3, 9, 1 };
        int sum = 0;

        foreach (int n in arr)
            sum += n;

        Console.WriteLine("Sum: " + sum);
    }

    // 🧪 Algorithm – Second Largest Element
    static void SecondLargestElement()
    {
        int[] arr = { 5, 3, 9, 1 };
        int first = int.MinValue, second = int.MinValue;

        foreach (int n in arr)
        {
            if (n > first)
            {
                second = first;
                first = n;
            }
            else if (n > second && n != first)
                second = n;
        }

        Console.WriteLine("Second Largest: " + second);
    }

    // 🧪 Algorithm – Pair With Given Sum
    static void PairWithGivenSum()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        int target = 8;
        HashSet<int> set = new();

        foreach (int n in arr)
        {
            if (set.Contains(target - n))
            {
                Console.WriteLine("Pair Found: True");
                return;
            }
            set.Add(n);
        }

        Console.WriteLine("Pair Found: False");
    }

    // 🧪 Algorithm – Move Zeros to End
    static void MoveZerosToEnd()
    {
        int[] arr = { 0, 1, 0, 3, 12 };
        int index = 0;

        foreach (int n in arr)
            if (n != 0)
                arr[index++] = n;

        while (index < arr.Length)
            arr[index++] = 0;

        Console.WriteLine("Move Zeros: " + string.Join(", ", arr));
    }

    // ------------------------------------------------------------

    // 🧠 Kadane’s Algorithm
    // Finds maximum sum of a contiguous subarray
    // ⏱ O(n) | 🧠 O(1)
    static int MaxSubArraySum(int[] nums)
    {
        int maxSoFar = nums[0];
        int current = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            current = Math.Max(nums[i], current + nums[i]);
            maxSoFar = Math.Max(maxSoFar, current);
        }
        return maxSoFar;
    }

    // ------------------------------------------------------------

    // 🧠 Two Sum using HashSet
    // Finds if any two numbers add up to target
    // ⏱ O(n) | 🧠 O(n)
    static bool TwoSum(int[] nums, int target)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in nums)
        {
            if (set.Contains(target - num))
                return true;
            set.Add(num);
        }
        return false;
    }

    // ------------------------------------------------------------

    // 🧠 Longest Common Prefix
    // ⏱ O(n * m) | 🧠 O(1)
    static string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 0) return "";

        string prefix = strs[0];

        foreach (string s in strs)
        {
            while (!s.StartsWith(prefix))
                prefix = prefix.Substring(0, prefix.Length - 1);
        }
        return prefix;
    }

    // ------------------------------------------------------------

    // 🧠 Valid Parentheses using Stack
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

    // ------------------------------------------------------------

    // 🧠 Rotate Matrix by 90 Degree Clockwise
    // ⏱ O(n²) | 🧠 O(1)
    static void RotateMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);

        // Transpose
        for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
                (matrix[i, j], matrix[j, i]) = (matrix[j, i], matrix[i, j]);

        // Reverse rows
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n / 2; j++)
                (matrix[i, j], matrix[i, n - j - 1]) =
                (matrix[i, n - j - 1], matrix[i, j]);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }

    // ------------------------------------------------------------

    // 🧠 Find Missing Number (XOR)
    // ⏱ O(n) | 🧠 O(1)
    static int FindMissingNumber(int[] nums)
    {
        int xor = 0;
        for (int i = 0; i <= nums.Length; i++)
            xor ^= i;
        foreach (int n in nums)
            xor ^= n;
        return xor;
    }

    // ------------------------------------------------------------

    // 🧠 Find Peak Element
    // ⏱ O(n) | 🧠 O(1)
    static int FindPeakElement(int[] nums)
    {
        for (int i = 1; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i - 1] && nums[i] > nums[i + 1])
                return nums[i];
        }
        return -1;
    }

    // ------------------------------------------------------------

    // 🧠 Majority Element (Boyer-Moore Voting)
    // ⏱ O(n) | 🧠 O(1)
    static int MajorityElement(int[] nums)
    {
        int count = 0, candidate = 0;

        foreach (int num in nums)
        {
            if (count == 0)
                candidate = num;
            count += (num == candidate) ? 1 : -1;
        }
        return candidate;
    }

    // ------------------------------------------------------------

    // 🧠 Palindrome Check (Two Pointer)
    // ⏱ O(n) | 🧠 O(1)
    static bool IsPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            if (s[left++] != s[right--])
                return false;
        }
        return true;
    }

    // ------------------------------------------------------------

    // 🧠 Stock Buy Sell – Max Profit
    // ⏱ O(n) | 🧠 O(1)
    static int MaxProfit(int[] prices)
    {
        int minPrice = int.MaxValue;
        int profit = 0;

        foreach (int price in prices)
        {
            minPrice = Math.Min(minPrice, price);
            profit = Math.Max(profit, price - minPrice);
        }
        return profit;
    }
}
