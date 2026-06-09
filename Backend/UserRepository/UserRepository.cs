using Backend.Models;

namespace Backend.UserRepository
{
    public static class UserRepository
    {
        public static List<User> GetUsers()
        {
            List<User> users =
            [
                new User {Id = 1, Name = "Oscar"},
                new User {Id = 2, Name = "Fabian"},
            ];

            return users;
        }

        public static User AddUser(User user)
        {
            // In a real implementation, you would save the user to a database and return the saved user with an assigned Id.
            // For this example, we will just return the user
            Console.WriteLine($"Adding user: {user.Name}");
            return user;
        }
    }
}
