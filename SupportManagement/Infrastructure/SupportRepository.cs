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

    public async Task<bool> AddSupportAsync(Support support)
    {
        try
        {
            await _SQLcontext.Supports.AddAsync(support);
            await _SQLcontext.SaveChangesAsync();

            await _MongoDBcontext.SQLToMongoDB();
            return true;
        } catch 
        {
            return false;
        }
        
    }

    public async Task<Support?> GetSupportAsync(string supportId)
    {
        return await _SQLcontext.Supports.FindAsync(supportId!);
    }
}
