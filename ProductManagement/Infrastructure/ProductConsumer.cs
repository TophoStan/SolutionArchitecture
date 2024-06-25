using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using ProductManagement.Domain;
using ProductManagement.Domain.Events;
using RabbitMQ.domain;

namespace ProductManagement.Infrastructure;

public class ProductConsumer : IConsumer<IInsertedEvent>
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
            StockQuantity = @event.StockQuantity
        };

        await _productRepository.AddProductAsync(product);
        return;
    }
}
