using StaticLabs.TasksApp.Api.Contracts.Responses.Users;
using StaticLabs.TasksApp.Api.Users.Models;

namespace StaticLabs.TasksApp.Api.Users.Builders;

public interface IUserBuilder
{
    UserResponse Build(User user);
}