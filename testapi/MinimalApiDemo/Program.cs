var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/search", (string? name) =>
{
    return $"Searching for: {name}";
});
app.MapGet("/api", () => "Hello World!api2");
app.Run();
