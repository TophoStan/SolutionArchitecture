using MassTransit;
using NotificationManagement.Service;
using RabbitMQ.domain;

namespace NotificationManagement.Infrastructure;

public class TrackingRegisteredConsumer : IConsumer<ITrackingStartedEvent>
{
    private readonly NotificationService _notificationService;

    public TrackingRegisteredConsumer(NotificationService service)
    {
        _notificationService = service;
    }

    public async Task Consume(ConsumeContext<ITrackingStartedEvent> context)
    {
        ITrackingStartedEvent order = context.Message;

        //TODO: Convert event to invoice
        _notificationService.SendNotification("TrackinID " + order.TrackingId + ": Your package from " + order.ProductId + " will be deliverd: " + order.EstimatedDelivery);
    }
}
