namespace StaticLabs.TasksApp.Api.Contracts.Responses.Users;

public class UserResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}