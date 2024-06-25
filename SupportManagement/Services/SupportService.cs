using MassTransit;
using RabbitMQ.domain;
using SupportManagement.Domain;
using SupportManagement.Domain.Events;
using SupportManagement.Infrastructure;

namespace SupportManagement.Services;

public class SupportService
{
    private readonly SupportRepository _supportRepository;
    private readonly IBus _bus;

    public SupportService(SupportRepository supportRepository, IBus bus)
    {
        _supportRepository = supportRepository;
        _bus = bus;
    }

    public async Task CreateSupportTicketAsync(Support support)
    {
        var result = await _supportRepository.AddSupportTicketAsync(support);
        if (result == null)
            return;

        ISupportTicketCreatedEvent @event = new SupportTicketCreatedEvent
        {
            SupportTicketNumber = support.SupportTicketNumber,
            UserEmail = support.UserEmail,
            IssueDate = support.IssueDate,
            Status = support.Status,
            Description = support.Description,
        };
        await _bus.Publish(@event);
    }
}
