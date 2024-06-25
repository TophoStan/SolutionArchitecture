using SupplierManagement.Infrastructure;
using UserManagement.Domain;
using UserManagement.Domain.Events;
using UserManagement.Infrastructure;

namespace UserManagement.Services;

public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly EventPublisher _eventPublisher;

    public UserService(UserRepository userRepository, EventPublisher eventPublisher)
    {
        _userRepository = userRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task RegisterUserAsync(User user)
    {
        var result = await _userRepository.AddUserAsync(user);
        if (!result)
            return;

        var @event = new UserRegisteredEvent
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address,
        };
        _eventPublisher.Publish(@event);
    }
}
