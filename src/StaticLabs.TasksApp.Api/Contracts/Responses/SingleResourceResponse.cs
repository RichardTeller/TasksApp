namespace StaticLabs.TasksApp.Api.Contracts.Responses;

public class SingleResourceResponse<T> : Response<T>
    where T : class
{
    public Guid Id { get; set; }
    public T Data { get; set; }
}