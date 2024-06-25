using SupportManagement.Domain;

namespace SupportManagement.Infrastructure;

public class SupportRepository
{
    private readonly SupportMySQLContext _SQLcontext;
    private readonly SupportMongoDBContext _MongoDBcontext;

    public SupportRepository(SupportMySQLContext context, SupportMongoDBContext mongoDBcontext)
    {
        _SQLcontext = context;
        _MongoDBcontext = mongoDBcontext;
    }

    public async Task<Support> AddSupportTicketAsync(Support support)
    {
        try
        {
            await _SQLcontext.Supports.AddAsync(support);
            await _SQLcontext.SaveChangesAsync();

            await _MongoDBcontext.SQLToMongoDB();

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

    public async Task<Support?> GetSupportAsync(string supportId)
    {
        return await _SQLcontext.Supports.FindAsync(supportId!);
    }
}
