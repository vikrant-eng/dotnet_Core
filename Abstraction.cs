// Interview Line
// -> A one-line comment likely indicating this file or snippet is for an interview exercise.

 // Abstraction reduces complexity and improves readability.
// -> Explains the purpose of using abstraction (design concept) in code.

abstract class Shape
// -> Declares an abstract base class named `Shape`. Abstract classes cannot be instantiated directly.
{
    public abstract double Area();
    // -> Declares an abstract method `Area` that must be implemented by derived (concrete) classes.
}

class Circle : Shape
// -> Declares a concrete class `Circle` that inherits from `Shape`.
{
    private double Radius;
    // -> Private field `Radius` stores the radius value for the circle; inaccessible outside the class.

    public Circle(double r)
    // -> Constructor for `Circle` accepting a parameter `r` to initialize the radius.
    {
        Radius = r;
        // -> Assigns the constructor argument `r` to the private field `Radius`.
    }

    public override double Area()
    // -> Implements the abstract `Area` method from `Shape`. `override` provides the concrete behavior.
    {
        return 3.14 * Radius * Radius;
        // -> Calculates and returns the circle's area using π * r^2. (Using 3.14 as an approximation for π.)
    }
}
class Program
// -> Declares the `Program` class which contains the program entry point.
{
    static void Main()
    // -> The `Main` method is the program's entry point for a console application.
    {
        // Shape s = new Shape(); ❌ Not allowed (abstract)
        // -> A commented-out example showing you cannot instantiate `Shape` directly because it is abstract.

        Shape shape = new Circle(5); // Polymorphism  
        // -> Creates a `Circle` instance with radius 5 but stores it in a `Shape` reference.
        // -> This demonstrates polymorphism: a base-class reference referring to a derived-class object.

         // Base class reference 
        // -> Comment emphasizing the previous line uses a base-class type for the variable.

        // Derived class object 
        // -> Comment emphasizing the actual object is of the derived type `Circle`.

        // Method call resolved at runtime
        // -> Notes that the overridden `Area` method is bound at runtime (dynamic dispatch / virtual call).

         //  shape.radius = 5; // ❌ Not allowed (private)
        // -> Commented-out attempt to set `Radius` directly, which fails because `Radius` is private.

        Console.WriteLine("Radius: 5");
        // -> Writes the text "Radius: 5" to standard output (console).

        Console.WriteLine("Area of Circle: " + shape.Area());
        // -> Calls `Area()` on the `shape` variable (runtime dispatch to `Circle.Area`) and prints the result.

        Console.ReadLine(); // Keep console open
        // -> Blocks until user presses Enter; used to keep the console window open in interactive runs.
    }
}

// Abstract class provides partial implementation and enforces derived classes to implement specific behavior.
// -> A summary comment explaining the purpose and benefits of abstract classes in OOP.

// 3️⃣ Why Abstract Class?
// -> Heading-style comment introducing reasons to use abstract classes.

// ✔ Forces derived classes to implement logic
// -> Benefit: base class can require derived classes to provide specific methods (via abstract methods).

// ✔ Cannot be instantiated
// -> Benefit/feature: prevents creating a base-class object directly when it is incomplete.

// ✔ Can contain both abstract & non-abstract methods
// -> Benefit: abstract classes can provide shared implementation and also require specific methods.