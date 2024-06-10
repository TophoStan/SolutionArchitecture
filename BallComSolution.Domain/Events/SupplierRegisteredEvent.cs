namespace BallComSolution.Domain.Events;

public class SupplierRegisteredEvent
{
    public string SupplierId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactDetails { get; set; }
}
