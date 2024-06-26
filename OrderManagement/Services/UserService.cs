using OrderManagement.Domain;
using OrderManagement.Domain.Events;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.User;

namespace OrderManagement.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> AddUser(User user)
    {
        var result = await _userRepository.AddUserAsync(user);
        var eventResult = await _userRepository.SaveEventAsync(user.Email, "AddUser", user);

        if (!result || !eventResult)
            return false;

        //var @event = new UserAddedEvent
        //{
        //    Email = user.Email,
        //    FirstName = user.FirstName,
        //    LastName = user.LastName
        //};
        //_eventPublisher.Publish(@event);

        return true;
    }

    public async Task<bool> UpdateUser(User user)
    {
        var result = await _userRepository.UpdateUserAsync(user);
        var eventResult = await _userRepository.SaveEventAsync(user.Email, "AddUser", user);

        if (!result || !eventResult)
            return false;

        //var @event = new UserAddedEvent
        //{
        //    Email = user.Email,
        //    FirstName = user.FirstName,
        //    LastName = user.LastName
        //};
        //_eventPublisher.Publish(@event);

        return true;
    }
}
