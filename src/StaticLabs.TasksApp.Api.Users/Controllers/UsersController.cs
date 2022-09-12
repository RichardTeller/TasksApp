using Microsoft.AspNetCore.Mvc;
using StaticLabs.TasksApp.Api.Contracts;
using StaticLabs.TasksApp.Api.Contracts.Requests.Users;
using StaticLabs.TasksApp.Api.Contracts.Responses;
using StaticLabs.TasksApp.Api.Contracts.Responses.Users;
using StaticLabs.TasksApp.Api.Users.Builders;
using StaticLabs.TasksApp.Api.Users.Services;

namespace StaticLabs.TasksApp.Api.Users.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _userService;
    private readonly IUserBuilder _userBuilder;

    public UsersController(
        ILogger<UsersController> logger,
        IUserService userService,
        IUserBuilder userBuilder)
    {
        _logger = logger;
        _userService = userService;
        _userBuilder = userBuilder;
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest createUserRequest)
    {
        var user = _userService.CreateUser(createUserRequest);

        var userResponse = _userBuilder.Build(user);
        var response = new SingleResourceResponse<UserResponse>
        {
            Data = userResponse,
            Links = new Dictionary<string, Link>()
        };
        response.Links.Add(Endpoints.ListUsersLinkName, Endpoints.ListUsersLink());
        response.Links.Add(Endpoints.GetUserLinkName, Endpoints.GetUserLink(userResponse.Id));
        response.Links.Add(Endpoints.UpdateUserLinkName, Endpoints.UpdateUserLink(userResponse.Id));
        response.Links.Add(Endpoints.DeleteUserLinkName, Endpoints.DeleteUserLink(userResponse.Id));

        return Created(Endpoints.UserByIdUri(userResponse.Id), response);
    }

    [HttpGet]
    public IActionResult ListUsers()
    {
        var users = _userService.GetUsers();

        var userResponses = users.Select(user => _userBuilder.Build(user)).ToArray();
        var response = new ArrayResponse<UserResponse>
        {
            Data = userResponses,
            Count = userResponses.Length,
            Links = new Dictionary<string, Link>()
        };
        response.Links.Add(Endpoints.CreateUserLinkName, Endpoints.CreateUserLink());

        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        var user = _userService.GetUser(id);

        if (user == null)
        {
            return NotFound();
        }

        var userResponse = _userBuilder.Build(user);
        var response = new SingleResourceResponse<UserResponse>
        {
            Data = userResponse,
            Links = new Dictionary<string, Link>()
        };
        response.Links.Add(Endpoints.CreateUserLinkName, Endpoints.CreateUserLink());
        response.Links.Add(Endpoints.ListUsersLinkName, Endpoints.ListUsersLink());
        response.Links.Add(Endpoints.UpdateUserLinkName, Endpoints.UpdateUserLink(userResponse.Id));
        response.Links.Add(Endpoints.DeleteUserLinkName, Endpoints.DeleteUserLink(userResponse.Id));

        return Ok(response);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, UpdateUserRequest updateUserRequest)
    {
        var user = _userService.UpdateUser(id, updateUserRequest);

        var userResponse = _userBuilder.Build(user);
        var response = new SingleResourceResponse<UserResponse>
        {
            Data = userResponse,
            Links = new Dictionary<string, Link>()
        };
        response.Links.Add(Endpoints.CreateUserLinkName, Endpoints.CreateUserLink());
        response.Links.Add(Endpoints.ListUsersLinkName, Endpoints.ListUsersLink());
        response.Links.Add(Endpoints.GetUserLinkName, Endpoints.GetUserLink(userResponse.Id));
        response.Links.Add(Endpoints.DeleteUserLinkName, Endpoints.DeleteUserLink(userResponse.Id));

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        _userService.DeleteUser(id);

        return NoContent();
    }

}
