using StaticLabs.TasksApp.Api.Exceptions;
using StaticLabs.TasksApp.Api.Users.Models;

namespace StaticLabs.TasksApp.Api.Users.Repository;

public class UserRepository : IUserRepository
{
    private List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();

        //Seed();
    }

    public User AddUser(User newUser)
    {
        _users.Add(newUser);

        return newUser;
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

    public User UpdateUser(User updatedUser)
    {
        var existingUser = _users.Single(user => user.Id == updatedUser.Id);

        existingUser.FirstName = updatedUser.FirstName;
        existingUser.LastName = updatedUser.LastName;
        existingUser.Email = updatedUser.Email;

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