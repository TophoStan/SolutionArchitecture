using BallComSolution.Domain;
using Microsoft.EntityFrameworkCore;

namespace BallComSolution.Infrastructure
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create unique index on Supplier.SupplierId
            modelBuilder.Entity<Supplier>().HasKey(s => s.SupplierId);
            modelBuilder.Entity<Supplier>().HasIndex(s => s.SupplierId).IsUnique();

            var Logitech = new Supplier {
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



            // Configure rest of supplier 
            modelBuilder.Entity<Supplier>().HasData(
                    Logitech, Pokemon, RedBull
                );
                
        }
    }
}
