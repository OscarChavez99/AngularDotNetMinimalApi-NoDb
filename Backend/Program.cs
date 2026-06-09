using Backend.UserRepository;
using Backend.Models;

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

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors();

app.MapGet("users", () => 
{
    var users = UserRepository.GetUsers();
    return Results.Ok(users);
});

app.MapPost("users", (User user) =>
{
    var createdUser = UserRepository.AddUser(user);
    return Results.Created($"/users/{createdUser.Id}", createdUser);
});

app.Run();