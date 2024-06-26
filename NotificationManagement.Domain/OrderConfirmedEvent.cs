using RabbitMQ.domain;

namespace NotificationManagement.Domain;

public class OrderConfirmedEvent : IOrderConfirmedEvent
{
    public string OrderNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime OrderDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string SupplierName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
