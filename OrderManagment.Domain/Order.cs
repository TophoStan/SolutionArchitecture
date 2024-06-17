namespace OrderManagement.Domain;

public class Order
{
    public string OrderNumber { get; set; }
    public string UserEmail { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
}
