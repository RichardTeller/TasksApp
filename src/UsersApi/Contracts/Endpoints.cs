using StaticLabs.TasksApp.Api.Users.Contracts.Responses;

namespace StaticLabs.TasksApp.Api.Users.Contracts.Endpoints;

public static class Endpoints
{
    public static string CreateUserUri() => "api/users";
    public static string GetUsersUri() => "api/users";
    public static string GetUserUri(Guid id) => $"api/users/{id}";
    public static string UpdateUserUri(Guid id) => $"api/users/{id}";
    public static string DeleteUserUri(Guid id) => $"api/users/{id}";

    public static Link CreateUserLink()
    {
        return new Link
        {
            Title = "Create User",
            Href = Endpoints.CreateUserUri(),
            Type = HttpMethod.Post
        };
    }

    public static Link GetUsersLink()
    {
        return new Link
        {
            Title = "Get Users",
            Href = Endpoints.GetUsersUri(),
            Type = HttpMethod.Get
        };
    }

    public static Link GetUserLink(Guid id)
    {
        return new Link
        {
            Title = "Get User",
            Href = Endpoints.GetUserUri(id),
            Type = HttpMethod.Get
        };
    }

    public static Link UpdateUserLink(Guid id)
    {
        return new Link
        {
            Title = "Update User",
            Href = Endpoints.UpdateUserUri(id),
            Type = HttpMethod.Put
        };
    }

    public static Link DeleteUserLink(Guid id)
    {
        return new Link
        {
            Title = "Delete User",
            Href = Endpoints.DeleteUserUri(id),
            Type = HttpMethod.Delete
        };
    }
}