using OrderManagement.Domain;
using OrderManagement.Domain.Events;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Product;

namespace OrderManagement.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> AddProduct(Product product)
    {
        var result = await _productRepository.AddProductAsync(product);
        var eventResult = await _productRepository.SaveEventAsync(product.ProductId, "AddProduct", product);

        if (!result || !eventResult)
            return false;

        //var @event = new ProductAddedEvent
        //{
        //    ProductId = product.ProductId,
        //    ProductName = product.ProductName,
        //    ProductDescription = product.ProductDescription,
        //    Price = product.Price
        //};
        //_eventPublisher.Publish(@event);

        return true;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var result = await _productRepository.UpdateProductAsync(product);
        var eventResult = await _productRepository.SaveEventAsync(product.ProductId, "UpdateProduct", product);

        if (!result || !eventResult)
            return false;

        //var @event = new ProductUpdatedEvent
        //{
        //    ProductId = product.ProductId,
        //    ProductName = product.ProductName,
        //    ProductDescription = product.ProductDescription,
        //    Price = product.Price
        //};
        //_eventPublisher.Publish(@event);

        return true;
    }
}
