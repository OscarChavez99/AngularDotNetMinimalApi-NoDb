using Backend.Models;

namespace Backend.UserRepository
{
    public class UserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ILogger<UserRepository> logger) 
        { 
            _logger = logger;
        }

        public List<User> GetUsers()
        {
            List<User> users =
            [
                new User {Id = 1, Name = "Oscar"},
                new User {Id = 2, Name = "Fabian"},
            ];

            _logger.LogInformation("GetUsers returning {Count} users", users.Count);

            return users;
        }

        public User AddUser(User user)
        {
            // In a real implementation, you would save the user to a database and return the saved user with an assigned Id.
            // For this example, we will just return the user
            _logger.LogInformation("Adding user: {Name} with ID {Id}", user.Name, user.Id);
            return user;
        }
    }
}
