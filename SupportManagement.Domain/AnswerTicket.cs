namespace SupportManagement.Domain;

public class AnswerTicket
{
    public int AnswerTicketId { get; set; }
    public string SupportTicketNumber { get; set; }
    public string AnswerText { get; set; }
public Support? Support { get; set; }
}
