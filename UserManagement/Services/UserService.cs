using MassTransit;
using RabbitMQ.domain;
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
    }

    public async Task RequestUserSupport(Support support, int userId)
    {
        var supportWithId = await _userRepository.AddTicketOfUserAsync(support, userId);

        ISupportTicketCreatedEvent @event = new SupportTicketCreatedEvent
        {
            SupportTicketNumber = support.SupportTicketNumber,
            UserEmail = support.UserEmail,
            IssueDate = support.IssueDate,
            Status = support.Status,
            Description = support.Description,
            SupportId = supportWithId.SupportId,
            UserId = userId,
        };
        await _bus.Publish(@event);
    }
}
