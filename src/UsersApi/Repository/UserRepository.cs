using StaticLabs.TasksApp.Api.Users.Exceptions;
using StaticLabs.TasksApp.Api.Users.Models;

namespace StaticLabs.TasksApp.Api.Users.Repository;

public class UserRepository : IUserRepository
{
    private List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();

        Seed();
    }

    public User AddUser(User user)
    {
        _users.Add(user);

        return user;
    }

    public IEnumerable<User> GetUsers()
    {
        return _users;
    }

    public User? GetUser(Guid id)
    {
        return _users.SingleOrDefault(user => user.Id == id);
    }

    public User GetUserOrThrow(Guid id)
    {
        var user = GetUser(id);

        if (user == null)
        {
            throw new RequiredResourceDoesNotExistException();
        }

        return user;
    }

    public User UpdateUser(User user)
    {
        var existingUser = _users.Single(user => user.Id == user.Id);

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;

        return existingUser;
    }

    public void DeleteUser(Guid id)
    {
        var existingUser = _users.Single(user => user.Id == id);

        _users.Remove(existingUser);
    }

    private void Seed()
    {
        for (int i = 0; i < 10; i++)
        {
            _users.Add(NewRandomizedUser());
        }
    }

    private User NewRandomizedUser()
    {
        var random = new Random();

        return new User
        {
            Id = Guid.NewGuid(),
            FirstName = $"FName_{random.Next(100)}",
            LastName = $"LName_{random.Next(100)}",
            Email = $"Email_{random.Next(100)}"
        };
    }
}