using BallComSolution.Domain;
using Microsoft.EntityFrameworkCore;

namespace BallComSolution.Infrastructure
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
