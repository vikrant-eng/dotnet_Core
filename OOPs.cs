using System;

// ================== OOPS CONCEPTS ==================

// 1️⃣ Encapsulation
// THEORY: Binding data and methods together and hiding data using access modifiers
// REAL WORLD: Like an ATM — you cannot access cash directly, only via buttons
// PURPOSE IN .NET: Protects data, improves security, avoids misuse of class members
// USES IN .NET: DTOs, Models, Entity classes, Business logic validation
class ATM
{
    private int balance = 10000;   // data hidden

    public int CheckBalance()      // controlled access
    {
        return balance;
    }
}

// 2️⃣ Abstraction
// THEORY: Showing only essential details and hiding internal implementation
// REAL WORLD: Like a car steering — driver knows how to drive, not engine logic
// PURPOSE IN .NET: Reduces complexity, allows loose coupling
// USES IN .NET: Interfaces, abstract services, Repository & Service patterns
abstract class Remote
{
    public abstract void PowerOn(); // what to do, not how
}

class TV : Remote
{
    public override void PowerOn()
    {
        Console.WriteLine("TV turned ON");
    }
}

// 3️⃣ Inheritance
// THEORY: One class acquires properties and behavior of another class
// REAL WORLD: Like a child inheriting traits from parents
// PURPOSE IN .NET: Code reusability, common base functionality
// USES IN .NET: BaseController, BaseEntity, Middleware, Framework extensions
class Parent
{
    public void Surname()
    {
        Console.WriteLine("Family Surname");
    }
}

class Child : Parent
{
    public void FirstName()
    {
        Console.WriteLine("Child First Name");
    }
}

// 4️⃣ Polymorphism
// THEORY: Same method name but different behavior in different classes
// REAL WORLD: One person, many roles — Father at home, Employee at office
// PURPOSE IN .NET: Enables flexible and scalable code
// USES IN .NET: Dependency Injection, Method overriding, Runtime behavior change
class Person
{
    public virtual void Role()
    {
        Console.WriteLine("General Person");
    }
}

class Employee : Person
{
    public override void Role()
    {
        Console.WriteLine("Office Employee");
    }
}
