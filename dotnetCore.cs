using System;

// ================== ASP.NET CORE CONCEPTS ==================

// 1️⃣ Middleware
// THEORY: Middleware is a component that handles requests & responses in pipeline
// REAL WORLD: Airport security check — every passenger passes through checks
// PURPOSE IN .NET CORE: Request processing, logging, authentication
// USES IN .NET CORE: Auth, CORS, Exception handling, Routing
public class CustomMiddleware
{
    // invoked for every HTTP request
}

// 2️⃣ Dependency Injection (Built-in DI)
// THEORY: Objects are provided from outside instead of creating them manually
// REAL WORLD: You order food — restaurant decides who cooks it
// PURPOSE IN .NET CORE: Loose coupling, easy testing
// USES IN .NET CORE: Services, Repositories, Logging, Controllers
interface IProductService
{
    void GetProducts();
}

class ProductService : IProductService
{
    public void GetProducts() { }
}

// 3️⃣ Controller
// THEORY: Handles incoming HTTP requests and returns responses
// REAL WORLD: Receptionist — receives request, forwards to correct department
// PURPOSE IN .NET CORE: API endpoints & MVC logic
// USES IN .NET CORE: REST APIs, MVC apps
class ProductController
{
    private readonly IProductService service;

    public ProductController(IProductService service)
    {
        this.service = service;
    }
}

// 4️⃣ Service Layer
// THEORY: Contains business logic of the application
// REAL WORLD: Manager — decides how work should be done
// PURPOSE IN .NET CORE: Keeps controllers thin
// USES IN .NET CORE: Validation, calculations, workflows
class OrderService
{
    public void PlaceOrder() { }
}

// 5️⃣ Repository Pattern
// THEORY: Separates data access logic from business logic
// REAL WORLD: Librarian — fetches books from storage
// PURPOSE IN .NET CORE: Clean data access & easy DB swap
// USES IN .NET CORE: EF Core, Dapper, MongoDB
class OrderRepository
{
    public void Save() { }
}

// 6️⃣ Entity / Model
// THEORY: Represents database tables as classes
// REAL WORLD: Registration form record
// PURPOSE IN .NET CORE: Data transfer & persistence
// USES IN .NET CORE: EF Core entities, DTOs
class Order
{
    public int Id { get; set; }
    public double Amount { get; set; }
}

// 7️⃣ Entity Framework Core (ORM)
// THEORY: Converts C# objects into database queries
// REAL WORLD: Translator — converts language
// PURPOSE IN .NET CORE: Avoid raw SQL, faster development
// USES IN .NET CORE: CRUD operations, migrations
class AppDbContext
{
    // DbSet<Order>
}

// 8️⃣ Configuration & appsettings.json
// THEORY: Stores application configuration settings
// REAL WORLD: Control panel settings
// PURPOSE IN .NET CORE: Centralized configuration
// USES IN .NET CORE: Connection strings, API keys
class ConfigurationExample { }

// 9️⃣ Authentication & Authorization
// THEORY: Authentication = Who you are, Authorization = What you can do
// REAL WORLD: ID card + permission access
// PURPOSE IN .NET CORE: Secure APIs & apps
// USES IN .NET CORE: JWT, Identity, Roles, Policies
class AuthService { }

// 🔟 Logging
// THEORY: Recording application behavior and errors
// REAL WORLD: CCTV camera for system
// PURPOSE IN .NET CORE: Debugging & monitoring
// USES IN .NET CORE: ILogger, Serilog, Application Insights
class LoggerExample { }

// 1️⃣1️⃣ Exception Handling
// THEORY: Handling runtime errors gracefully
// REAL WORLD: Airbags in car — protect during crash
// PURPOSE IN .NET CORE: App stability
// USES IN .NET CORE: Global exception middleware
class ExceptionHandler { }

// 1️⃣2️⃣ Hosting & Kestrel
// THEORY: Web server that runs ASP.NET Core apps
// REAL WORLD: Engine of a vehicle
// PURPOSE IN .NET CORE: Run web apps
// USES IN .NET CORE: Cross-platform hosting
class Program { }


// ================== TYPES OF CLASSES IN C# ==================

// 1️⃣ Class (Normal Class)
// THEORY: Blueprint for creating objects
// REAL WORLD: House blueprint
// USE IN .NET: Business logic, services, models
class NormalClass { }

// 2️⃣ Abstract Class
// THEORY: Partial implementation, cannot be instantiated
// REAL WORLD: Vehicle concept
// USE IN .NET: Base services, shared logic
abstract class AbstractClass
{
    public abstract void Run();
}

// 3️⃣ Interface
// THEORY: Contract with no implementation
// REAL WORLD: Charger standard
// USE IN .NET: Dependency Injection
interface IMyInterface
{
    void Execute();
}

// 4️⃣ Static Class
// THEORY: Cannot be instantiated, contains static members
// REAL WORLD: Calculator
// USE IN .NET: Helper, utility classes
static class MathHelper
{
    public static int Add(int a, int b) => a + b;
}

// 5️⃣ Partial Class
// THEORY: Class split into multiple files
// REAL WORLD: Team work on same project
// USE IN .NET: Auto-generated EF / Designer code
partial class PartialExample { }

// 6️⃣ Sealed Class
// THEORY: Cannot be inherited
// REAL WORLD: Final decision
// USE IN .NET: Security, performance
sealed class FinalClass { }

// 7️⃣ Record Class
// THEORY: Immutable data object
// REAL WORLD: ID card
// USE IN .NET: DTOs, API responses
record Person(string Name, int Age);

// ================== TYPES OF METHODS / FUNCTIONS ==================

// 1️⃣ Instance Method
// THEORY: Belongs to object
// REAL WORLD: Person walking
class InstanceMethod
{
    public void Walk() { }
}

// 2️⃣ Static Method
// THEORY: Belongs to class
// REAL WORLD: Calculator addition
class StaticMethod
{
    public static void Sum() { }
}

// 3️⃣ Abstract Method
// THEORY: No body, must be implemented
// REAL WORLD: Rules
abstract class AbstractMethod
{
    public abstract void DoWork();
}

// 4️⃣ Virtual Method
// THEORY: Can be overridden
// REAL WORLD: Default rule
class VirtualMethod
{
    public virtual void Show() { }
}

// 5️⃣ Override Method
// THEORY: Changes parent behavior
// REAL WORLD: Custom rule
class OverrideMethod : VirtualMethod
{
    public override void Show() { }
}

// 6️⃣ Extension Method
// THEORY: Adds method to existing class
// REAL WORLD: Adding feature without change
// USE IN .NET: LINQ
static class ExtensionExample
{
    public static bool IsEven(this int number) => number % 2 == 0;
}

// ================== METHOD PARAMETERS & KEYWORDS ==================

// 1️⃣ ref
// THEORY: Pass variable by reference (must be initialized)
// REAL WORLD: Shared key
// USE IN .NET: Performance-critical code
void RefExample(ref int x) { x += 10; }

// 2️⃣ out
// THEORY: Pass variable to return multiple values
// REAL WORLD: Result slip
// USE IN .NET: TryParse methods
void OutExample(out int x) { x = 100; }

// 3️⃣ params
// THEORY: Variable number of parameters
// REAL WORLD: Shopping cart
// USE IN .NET: Logging, aggregation
int Sum(params int[] numbers) => numbers.Length;

// 4️⃣ in
// THEORY: Read-only reference
// REAL WORLD: View-only access
void InExample(in int x) { }

// ================== IMPORTANT C# KEYWORDS ==================

// new      → Create object
// this     → Current object
// base     → Parent class
// readonly → Value set once
// const    → Compile-time constant
// var      → Type inference
// dynamic  → Runtime type
// async    → Asynchronous method
// await    → Wait for async result
// yield    → Return data one-by-one
// lock     → Thread safety
// using    → Resource management
// nullable → Allow null values (int?)

// ================== ASYNC METHOD ==================
// THEORY: Non-blocking execution
// REAL WORLD: Ordering food while doing work
async Task AsyncExample()
{
    await Task.Delay(1000);
}

using System;

// ================== ACCESS MODIFIERS IN C# ==================


// public → Everywhere 
// private → Same class 
// protected → Parent + child 
// internal → Same project 
// protected internal → Project OR child 
// private protected → Project AND child

// 1️⃣ public
// THEORY: Accessible from anywhere
// REAL WORLD: Public road — anyone can use it
// PURPOSE: Expose functionality to outside world
// USES IN .NET: Controllers, APIs, Services, DTOs
public class PublicClass
{
    public void Show() { }
}

// 2️⃣ private
// THEORY: Accessible only within the same class
// REAL WORLD: ATM PIN — only you can access it
// PURPOSE: Data hiding & security
// USES IN .NET: Internal logic, validation, sensitive data
class PrivateExample
{
    private int secret = 10;
}

// 3️⃣ protected
// THEORY: Accessible within class and derived (child) classes
// REAL WORLD: Family property — only family members
// PURPOSE: Controlled inheritance access
// USES IN .NET: Base classes, framework extensions
class Parent
{
    protected void FamilyAccess() { }
}

// 4️⃣ internal
// THEORY: Accessible within same assembly (project)
// REAL WORLD: Office ID — only employees allowed
// PURPOSE: Restrict access inside project
// USES IN .NET: Business logic layer, helper classes
internal class InternalClass { }

// 5️⃣ protected internal
// THEORY: Accessible in same assembly OR derived classes
// REAL WORLD: Company family access
// PURPOSE: Flexible inheritance across project
// USES IN .NET: Framework base libraries
class ProtectedInternalExample
{
    protected internal void Access() { }
}

// 6️⃣ private protected
// THEORY: Accessible in same class OR derived classes in same assembly
// REAL WORLD: Family locker inside same house
// PURPOSE: Strong encapsulation
// USES IN .NET: Secure base class design
class PrivateProtectedExample
{
    private protected void SecureAccess() { }
}



// ================== CONSTRUCTORS IN C# ==================

// CONSTRUCTOR
// THEORY: Special method that runs automatically when an object is created
// REAL WORLD: Switching ON a mobile — initial setup happens automatically
// PURPOSE: Initialize object state, assign default values, inject dependencies
// USES IN .NET: Model initialization, Dependency Injection, DB context setup
class User
{
    public string Name;
    public int Age;

    // 1️⃣ Default Constructor
    // THEORY: No parameters, sets default values
    // REAL WORLD: New phone with factory settings
    public User()
    {
        Name = "Guest";
        Age = 0;
    }

    // 2️⃣ Parameterized Constructor
    // THEORY: Accepts parameters to initialize object
    // REAL WORLD: Custom phone setup
    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // 3️⃣ Copy Constructor
    // THEORY: Creates object by copying another object
    // REAL WORLD: Duplicate ID card
    public User(User other)
    {
        Name = other.Name;
        Age = other.Age;
    }

    // 4️⃣ Static Constructor
    // THEORY: Runs once, used to initialize static data
    // REAL WORLD: Company rules set once
    static User()
    {
        // static initialization
    }

    // 5️⃣ Private Constructor
    // THEORY: Restricts object creation
    // REAL WORLD: Single entry gate
    // USE: Singleton pattern
    private User(int id) { }
}

// 6️⃣ Constructor Chaining
// THEORY: One constructor calls another constructor using this()
// REAL WORLD: Step-by-step setup
class Product
{
    public string Name;
    public double Price;

    public Product() : this("Unknown", 0) { }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

// 7️⃣ Object Initializer
// THEORY: Initialize object properties without constructor
// REAL WORLD: Filling form fields directly
class OrderExample
{
    public int Id { get; set; }
    public double Amount { get; set; }
}       

// ================== NAMESPACES IN C# ==================       
// THEORY: Organizes classes and avoids name conflicts
// REAL WORLD: Library sections — fiction, non-fiction
// PURPOSE: Code organization and modularity
// USES IN .NET: Group related classes, third-party libraries
namespace MyApp.Models
{
    class Customer { }
}

