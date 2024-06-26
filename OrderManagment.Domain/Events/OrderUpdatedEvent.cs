namespace OrderManagement.Domain.Events;

public class OrderUpdatedEvent
{
    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
}
