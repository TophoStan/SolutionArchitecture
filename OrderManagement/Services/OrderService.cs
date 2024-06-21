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

    public async Task<bool> AddOrder(Order order)
    {
        var result = await _orderRepository.AddOrderAsync(order);
        var eventResult = await _orderRepository.SaveEventAsync(order.OrderNumber, "AddOrder", order);

        if (!result || !eventResult)
            return false;

        var @event = new OrderAddedEvent
        {
            OrderNumber = order.OrderNumber,
            UserEmail = order.UserEmail,
            OrderDate = order.OrderDate,
            Status = order.Status
        };
        _eventPublisher.Publish(@event);

        return true;
    }

    public async Task<bool> UpdateOrder(Order order)
    {
        var result = await _orderRepository.UpdateOrderAsync(order);
        var eventResult = await _orderRepository.SaveEventAsync(order.OrderNumber, "UpdateOrder", order);

        if (!result || !eventResult)
            return false;

        var @event = new OrderUpdatedEvent
        {
            OrderNumber = order.OrderNumber,
            UserEmail = order.UserEmail,
            OrderDate = order.OrderDate,
            Status = order.Status
        };
        _eventPublisher.Publish(@event);

        return true;
    }

    public async Task<IEnumerable<OrderEvent>> GetOrderEvents(string orderNumber)
    {
        return await _orderRepository.GetEventsAsync(orderNumber);
    }
}
