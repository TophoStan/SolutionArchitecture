using OrderManagement.Domain;

namespace OrderManagement.Infrastructure.User;

public class UserRepository
{
    private readonly Dictionary<string, Domain.User> _users = new Dictionary<string, Domain.User>();

    public void AddUser(Domain.User user)
    {
        _users[user.Email] = user;
    }

    public Domain.User GetUser(string userNumber)
    {
        _users.TryGetValue(userNumber, out var user);
        return user;
    }
}
