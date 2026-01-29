var builder = WebApplication.CreateBuilder(args);


// 🔹 REQUIRED for Aspire
builder.AddServiceDefaults();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


// 🔹 REQUIRED for Aspire
app.MapDefaultEndpoints();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");
app.MapGet("/search", (string? name) =>
{
    return $"Searching for: {name}";
});
app.MapGet("/api", () => "Hello World!api2");
app.Run();
