using Microsoft.EntityFrameworkCore;
using SupplierManagement.Domain;

namespace SupplierManagement.Infrastructure;

public class SupplierMySQLContext : DbContext
{
    public SupplierMySQLContext(DbContextOptions<SupplierMySQLContext> options) : base(options) { }

    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Create unique index on Supplier.SupplierId
        modelBuilder.Entity<Supplier>().HasKey(s => s.SupplierId);
        modelBuilder.Entity<Supplier>().HasIndex(s => s.SupplierId).IsUnique();
        modelBuilder.Entity<Supplier>().HasIndex(s => s.SupplierName).IsUnique();

        //The list of products only have a reference to the supplier by supplierId
        modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        modelBuilder.Entity<Product>().HasOne(p => p.Supplier).WithMany(s => s.Products).HasForeignKey(p => p.SupplierId);


        // The product object only has the columns of productId and productName the other properties should not be saved in the database
        modelBuilder.Entity<Product>().Property(p => p.ProductName).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.ProductDescription).HasDefaultValue("No description").IsRequired(false);
        modelBuilder.Entity<Product>().Property(p => p.Price).HasDefaultValue(0).IsRequired(false);
        modelBuilder.Entity<Product>().Property(p => p.StockQuantity).HasDefaultValue(0).IsRequired(false);
        modelBuilder.Entity<Product>().Property(p => p.Category).HasDefaultValue("No category").IsRequired(false);





        var Logitech = new Supplier
        {
            SupplierId = 1,
            ContactEmail = "Logitech@mail.com",
            ContactName = "John Doe",
            ContactPhone = "123456789",
            SupplierName = "Logitech BV.",
            Address = "Logitech address"
        };

        var Pokemon = new Supplier
        {
            SupplierId = 2,
            ContactEmail = "Pokemon@mail.com",
            ContactName = "Ash Ketchum",
            ContactPhone = "987654321",
            SupplierName = "Pokemon Inc.",
            Address = "Pokemon address"

        };

        var RedBull = new Supplier
        {
            SupplierId = 3,
            ContactEmail = "Redbull@mail.com",
            ContactName = "Max Verstappen",
            ContactPhone = "123456789",
            SupplierName = "Red Bull Racing",
            Address = "Red Bull Racing address"
        };

        modelBuilder.Entity<Supplier>().HasData(
                Logitech, Pokemon, RedBull
            );
    }
}
