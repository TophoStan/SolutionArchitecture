using ProductManagement.Domain;
using ProductManagement.Domain.Events;
using ProductManagement.Infrastructure;

namespace ProductManagement.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly EventPublisher _eventPublisher;

    public ProductService(ProductRepository productRepository, EventPublisher eventPublisher)
    {
        _productRepository = productRepository;
        _eventPublisher = eventPublisher;
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
        _eventPublisher.Publish(@event);
    }

    public async Task<Product> GetProductAsync(int productId)
    {
        return await _productRepository.GetProductAsync(productId);
    }
}
