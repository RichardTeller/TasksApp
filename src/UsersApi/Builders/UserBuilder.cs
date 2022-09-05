using StaticLabs.TasksApp.Api.Users.Contracts.Endpoints;
using StaticLabs.TasksApp.Api.Users.Contracts.Responses;
using StaticLabs.TasksApp.Api.Users.Models;

namespace StaticLabs.TasksApp.Api.Users.Builders;

public class UserBuilder : IUserBuilder
{
    public UserBuilder()
    {

    }

    public UserResponse Build(User user)
    {
        var userResponse = new UserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };

        return userResponse;
    }
}