using MassTransit;
using RabbitMQ.domain;

namespace UserManagement.Infrastructure;

public class AnswerTicketConsumer : IConsumer<ITicketAnsweredEvent>
{
    public Task Consume(ConsumeContext<ITicketAnsweredEvent> context)
    {
        Console.WriteLine($"Answer received for support ticket: " + context.Message.ToString());
        return Task.CompletedTask;
    }
}
