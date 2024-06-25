using SupportManagement.Domain;
using SupportManagement.Domain.Events;
using SupportManagement.Infrastructure;

namespace SupportManagement.Services;

public class SupportService
{
    private readonly SupportRepository _supportRepository;

    public SupportService(SupportRepository supportRepository)
    {
        _supportRepository = supportRepository;
    }

    public async Task CreateSupportTicket(Support support)
    {
        var result = await _supportRepository.AddSupportAsync(support);
        if (!result)
            return;

        var @event = new SupportTicketCreatedEvent
        {
            SupportTicketNumber = support.SupportTicketNumber,
            UserEmail = support.UserEmail,
            IssueDate = support.IssueDate,
            Status = support.Status,
            Description = support.Description,
        };
        //_eventPublisher.Publish(@event);
    }
}
