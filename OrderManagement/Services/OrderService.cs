using OrderManagement.Infrastructure;
using OrderManagement.Domain;
using OrderManagement.Infrastructure.Order;
using OrderManagement.Domain.Events;
using MassTransit;
using RabbitMQ.domain;
using RabbitMQ.domain.OrderEvents;

namespace OrderManagement.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly IBus _bus;

    public OrderService(OrderRepository orderRepository, IBus bus)
    {
        _orderRepository = orderRepository;
        _bus = bus;
    }

    public async Task<bool> AddOrder(Order order)
    {
        var result = await _orderRepository.AddOrderAsync(order);

        if (!result)
            return false;
        
        IOrderConfirmedEvent @event = new OrderConfirmedEvent() { OrderDate = order.OrderDate, OrderNumber = order.OrderNumber, SupplierName = order.SupplierName, UserName = order.User.Email };
        await _bus.Publish(@event);

        return true;
    }

    public async Task<bool> UpdateOrder(Order order)
    {
        var result = await _orderRepository.UpdateOrderAsync(order);

        if (result == null)
            return false;

        IOrderUpdatedEvent @event = new OrderUpdatedEvent()
        {
            OrderDate = result.OrderDate,
            OrderNumber = result.OrderNumber,
            Status = result.Status,
            UserId = result.UserId,
        };

        await _bus.Publish(@event);
        return true;
    }

    public async Task<bool> CancelOrder(string OrderNumber)
    {
        var result = await _orderRepository.CancelOrderAsync(OrderNumber);

        if (result == null)
            return false;

        IOrderCanceledEvent @event = new OrderCanceledEvent() 
        { 
            OrderDate = result.OrderDate,
            OrderNumber = result.OrderNumber,
            Status = result.Status,
            UserId = result.UserId,
        };

        await _bus.Publish(@event);
        return true;
    }
}
