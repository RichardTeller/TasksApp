using StaticLabs.TasksApp.Api.Users.Models;

namespace StaticLabs.TasksApp.Api.Users.Repository;

public interface IUserRepository
{
    User AddUser(User user);
    IEnumerable<User> GetUsers();
    User? GetUser(Guid id);
    User GetUserOrThrow(Guid id);
    User UpdateUser(User user);
    void DeleteUser(Guid id);
}