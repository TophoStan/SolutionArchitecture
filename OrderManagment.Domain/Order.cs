using MongoDB.Bson.Serialization.Attributes;

namespace OrderManagement.Domain;

public class Order
{
    [BsonId]
    public string OrderNumber { get; set; }
    public string UserEmail { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
}
