using StaticLabs.TasksApp.Api.Users.Contracts.Requests;
using StaticLabs.TasksApp.Api.Users.Models;
using StaticLabs.TasksApp.Api.Users.Repository;

namespace StaticLabs.TasksApp.Api.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User CreateUser(CreateUserRequest createUserRequest)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = createUserRequest.FirstName,
            LastName = createUserRequest.LastName,
            Email = createUserRequest.Email
        };

        _userRepository.AddUser(user);

        return user;
    }

    public IEnumerable<User> GetUsers()
    {
        return _userRepository.GetUsers();
    }

    public User? GetUser(Guid id)
    {
        return _userRepository.GetUser(id);
    }

    public User UpdateUser(Guid id, UpdateUserRequest updateUserRequest)
    {
        var existingUser = _userRepository.GetUserOrThrow(id);
        
        existingUser.FirstName = updateUserRequest.FirstName;
        existingUser.LastName = updateUserRequest.LastName;
        existingUser.Email = updateUserRequest.Email;

        _userRepository.UpdateUser(existingUser);

        return existingUser;
    }

    public void DeleteUser(Guid id)
    {
        var user = _userRepository.GetUser(id);

        if (user == null)
        {
            return;
        }

        _userRepository.DeleteUser(id);
    }
}