using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace OrderManagement.Infrastructure.Order;

public class OrderMySQLContext : DbContext
{
    public OrderMySQLContext(DbContextOptions<OrderMySQLContext> options) : base(options){ }

    public DbSet<Domain.Order> Orders { get; set; }
    public DbSet<Domain.Events.OrderEvent> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Order>().HasKey(o => o.OrderNumber);
        modelBuilder.Entity<Domain.Order>().HasIndex(o => o.OrderNumber).IsUnique();

        var order1 = new Domain.Order
        {
            OrderNumber = "1234",
            UserEmail = "stijn@mail.com",
            OrderDate = DateTime.Now,
            Status = "Processing"
        };

        var order2 = new Domain.Order
        {
            OrderNumber = "4321",
            UserEmail = "thomas@mail.com",
            OrderDate = DateTime.Now,
            Status = "Done"
        };

        modelBuilder.Entity<Domain.Order>().HasData(
            order1, order2
        );

        modelBuilder.Entity<Domain.Events.OrderEvent>().HasKey(e => e.EventId);
        modelBuilder.Entity<Domain.Events.OrderEvent>().Property(e => e.EventId).ValueGeneratedOnAdd();
        modelBuilder.Entity<Domain.Events.OrderEvent>().HasIndex(e => e.AggregateId);
        modelBuilder.Entity<Domain.Events.OrderEvent>().Property(e => e.EventData).IsRequired();
        modelBuilder.Entity<Domain.Events.OrderEvent>().Property(e => e.EventTime).IsRequired();

        var orderEvent1 = new Domain.Events.OrderEvent
        {
            EventId = -1,
            AggregateId = "1234",
            EventType = "OrderCreated",
            EventData = JsonSerializer.Serialize(order1),
            EventTime = DateTime.Now
        };

        var orderEvent2 = new Domain.Events.OrderEvent
        {
            EventId = -2,
            AggregateId = "4321",
            EventType = "OrderCreated",
            EventData = JsonSerializer.Serialize(order2),
            EventTime = DateTime.Now
        };

        modelBuilder.Entity<Domain.Events.OrderEvent>().HasData(
            orderEvent1, orderEvent2
        );
    }
}
