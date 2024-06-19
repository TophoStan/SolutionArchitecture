
using MassTransit;
using ProductManagement.Domain;

namespace ProductManagement.Infrastructure;

public class Worker : BackgroundService
{

    private readonly IBus _bus;

    public Worker(IBus bus)
    {
        _bus = bus;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _bus.Publish(new Product
            {
                ProductId = "1",
                ProductName = "Product 1",
                ProductDescription = "Product 1 Description",
                Price = 100,
                StockQuantity = 10,
                Category = "Category 1"
            }, stoppingToken);

            await Task.Delay(1000, stoppingToken);
        }
    }
}
