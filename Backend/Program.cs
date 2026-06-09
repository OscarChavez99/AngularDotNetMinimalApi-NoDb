using Backend.Api;
using Backend.UserRepository;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy to allow requests from the frontend

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Dependency injection for UserRepository
builder.Services.AddScoped<UserRepository>();

// Add services to the container.

var app = builder.Build();
// Map API endpoints
Routes.MapEndpoints(app);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors();
app.Run();