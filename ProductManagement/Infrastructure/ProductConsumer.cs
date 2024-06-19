using MassTransit;
using ProductManagement.Domain;
using ProductManagement.Domain.Events;
using RabbitMQ.domain;

namespace ProductManagement.Infrastructure;

public class ProductConsumer : IConsumer<IInsertedEvent>
{
    public Task Consume(ConsumeContext<IInsertedEvent> context)
    {
        Console.WriteLine("Product received: " + context.Message.ToString());
        return Task.CompletedTask;
    }
}
