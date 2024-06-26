using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Infrastructure.Order;

public class OrderMySQLContext : DbContext
{
    public OrderMySQLContext(DbContextOptions<OrderMySQLContext> options) : base(options){ }

    public DbSet<Domain.Order> Orders { get; set; }
    public DbSet<Domain.Product> Products { get; set; }
    public DbSet<Domain.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Product
        modelBuilder.Entity<Domain.Product>().HasKey(p => p.ProductId);
        modelBuilder.Entity<Domain.Product>().HasIndex(p => p.ProductId).IsUnique();

        var Keyboard = new Domain.Product
        {
            ProductId = "1",
            ProductName = "Keyboard",
            ProductDescription = "Mechanical Keyboard with RGB lighting",
            Price = 50
        };

        var Mouse = new Domain.Product
        {
            ProductId = "2",
            ProductName = "Mouse",
            ProductDescription = "Gaming Mouse with 12 programmable buttons",
            Price = 30
        };

        var Headset = new Domain.Product
        {
            ProductId = "3",
            ProductName = "Headset",
            ProductDescription = "Wireless Headset with 7.1 Surround Sound",
            Price = 70
        };

        modelBuilder.Entity<Domain.Product>().HasData(
               Keyboard, Mouse, Headset
           );

        // User
        modelBuilder.Entity<Domain.User>().HasKey(o => o.UserId);
        modelBuilder.Entity<Domain.User>().HasIndex(o => o.UserId).IsUnique();

        var Logitech = new Domain.User
        {
            UserId = 1,
            Email = "Logitech@mail.com",
            FirstName = "John",
            LastName = "Doe"
        };

        var Pokemon = new Domain.User
        {
            UserId = 2,
            Email = "Pokemon@mail.com",
            FirstName = "Ash",
            LastName = "Ketchum"

        };

        var RedBull = new Domain.User
        {
            UserId = 3,
            Email = "Redbull@mail.com",
            FirstName = "Max",
            LastName = "Verstappen"
        };

        modelBuilder.Entity<Domain.User>().HasData(
                Logitech, Pokemon, RedBull
            );

        // Order
        modelBuilder.Entity<Domain.Order>().HasKey(o => o.OrderNumber);
        modelBuilder.Entity<Domain.Order>().HasIndex(o => o.OrderNumber).IsUnique();

        // Order - Products
        modelBuilder.Entity<Domain.Order>().HasMany(o => o.Products).WithMany(p => p.Orders);

        // Order - User
        modelBuilder.Entity<Domain.Order>().HasOne(o => o.User).WithMany(u => u.Orders);

        var order1 = new Domain.Order
        {
            OrderNumber = "1",
            OrderDate = DateTime.Now,
            Status = "Delivered",
            UserId = 1,
            SupplierName = "Logitech"
        };

        var order2 = new Domain.Order
        {
            OrderNumber = "2",
            OrderDate = DateTime.Now,
            Status = "Processing",
            UserId = 2,
            SupplierName = "Pokemon"
        };

        var order3 = new Domain.Order
        {
            OrderNumber = "3",
            OrderDate = DateTime.Now,
            Status = "Shipped",
            UserId = 3,
            SupplierName = "RedBull"
        };

        modelBuilder.Entity<Domain.Order>().HasData(
                order1, order2, order3
            );

        modelBuilder.Entity("OrderProduct", b =>
        {
            b.HasData(
                new
                {
                    OrdersOrderNumber = "1",
                    ProductsProductId = "1"
                },
                new
                {
                    OrdersOrderNumber = "1",
                    ProductsProductId = "2"
                },
                new
                {
                    OrdersOrderNumber = "2",
                    ProductsProductId = "2"
                },
                new
                {
                    OrdersOrderNumber = "2",
                    ProductsProductId = "3"
                },
                new
                {
                    OrdersOrderNumber = "3",
                    ProductsProductId = "1"
                }
                );
        });
    }
}
