using MassTransit;
using MongoDB.Bson;
using RabbitMQ.domain.OrderEvents;

namespace OrderManagement.Infrastructure.Events;

public class EventOrderUpdatedConsumer : IConsumer<IOrderUpdatedEvent>
{
    private readonly EventsRepository _eventsRepository;

    public EventOrderUpdatedConsumer(EventsRepository eventsRepository)
    {
        _eventsRepository = eventsRepository;
    }

    public async Task Consume(ConsumeContext<IOrderUpdatedEvent> context)
    {
        Console.WriteLine("Order received on Events: " + context.Message.ToString());
        
        IOrderUpdatedEvent @event = context.Message;
        string eventType = "OrderUpdate";

        await _eventsRepository.SaveEventAsync(@event.OrderNumber, eventType, @event);
    }
}
