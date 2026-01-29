using System;

// ================== SOLID PRINCIPLES ==================

// S = One job // 1️⃣ S — Single Responsibility Principle (SRP)
// O = Extend, don’t modify // 2️⃣ O — Open / Closed Principle (OCP)
// L = Replace without break // 3️⃣ L — Liskov Substitution Principle (LSP)
// I = Small interfaces  // 4️⃣ I — Interface Segregation Principle (ISP)
// D = Depend on abstraction // 5️⃣ D — Dependency Inversion Principle (DIP)



// 1️⃣ S — Single Responsibility Principle (SRP)
// THEORY: A class should have only one reason to change
// REAL WORLD: A chef cooks, a waiter serves — one job per person
// PURPOSE IN .NET: Makes code easy to maintain and test
// USES IN .NET: Separate Controller, Service, Repository, Logger
class Invoice
{
    public void CalculateTotal() { /* calculation logic */ }
}

// 2️⃣ O — Open / Closed Principle (OCP)
// THEORY: Open for extension, closed for modification
// REAL WORLD: Mobile phone — add apps without changing hardware
// PURPOSE IN .NET: Add new features without breaking existing code
// USES IN .NET: Strategy pattern, Plugins, Middleware pipeline
abstract class Discount
{
    public abstract double Apply(double amount);
}

class FestivalDiscount : Discount
{
    public override double Apply(double amount) => amount * 0.9;
}

// 3️⃣ L — Liskov Substitution Principle (LSP)
// THEORY: Child class should replace parent class without breaking behavior
// REAL WORLD: USB drive — any brand works in same USB port
// PURPOSE IN .NET: Ensures reliable inheritance
// USES IN .NET: Base services, Framework extensibility
class Bird
{
    public virtual void Fly() { }
}

class Sparrow : Bird
{
    public override void Fly() { }
}

// 4️⃣ I — Interface Segregation Principle (ISP)
// THEORY: Clients should not be forced to implement unused methods
// REAL WORLD: TV remote — only needed buttons are present
// PURPOSE IN .NET: Cleaner interfaces, avoids unnecessary implementation
// USES IN .NET: Small focused interfaces in services
interface IPrinter
{
    void Print();
}

interface IScanner
{
    void Scan();
}

// 5️⃣ D — Dependency Inversion Principle (DIP)
// THEORY: High-level modules should depend on abstractions, not concrete classes
// REAL WORLD: Switch controls bulb — switch doesn't care which bulb brand
// PURPOSE IN .NET: Loose coupling and easy unit testing
// USES IN .NET: Dependency Injection in ASP.NET Core
interface IMessageService
{
    void Send();
}

class EmailService : IMessageService
{
    public void Send() { }
}
class Notification
{
    private readonly IMessageService _messageService;

    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify()
    {
        _messageService.Send();
    }
}
   