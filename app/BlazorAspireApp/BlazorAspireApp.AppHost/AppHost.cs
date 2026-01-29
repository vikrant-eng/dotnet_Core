

var builder = DistributedApplication.CreateBuilder(args);

var web = builder.AddProject<Projects.BlazorAspireApp_Web>("blazorweb")
                 .WithExternalHttpEndpoints();
// 🔹 Add Minimal API project
var minimalApi = builder.AddProject<Projects.MinimalApiDemo>("minimalapi")
                        .WithExternalHttpEndpoints();
builder.Build().Run();
