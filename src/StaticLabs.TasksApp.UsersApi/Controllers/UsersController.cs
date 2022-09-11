using Microsoft.AspNetCore.Mvc;
using StaticLabs.TasksApp.Api.Users.Builders;
using StaticLabs.TasksApp.Api.Users.Contracts.Endpoints;
using StaticLabs.TasksApp.Api.Users.Contracts.Requests;
using StaticLabs.TasksApp.Api.Users.Contracts.Responses;
using StaticLabs.TasksApp.Api.Users.Services;

namespace UsersApi.Controllers;

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
            Id = user.Id,
            Data = userResponse,
            Links = new List<Link>()
        };
        response.Links.Add(Endpoints.GetUsersLink());
        response.Links.Add(Endpoints.GetUserLink(response.Id));
        response.Links.Add(Endpoints.UpdateUserLink(response.Id));
        response.Links.Add(Endpoints.DeleteUserLink(response.Id));

        return Created(Endpoints.GetUserUri(response.Id), response);
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsers();

        var userResponses = users.Select(user => _userBuilder.Build(user)).ToArray();
        var response = new ArrayResponse<UserResponse>
        {
            Data = userResponses,
            Count = userResponses.Length,
            Links = new List<Link>()
        };
        response.Links.Add(Endpoints.CreateUserLink());

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
            Id = user.Id,
            Data = userResponse,
            Links = new List<Link>()
        };
        response.Links.Add(Endpoints.CreateUserLink());
        response.Links.Add(Endpoints.GetUsersLink());
        response.Links.Add(Endpoints.UpdateUserLink(response.Id));
        response.Links.Add(Endpoints.DeleteUserLink(response.Id));

        return Ok(response);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, UpdateUserRequest updateUserRequest)
    {
        var user = _userService.UpdateUser(id, updateUserRequest);

        var userResponse = _userBuilder.Build(user);
        var response = new SingleResourceResponse<UserResponse>
        {
            Id = user.Id,
            Data = userResponse,
            Links = new List<Link>()
        };
        response.Links.Add(Endpoints.CreateUserLink());
        response.Links.Add(Endpoints.GetUsersLink());
        response.Links.Add(Endpoints.GetUserLink(response.Id));
        response.Links.Add(Endpoints.DeleteUserLink(response.Id));

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        _userService.DeleteUser(id);

        return NoContent();
    }

}
