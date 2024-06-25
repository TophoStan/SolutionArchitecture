using MassTransit;
using RabbitMQ.domain.UserEvents;
using UserManagement.Domain;
using UserManagement.Domain.Events;
using UserManagement.Infrastructure;

namespace UserManagement.Services;

public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly IBus _bus;

    public UserService(UserRepository userRepository, IBus bus)
    {
        _userRepository = userRepository;
        _bus = bus;
    }

    public async Task RegisterUserAsync(User user)
    {
        var result = await _userRepository.AddUserAsync(user);
        
        // add event
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);

        IUserUpdatedEvent @event = new UserUpdatedEvent
        {
            UserId = user.UserId,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address,
        };
        await _bus.Publish(@event);

    }
}
