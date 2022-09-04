namespace StaticLabs.TasksApp.Api.Users.Contracts.Responses;

public class Response<T>
    where T : class
{
    public Guid Id { get; set; }
    public T Data { get; set; }
    public ICollection<Link> Links { get; set; }
}