using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Infrastructure.Order;

public class OrderMySQLContext : DbContext
{
    public OrderMySQLContext(DbContextOptions<OrderMySQLContext> options) : base(options){ }

    public DbSet<Domain.Order> Orders { get; set; }

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
    }
}
