using OrderManagement.Domain;

namespace OrderManagement.Infrastructure.Product;

public class ProductRepository
{
    private readonly Dictionary<string, Domain.Product> _products = new Dictionary<string, Domain.Product>();

    public void AddProduct(Domain.Product product)
    {
        _products[product.ProductId] = product;
    }

    public Domain.Product GetProduct(string productId)
    {
        _products.TryGetValue(productId, out var product);
        return product;
    }
}
