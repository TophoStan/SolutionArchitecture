using ProductManagement.Domain;

namespace ProductManagement.Infrastructure;

public class ProductRepository
{
    private readonly ProductMySQLContext _SQLcontext;

    public ProductRepository(ProductMySQLContext context)
    {
        _SQLcontext = context;
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
        catch(Exception e)
        {
            Console.WriteLine(e);
            return null;
        }

    }

    public async Task<Product> UpdateProductQuantityAsync(int productKey, int quantity)
    {
        try
        {
            var product = await _SQLcontext.Products.FindAsync(productKey);
            product.StockQuantity -= quantity;
            await _SQLcontext.SaveChangesAsync();
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<Product?> GetProductAsync(int productId)
    {
        return await _SQLcontext.Products.FindAsync(productId);
    }
}
