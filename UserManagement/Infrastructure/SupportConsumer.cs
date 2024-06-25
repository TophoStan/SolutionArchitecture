using MassTransit;
using RabbitMQ.domain;

namespace UserManagement.Infrastructure;

public class SupportConsumer : IConsumer<ISupportTicketCreatedEvent>
{
    public Task Consume(ConsumeContext<ISupportTicketCreatedEvent> context)
    {
        Console.WriteLine("Support received on UserManagement: " + context.Message.ToString());
        return Task.CompletedTask;
    }
}
