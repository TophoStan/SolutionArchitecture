using ProductManagement.Domain;
using ProductManagement.Domain.Events;
using ProductManagement.Infrastructure;

namespace ProductManagement.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task RegisterProductAsync(Product product)
    {
        var result = await _productRepository.AddProductAsync(product);
        if (!result)
            return;

        var @event = new ProductInsertedEvent
        {
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            Category = product.Category
                
        };
    }

    public async Task<Product> GetProductAsync(int productId)
    {
        return await _productRepository.GetProductAsync(productId);
    }
}
