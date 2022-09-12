using StaticLabs.TasksApp.Api.Contracts.Responses;

namespace StaticLabs.TasksApp.Api.Contracts;

public static class Endpoints
{
    public static string UsersUri() => "api/users";
    public static string UserByIdUri(Guid id) => $"api/users/{id}";

    public static Link CreateUserLink()
    {
        return new Link
        {
            Title = "Create User",
            Href = UsersUri(),
            Type = HttpMethod.Post.ToString()
        };
    }

    public static Link GetUsersLink()
    {
        return new Link
        {
            Title = "Get Users",
            Href = UsersUri(),
            Type = HttpMethod.Get.ToString()
        };
    }

    public static Link GetUserLink(Guid id)
    {
        return new Link
        {
            Title = "Get User",
            Href = UserByIdUri(id),
            Type = HttpMethod.Get.ToString()
        };
    }

    public static Link UpdateUserLink(Guid id)
    {
        return new Link
        {
            Title = "Update User",
            Href = UserByIdUri(id),
            Type = HttpMethod.Put.ToString()
        };
    }

    public static Link DeleteUserLink(Guid id)
    {
        return new Link
        {
            Title = "Delete User",
            Href = UserByIdUri(id),
            Type = HttpMethod.Delete.ToString()
        };
    }
}