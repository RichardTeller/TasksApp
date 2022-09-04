using StaticLabs.TasksApp.Api.Users.Contracts.Endpoints;
using StaticLabs.TasksApp.Api.Users.Contracts.Responses;
using StaticLabs.TasksApp.Api.Users.Models;

namespace StaticLabs.TasksApp.Api.Users.Builders;

public class UserBuilder : IUserBuilder
{
    public UserBuilder()
    {

    }

    public Response<UserResponse> Build(User user)
    {
        var userResponse = new UserResponse
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };

        var response = new Response<UserResponse>
        {
            Id = user.Id,
            Data = userResponse,
            Links = new List<Link>()
        };

        return response;
    }
}