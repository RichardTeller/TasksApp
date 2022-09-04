namespace StaticLabs.TasksApp.Api.Users.Contracts.Responses;

public class UserResponse : Response<UserResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}