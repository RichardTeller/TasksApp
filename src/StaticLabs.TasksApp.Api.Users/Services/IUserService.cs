using StaticLabs.TasksApp.Api.Contracts.Requests.Users;
using StaticLabs.TasksApp.Api.Users.Models;

namespace StaticLabs.TasksApp.Api.Users.Services;

public interface IUserService
{
    User CreateUser(CreateUserRequest createUserRequest);
    IEnumerable<User> GetUsers();
    User? GetUser(Guid id);
    User UpdateUser(Guid id, UpdateUserRequest updateUserRequest);
    void DeleteUser(Guid id);
}