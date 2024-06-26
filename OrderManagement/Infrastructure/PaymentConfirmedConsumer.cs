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

        // Publish OrderConfirmedEvent
        IPaymentConfirmedEvent @event = context.Message;

        Domain.Order order = new();

       await _orderService.AddOrder(order);
    }
}
