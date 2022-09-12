using StaticLabs.TasksApp.Api.Contracts.Responses;

namespace StaticLabs.TasksApp.Api.Contracts;

public static class Endpoints
{
    public static string UsersUri() => "api/users";
    public static string UserByIdUri(Guid id) => $"api/users/{id}";

    public static string CreateUserLinkName => "createUser";
    public static Link CreateUserLink()
    {
        return new Link
        {
            Href = UsersUri(),
            Type = HttpMethod.Post.ToString()
        };
    }

    public static string ListUsersLinkName => "listUsers";
    public static Link ListUsersLink()
    {
        return new Link
        {
            Href = UsersUri(),
            Type = HttpMethod.Get.ToString()
        };
    }

    public static string GetUserLinkName => "getUser";
    public static Link GetUserLink(Guid id)
    {
        return new Link
        {
            Href = UserByIdUri(id),
            Type = HttpMethod.Get.ToString()
        };
    }

    public static string UpdateUserLinkName => "updateUser";
    public static Link UpdateUserLink(Guid id)
    {
        return new Link
        {
            Href = UserByIdUri(id),
            Type = HttpMethod.Put.ToString()
        };
    }

    public static string DeleteUserLinkName => "deleteUser";
    public static Link DeleteUserLink(Guid id)
    {
        return new Link
        {
            Href = UserByIdUri(id),
            Type = HttpMethod.Delete.ToString()
        };
    }
}