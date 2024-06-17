using OrderManagement.Domain;
using OrderManagement.Infrastructure.User;

namespace OrderManagement.Services;

public class UserService
{
    private readonly UserRepository _userRepository;
    //private readonly EventPublisher _eventPublisher;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
        //_eventPublisher = eventPublisher;
    }

    public void AddUser(User user)
    {
        _userRepository.AddUser(user);

        // event shit
    }
}
