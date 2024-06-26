using MassTransit;
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

    public async Task RegisterSupportAsync(Support support)
    {
        var insertResult = await _supportRepository.AddSupportTicketAsync(support);
    }

    public async Task AnswerCustomerTicketAsync(AnswerTicket answer)
    {
        try
        {
            var ticket = await _supportRepository.GetTicketAsync(answer.SupportTicketNumber);

            if (ticket == null)
            {
                throw new KeyNotFoundException($"Support ticket with number '{answer.SupportTicketNumber}' not found.");
            }

            await _supportRepository.AnswerSupportTicketAsync(ticket);

            var @event = new TicketAnsweredEvent
            {
                SupportTicketNumber = answer.SupportTicketNumber,
                AnswerText = answer.AnswerText
            };

            await _bus.Publish(@event);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException("Failed to answer customer ticket.", e);
        }
    }
}
