using MassTransit;
using OrderManagement.Services;
using RabbitMQ.domain;

namespace OrderManagement.Infrastructure;

public class PaymentConfirmedConsumer : IConsumer<IPaymentConfirmedEvent>
{
    private readonly OrderService _orderService;
    public PaymentConfirmedConsumer(OrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task Consume(ConsumeContext<IPaymentConfirmedEvent> context)
    {
        Console.WriteLine("PaymentConfirmedConsumer");
        // Publish OrderConfirmedEvent
        IPaymentConfirmedEvent @event = context.Message;
        if (!@event.IsForwardPaid) {
            Console.WriteLine("Order has not been paid yet.");
            return;
        };

        Domain.Order order = new() { User = new Domain.User()};

        order.OrderNumber = @event.OrderNumber;
        order.OrderDate = DateTime.Now;
        order.Status = "Confirmed";
        order.User.Email = @event.UserName;
        order.SupplierName = @event.SupplierName;
        order.ProductIdQuantity = @event.ProductIdQuantity;

        order.Products = new List<Domain.Product>();

        foreach (var item in @event.ProductIdQuantity)
        {
            order.Products.Add(new Domain.Product() { ProductId = item.Key.ToString(), Quantity = item.Value });
        }


        await _orderService.AddOrder(order);
    }
}
