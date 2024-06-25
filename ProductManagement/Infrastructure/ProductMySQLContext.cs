using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain;

namespace ProductManagement.Infrastructure;

public class ProductMySQLContext : DbContext
{
    public ProductMySQLContext(DbContextOptions<ProductMySQLContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    //Onmodelcreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Create unique index on Product.ProductId
        modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
    }




    }
