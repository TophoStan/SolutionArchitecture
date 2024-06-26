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

        Product RbWodka = new Product()
        {
            ProductName = "Red Bull Wodka",
            ProductDescription = "Energy drink with wodka",
            Price = 5,
            StockQuantity = 10,
            Category = "Drinks",
            SupplierId = 3
        };
        Product RbWaterMelon = new Product()
        {
            ProductName = "Red Bull Watermelon",
            ProductDescription = "Energy drink with watermelon",
            Price = 3,
            StockQuantity = 20,
            Category = "Drinks",
            SupplierId = 3
        };
        Product RbGrapefruit = new Product()
        {
            ProductName = "Red Bull Grapefruit",
            ProductDescription = "Energy drink with grapefruit",
            Price = 4,
            StockQuantity = 15,
            Category = "Drinks",
            SupplierId = 3
        };

        modelBuilder.Entity<Product>().HasData(RbWodka, RbWaterMelon, RbGrapefruit);

        Product G603 = new Product()
        {
            ProductName = "Logitech G603",
            ProductDescription = "Wireless gaming mouse",
            Price = 70,
            StockQuantity = 5,
            Category = "Electronics",
            SupplierId = 1
        };
        Product GPro = new Product()
        {
            ProductName = "Logitech G Pro",
            ProductDescription = "Wired gaming mouse",
            Price = 50,
            StockQuantity = 10,
            Category = "Electronics",
            SupplierId = 1
        };
        Product G213 = new Product()
        {
            ProductName = "Logitech G213",
            ProductDescription = "Gaming keyboard",
            Price = 40,
            StockQuantity = 15,
            Category = "Electronics",
            SupplierId = 1
        };

        modelBuilder.Entity<Product>().HasData(G603, GPro, G213);

        Product pikachu = new Product()
        {
            ProductName = "Pikachu",
            ProductDescription = "Electric pokemon",
            Price = 100,
            StockQuantity = 1,
            Category = "Toys",
            SupplierId = 2
        };

        Product snorlax = new Product()
        {
            ProductName = "Snorlax",
            ProductDescription = "Sleeping pokemon",
            Price = 200,
            StockQuantity = 1,
            Category = "Toys",
            SupplierId = 2
        };

        Product charizard = new Product()
        {
            ProductName = "Charizard",
            ProductDescription = "Fire pokemon",
            Price = 150,
            StockQuantity = 1,
            Category = "Toys",
            SupplierId = 2
        };

        modelBuilder.Entity<Product>().HasData(pikachu, snorlax, charizard);
    }
}
