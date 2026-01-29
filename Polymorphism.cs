// Polymorphism means:
            // Same method name, different behavior.

// Types: 
         // Compile-time (Method Overloading) 
         // Run-time (Method Overriding)

// Example of Run-time Polymorphism (Method Overriding) 
// abstract class Animal
// {
//     public abstract void Speak();
// }
class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal sound");
    }
}
class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Woof");
    }
}
class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Meow");
    }
}
class Program
{
    static void Main()
    {
        Animal myDog = new Dog(); // Base class reference, derived class object
        Animal myCat = new Cat(); // Base class reference, derived class object 
        myDog.Speak(); // Output: Woof
        myCat.Speak(); // Output: Meow


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
// Example of Compile-time Polymorphism (Method Overloading)
// class Calculator
// {
//     public int Add(int a, int b)
//     {
//         return a + b;
//     }    
//     public double Add(double a, double b)
//     {
//         return a + b;
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         Calculator calc = new Calculator();
//         Console.WriteLine(calc.Add(5, 10));         // Calls int Add(int a, int b)
//         Console.WriteLine(calc.Add(5.5, 10.2
//));   // Calls double Add(double a, double b)
//     }
// }        
// Polymorphism allows methods to do different things based on the object that it is acting upon.
// ✔️ Code reusability
// ✔️ Flexibility and maintainability
// ✔️ Dynamic method resolution

