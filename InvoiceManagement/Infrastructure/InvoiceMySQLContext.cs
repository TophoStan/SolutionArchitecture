using InvoiceManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagement.Infrastructure;

public class InvoiceMySQLContext : DbContext
{
    public InvoiceMySQLContext(DbContextOptions<InvoiceMySQLContext> options) : base(options) { }

    public DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>().HasKey(x => x.InvoiceNumber);
    }
}
