using SupportManagement.Domain;

namespace SupportManagement.Infrastructure;

public class SupportRepository
{
    private readonly SupportMySQLContext _SQLcontext;

    public SupportRepository(SupportMySQLContext context)
    {
        _SQLcontext = context;
    }

    public async Task<Support> AddSupportTicketAsync(Support support)
    {
        try
        {
            await _SQLcontext.Supports.AddAsync(support);
            await _SQLcontext.SaveChangesAsync();

            var addedSupport = _SQLcontext.Supports.FirstOrDefault(s => s.SupportTicketNumber == support.SupportTicketNumber);
            if (addedSupport == null)
            {
                throw new InvalidOperationException("Support ticket not found after adding.");
            }

            return addedSupport;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException("Failed to add support ticket.", e);
        }
    }
    public async Task AnswerSupportTicketAsync(AnswerTicket answer)
    {
        try
        {
            _SQLcontext.AnswerTickets.Update(answer);
            await _SQLcontext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ApplicationException("Failed to update support ticket.", e);
        }
    }

    public async Task<Support?> GetSupportAsync(string supportId)
    {
        return await _SQLcontext.Supports.FindAsync(supportId!);
    }

    public async Task<AnswerTicket?> GetTicketAsync(string ticketId)
    {
        return await _SQLcontext.AnswerTickets.FindAsync(ticketId!);
    }
}
