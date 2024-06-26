using MassTransit;
using RabbitMQ.domain;
using UserManagement.Domain;

namespace UserManagement.Infrastructure;

public class AnswerTicketConsumer : IConsumer<ITicketAnsweredEvent>
{
    private readonly UserRepository _userRepository;
    public AnswerTicketConsumer(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Consume(ConsumeContext<ITicketAnsweredEvent> context)
    {
        Console.WriteLine("Support received on SupportManagement: " + context.Message.ToString());

        ITicketAnsweredEvent @event = context.Message;
        AnswerTicket supportTicket = new AnswerTicket
        {
            SupportTicketNumber = @event.SupportTicketNumber,
            AnswerText = @event.AnswerText
        };

        await _userRepository.AddAnswerOfTicket(supportTicket);
    }
}
