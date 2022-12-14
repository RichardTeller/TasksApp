namespace StaticLabs.TasksApp.Api.Contracts.Responses;

public class ArrayResponse<T> : Response<T>
    where T : class
{
    public ICollection<T> Data { get; set; }
    public int Count { get; set; }
}