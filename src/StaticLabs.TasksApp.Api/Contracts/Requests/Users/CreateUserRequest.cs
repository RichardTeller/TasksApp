namespace StaticLabs.TasksApp.Api.Contracts.Requests.Users;

public class CreateUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}