namespace StaticLabs.TasksApp.Api.Users.Contracts.Requests;

public class CreateUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}