using Backend.Handlers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api
{
    public static class Routes
    {
        public static void MapEndpoints(this WebApplication app)
        {
            MapUsers(app);
        }

        public static void MapUsers(WebApplication app)
        {
            // GET
            app.MapGet("users", ([FromServices] UserHandler userRepository) =>
                userRepository.GetUsers());
            // POST
            app.MapPost("users", ([FromServices] UserHandler userRepository, [FromBody] User user) =>
                userRepository.AddUser(user));
        }
    }
}
