using MassTransit;
using OrderManagement.Services;
using RabbitMQ.domain;

namespace OrderManagement.Infrastructure;

public class PaymentConfirmedConsumer : IConsumer<IPaymentConfirmedEvent>
{
    private readonly OrderService _orderService;
    public PaymentConfirmedConsumer(OrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task Consume(ConsumeContext<IPaymentConfirmedEvent> context)
    {
        Console.WriteLine("PaymentConfirmedConsumer");

        // Publish OrderConfirmedEvent
        IPaymentConfirmedEvent @event = context.Message;

        Domain.Order order = new() { User = new Domain.User()};

        order.OrderNumber = @event.OrderNumber;
        order.OrderDate = DateTime.Now;
        order.Status = "Confirmed";
        order.User.Email = @event.UserName;
        order.SupplierName = @event.SupplierName;


        await _orderService.AddOrder(order);
    }
}
