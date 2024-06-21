using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain;

namespace ProductManagement.Infrastructure;

public class ProductMySQLContext : DbContext
{
    public ProductMySQLContext(DbContextOptions<ProductMySQLContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
