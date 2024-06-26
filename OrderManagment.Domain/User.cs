﻿using MongoDB.Bson.Serialization.Attributes;

namespace OrderManagement.Domain;

public class User
{
    [BsonId]
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
}
