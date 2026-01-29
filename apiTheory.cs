using System;

// ================== TYPES OF APIs ==================

// 1️⃣ REST API
// THEORY: Representational State Transfer, uses HTTP verbs (GET, POST, PUT, DELETE)
// REAL WORLD: Ordering food online (request → kitchen → response)
// PURPOSE: CRUD operations, stateless
// USE IN .NET: ASP.NET Core Web API
class RestApiExample
{
    // GET /products
    public void GetProducts() { }

    // POST /products
    public void AddProduct() { }
}

// 2️⃣ SOAP API
// THEORY: XML-based protocol, strictly defined contract (WSDL)
// REAL WORLD: Formal business contract with strict rules
// PURPOSE: Enterprise apps, strong typing, secure
// USE IN .NET: WCF Services
class SoapApiExample
{
    // SOAP call example
}

// 3️⃣ GraphQL API
// THEORY: Single endpoint, clients specify required data
// REAL WORLD: Buffet – take only what you want
// PURPOSE: Reduce over-fetching/under-fetching
// USE IN .NET: HotChocolate, GraphQL.NET
class GraphQLExample
{
    // query { users { name, age } }
}

// 4️⃣ gRPC API
// THEORY: High-performance, binary protocol, contract-based
// REAL WORLD: Call center using private phone line
// PURPOSE: Microservices communication, real-time
// USE IN .NET: ASP.NET Core gRPC
class GrpcExample
{
    // gRPC service method
}

// ================== API AUTHENTICATION VS AUTHORIZATION ==================

// 🔹 AUTHENTICATION
// THEORY: Verifying who you are
// REAL WORLD: Showing ID at airport gate
// PURPOSE: Identify user
// USE IN .NET: JWT, OAuth2, ASP.NET Core Identity
class AuthenticationExample
{
    public void Login(string username, string password)
    {
        // Validate credentials → issue token
    }
}

// 🔹 AUTHORIZATION
// THEORY: Verifying what you can access
// REAL WORLD: Boarding gate → economy vs business class
// PURPOSE: Control access to resources
// USE IN .NET: Role-based, Policy-based
class AuthorizationExample
{
    public void AccessResource(string role)
    {
        if(role == "Admin")
        {
            // grant access
        }
        else
        {
            // deny access
        }
    }
}

// ================== API SECURITY BEST PRACTICES ==================
/*
1️⃣ Always use HTTPS → Protect data in transit
2️⃣ Use authentication → Identify users (JWT, OAuth2)
3️⃣ Use authorization → Role & policy based
4️⃣ Rate limiting → Prevent abuse
5️⃣ Input validation → Prevent injection attacks
6️⃣ Logging & monitoring → Track suspicious activity
7️⃣ Versioning → v1, v2 endpoints for backward compatibility
*/

// ================== INTERVIEW GOLD SUMMARY ==================
/*
API Types:
- REST → CRUD, stateless, HTTP
- SOAP → XML, enterprise, strict contract
- GraphQL → Client selects data
- gRPC → High-performance microservices

Auth:
- Authentication → Who you are
- Authorization → What you can do
*/


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

// ================== API VERSIONING ==================

// THEORY: Maintain multiple versions of an API without breaking clients
// REAL WORLD: Mobile apps supporting old and new features
// PURPOSE: Backward compatibility
// USE IN .NET: ASP.NET Core API Versioning package

// Setup API Versioning in Startup.cs / Program.cs
var builder = WebApplication.CreateBuilder();
builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Example Controller with multiple versions
[ApiController]
[Route("api/v{version:apiVersion}/products")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    [MapToApiVersion("1.0")] // v1
    public IActionResult GetV1() => Ok(new[] { "ProductA_v1", "ProductB_v1" });

    [HttpGet]
    [MapToApiVersion("2.0")] // v2
    public IActionResult GetV2() => Ok(new[] { "ProductA_v2", "ProductB_v2", "ProductC_v2" });
}

// ================== RATE LIMITING MIDDLEWARE ==================

// THEORY: Limit number of requests per user/time window
// REAL WORLD: Token system in bank → only X people at a time
// PURPOSE: Prevent abuse, DoS attacks, overload
// USE IN .NET: Custom middleware or third-party packages (AspNetCoreRateLimit)

public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly ConcurrentDictionary<string, (DateTime timestamp, int count)> _requests =
        new ConcurrentDictionary<string, (DateTime, int)>();
    private readonly int _maxRequests = 5; // max per time window
    private readonly TimeSpan _timeWindow = TimeSpan.FromSeconds(10); // 10 sec window

    public RateLimitingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var key = context.Connection.RemoteIpAddress.ToString();
        var now = DateTime.UtcNow;

        _requests.AddOrUpdate(key,
            (now, 1),
            (k, old) =>
            {
                if (now - old.timestamp > _timeWindow)
                    return (now, 1); // reset window
                return (old.timestamp, old.count + 1);
            });

        if (_requests[key].count > _maxRequests)
        {
            context.Response.StatusCode = 429; // Too Many Requests
            await context.Response.WriteAsync("Rate limit exceeded. Try again later.");
            return;
        }

        await _next(context); // continue pipeline
    }
}

// ================== USAGE IN PIPELINE ==================
app.UseMiddleware<RateLimitingMiddleware>(); // apply rate limiter globally
app.MapControllers();
app.Run();

// ================== INTERVIEW GOLD SUMMARY ==================
/*
API Versioning:
- Keep multiple API versions for backward compatibility
- v1, v2, v3 endpoints in same controller or separate controllers

Rate Limiting:
- Prevent abuse & overload
- Can be IP-based, user-based
- Implement via middleware or packages
- Response code 429 when exceeded
*/
