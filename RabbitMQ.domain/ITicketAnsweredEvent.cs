namespace RabbitMQ.domain;

public interface ITicketAnsweredEvent
{
    public string SupportTicketNumber { get; set; }
    public string AnswerText { get; set; }
}
