using Microsoft.AspNetCore.Mvc;
using StaticLabs.TasksApp.Api.Users.Builders;
using StaticLabs.TasksApp.Api.Users.Contracts.Endpoints;
using StaticLabs.TasksApp.Api.Users.Contracts.Requests;
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

        var response = _userBuilder.Build(user);
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

        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        var user = _userService.GetUser(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, UpdateUserRequest updateUserRequest)
    {
        var user = _userService.UpdateUser(id, updateUserRequest);

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        _userService.DeleteUser(id);

        return NoContent();
    }

}
