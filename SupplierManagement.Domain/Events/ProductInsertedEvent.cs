using MassTransit;
using RabbitMQ.domain;

namespace SupplierManagement.Domain.Events;
public class ProductInsertedEvent : IInsertedEvent
{
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
}
