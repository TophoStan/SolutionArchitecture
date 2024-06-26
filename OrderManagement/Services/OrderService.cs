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
        var eventResult = await _orderRepository.SaveEventAsync(order.OrderNumber, "AddOrder", order);

        if (!result || !eventResult)
            return false;


        //Data that gets sent over the bus
        //var @event = new OrderAddedEvent
        //{
        //    OrderNumber = order.OrderNumber,
        //    OrderDate = order.OrderDate,
        //    Status = order.Status
        //};
        IOrderConfirmedEvent @event = new OrderConfirmedEvent() { OrderDate = order.OrderDate, OrderNumber = order.OrderNumber, SupplierName = order.SupplierName, UserName = order.User.Email };
        await _bus.Publish(@event);

        return true;
    }

    public async Task<bool> UpdateOrder(Order order)
    {
        var result = await _orderRepository.UpdateOrderAsync(order);
        var eventResult = await _orderRepository.SaveEventAsync(order.OrderNumber, "UpdateOrder", order);

        if (!result || !eventResult)
            return false;

        //var @event = new OrderUpdatedEvent
        //{
        //    OrderNumber = order.OrderNumber,
        //    OrderDate = order.OrderDate,
        //    Status = order.Status
        //};
        //_eventPublisher.Publish(@event);

        return true;
    }

    public async Task<bool> CancelOrder(string OrderNumber)
    {
        var result = await _orderRepository.CancelOrderAsync(OrderNumber);
        var eventResult = await _orderRepository.SaveEventAsync(OrderNumber, "CancelOrder", result);

        if (result == null || !eventResult)
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

    public async Task<IEnumerable<OrderEvent>> GetOrderEvents(string orderNumber)
    {
        return await _orderRepository.GetEventsAsync(orderNumber);
    }

}
