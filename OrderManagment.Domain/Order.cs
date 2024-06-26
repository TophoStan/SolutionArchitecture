using MongoDB.Bson.Serialization.Attributes;

namespace OrderManagement.Domain;

public class Order
{
    [BsonId]
    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public int UserId { get; set; }

    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
    public virtual User? User { get; set; }
}
