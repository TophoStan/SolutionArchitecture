using OrderManagement.Infrastructure;
using OrderManagement.Domain;
using OrderManagement.Infrastructure.Order;
using OrderManagement.Domain.Events;

namespace OrderManagement.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly EventPublisher _eventPublisher;

    public OrderService(OrderRepository orderRepository, EventPublisher eventPublisher)
    {
        _orderRepository = orderRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task AddOrder(Order order)
    {
        var result = await _orderRepository.AddOrderAsync(order);
        if (!result)
            return;

        var @event = new OrderAddedEvent
        {
            OrderNumber = order.OrderNumber,
            UserEmail = order.UserEmail,
            OrderDate = order.OrderDate,
            Status = order.Status
        };
        _eventPublisher.Publish(@event);
    }
}
