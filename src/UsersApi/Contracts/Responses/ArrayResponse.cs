namespace StaticLabs.TasksApp.Api.Users.Contracts.Responses;

public class ArrayResponse<T> : Response<T>
    where T : class
{
    public IEnumerable<T> Data { get; set; }
    public int Count { get; set; }
}