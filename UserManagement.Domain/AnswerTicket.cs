namespace UserManagement.Domain;

public class AnswerTicket
{
    public string SupportTicketNumber { get; set; }
    public string AnswerText { get; set; }
    public int AnswerTicketId { get; set; }

    public User? User { get; set; }
}
