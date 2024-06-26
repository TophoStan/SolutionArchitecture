using RabbitMQ.domain;

namespace SupportManagement.Domain.Events;

public class TicketAnsweredEvent : ITicketAnsweredEvent
{
    public string SupportTicketNumber { get; set; }
    public string AnswerText { get; set; }
}
