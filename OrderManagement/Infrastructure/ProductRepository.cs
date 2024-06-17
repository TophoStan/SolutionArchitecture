using OrderManagement.Domain;

namespace OrderManagement.Infrastructure;

public class ProductRepository
{
    private readonly Dictionary<string, Product> _products = new Dictionary<string, Product>();

    public void AddProduct(Product product)
    {
        _products[product.ProductId] = product;
    }

    public Product GetProduct(string productId)
    {
        _products.TryGetValue(productId, out var product);
        return product;
    }
}
