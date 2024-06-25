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

    public async Task<Product> AddProductAsync(Product product)
    {
        try
        {
            await _SQLcontext.Products.AddAsync(product);
            await _SQLcontext.SaveChangesAsync();


            //TODO await _MongoDBcontext.SQLToMongoDB();

            return _SQLcontext.Products.FirstOrDefault(p => p.ProductName == product.ProductName);
        }
        catch
        {
            return null;
        }

    }

    public async Task<Product?> GetProductAsync(int productId)
    {
        return await _SQLcontext.Products.FindAsync(productId);
    }
}
