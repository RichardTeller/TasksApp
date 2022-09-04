namespace StaticLabs.TasksApp.Api.Users.Contracts.Responses;

public class Link
{
    public string Title { get; set; }
    public string Href { get; set; }
    //public string Rel { get; set; }
    public HttpMethod Type { get; set; }
}