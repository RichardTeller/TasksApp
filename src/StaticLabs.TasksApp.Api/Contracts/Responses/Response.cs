namespace StaticLabs.TasksApp.Api.Contracts.Responses;

public abstract class Response<T>
    where T : class
{
    public IDictionary<string, Link> Links { get; set; }
}