using RabbitMQ.domain;

namespace OrderManagement.Infrastructure;

public class PaymentConfirmedEvent : IPaymentConfirmedEvent
{
    public string PaymentId { get; set; }
    public string OrderId { get; set; }
    public Dictionary<int, int> ProductIdQuantity { get; set; } = new Dictionary<int, int>();
}
