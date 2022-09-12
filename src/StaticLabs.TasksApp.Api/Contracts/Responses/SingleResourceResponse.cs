namespace StaticLabs.TasksApp.Api.Contracts.Responses;

public class SingleResourceResponse<T> : Response<T>
    where T : class
{
    public T Data { get; set; }
}