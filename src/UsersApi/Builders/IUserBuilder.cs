using StaticLabs.TasksApp.Api.Users.Contracts.Responses;
using StaticLabs.TasksApp.Api.Users.Models;

namespace StaticLabs.TasksApp.Api.Users.Builders;

public interface IUserBuilder
{
    Response<UserResponse> Build(User user);
}