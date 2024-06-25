﻿namespace SupportManagement.Domain;

public class Support
{
    public int SupportId { get; set; }
    public string SupportTicketNumber { get; set; }
    public string UserEmail { get; set; }
    public DateTime IssueDate { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
}
