using MassTransit;
using NotificationManagament.Service;
using RabbitMQ.domain;

namespace NotificationManagament.Infrastructure;

public class OrderConfirmedConsumer : IConsumer<IOrderConfirmedEvent>
{

    private readonly NotificationService _notificationService;
    public OrderConfirmedConsumer(NotificationService service)
    {
        _notificationService = service;

    }

    public async Task Consume(ConsumeContext<IOrderConfirmedEvent> context)
    {
        IOrderConfirmedEvent order = context.Message;

        //TODO: Convert event to invoice
        _notificationService.SendNotification("Order Confirmed: " + order.ToString());
        throw new NotImplementedException();


    }
}

