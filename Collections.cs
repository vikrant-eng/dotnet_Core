

    // 2️⃣ Collections in C#
    //    🔹 Why Collections?
    //      Dynamic size
    //      Better features
    //      Type safety (Generics)

class Program
{
    static void Main()
    {
        
        // 🔹 List<T> 
        // Dynamic array 
        // Fast read 
        // Slower insert in middle
        
        List<int> list = new List<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);



        Dictionary<int, string> dict = new Dictionary<int, string>();
         dict.Add(1, "One");
         dict[2] = "Two";

           Console.WriteLine(dict[1]); // One

        //    🔹 HashSet<T> 
        // 1. Unique values only 
        // 2.Fast lookup
        
        HashSet<int> set = new HashSet<int>();
        set.Add(10);
        set.Add(10); // ignored

        Console.WriteLine(set.Count); // 1

        //    🔹 Queue<T> (FIFO)
        Queue<int> q = new Queue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        Console.WriteLine(q.Dequeue()); // 1

        //    🔹 Stack<T> (LIFO)
        Stack<int> st = new Stack<int>();
        st.Push(1);
        st.Push(2);
        Console.WriteLine(st.Pop()); // 2

        


        

    }
}