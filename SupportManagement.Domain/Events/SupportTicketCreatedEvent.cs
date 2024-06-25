namespace SupportManagement.Domain.Events;

public class SupportTicketCreatedEvent
{
    public string SupportTicketNumber { get; set; }
    public string UserEmail { get; set; }
    public DateTime IssueDate { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
}
