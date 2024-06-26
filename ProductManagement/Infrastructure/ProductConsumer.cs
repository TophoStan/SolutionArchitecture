using MassTransit;
using ProductManagement.Domain;
using RabbitMQ.domain;

namespace ProductManagement.Infrastructure;

public class ProductConsumer : IConsumer<IInsertedEvent>, IConsumer<IOrderConfirmedEvent>
{
    private readonly ProductRepository _productRepository;
    public ProductConsumer(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task Consume(ConsumeContext<IInsertedEvent> context)
    {
        Console.WriteLine("Product received on Product management: " + context.Message.ToString());
        // Save to database
        IInsertedEvent @event = context.Message;
        Product product = new Product
        {
            ProductName = @event.ProductName,
            ProductDescription = @event.ProductDescription,
            Price = @event.Price,
            StockQuantity = @event.StockQuantity,
            Category = @event.Category,
            SupplierId = @event.SupplierId,
            ProductId = @event.ProductId
            
        };

        await _productRepository.AddProductAsync(product);
    }

    public async Task Consume(ConsumeContext<IOrderConfirmedEvent> context)
    {
        Console.WriteLine("Product quantity changed on Product management: " + context.Message.ToString());
        
        IOrderConfirmedEvent @event = context.Message;
        foreach (var item in @event.ProductsWithQuanitity)
        {
            await _productRepository.UpdateProductQuantityAsync(item.Key, item.Value);
        }
    }
}
