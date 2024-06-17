using BallComSolution.Domain;

namespace BallComSolution.Infrastructure;

public class SupplierRepository
{
    private readonly SupplierDbContext _context;

    public SupplierRepository(SupplierDbContext context)
    {
        _context = context;
    }

    public async Task AddSupplierAsync(Supplier supplier)
    {
        await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task<Supplier> GetSupplierAsync(string supplierId)
    {
        return await _context.Suppliers.FindAsync(supplierId);
    }
}
