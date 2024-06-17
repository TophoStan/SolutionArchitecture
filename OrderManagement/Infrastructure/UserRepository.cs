using OrderManagement.Domain;

namespace OrderManagement.Infrastructure;

public class UserRepository
{
    private readonly Dictionary<string, User> _users = new Dictionary<string, User>();

    public void AddUser(User user)
    {
        _users[user.Email] = user;
    }

    public User GetUser(string userNumber)
    {
        _users.TryGetValue(userNumber, out var user);
        return user;
    }
}
