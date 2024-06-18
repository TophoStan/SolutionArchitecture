using OrderManagement.Domain;
using OrderManagement.Infrastructure.Product;

namespace OrderManagement.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    //private readonly EventPublisher _eventPublisher;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
        //_eventPublisher = eventPublisher;
    }

    public void AddProduct(Product product)
    {
        _productRepository.AddProduct(product);

        // event shit
    }
}
