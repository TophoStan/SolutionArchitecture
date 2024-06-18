using ProductManagement.Domain;

namespace ProductManagement.Infrastructure;

public class ProductRepository
{
    private readonly ProductMySQLContext _SQLcontext;
    private readonly ProductMongoDBContext _MongoDBcontext;

    public ProductRepository(ProductMySQLContext context, ProductMongoDBContext mongoDBcontext)
    {
        _SQLcontext = context;
        _MongoDBcontext = mongoDBcontext;
    }

    public async Task<bool> AddProductAsync(Product supplier)
    {
        try
        {
            await _SQLcontext.Products.AddAsync(supplier);
            await _SQLcontext.SaveChangesAsync();

            //TODO await _MongoDBcontext.SQLToMongoDB();
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<Product> GetProductAsync(int productId)
    {
        return await _SQLcontext.Products.FindAsync(productId);
    }
}
