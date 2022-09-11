namespace StaticLabs.TasksApp.Api.Users.Contracts.Responses;

public abstract class Response<T>
    where T : class
{
    public ICollection<Link> Links { get; set; }
}