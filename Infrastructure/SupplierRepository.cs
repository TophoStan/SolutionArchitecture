using SupplierManagement.Domain;

namespace SupplierManagementService.Infrastructure;
public class SupplierRepository
{
    private readonly Dictionary<string, Supplier> _suppliers = new Dictionary<string, Supplier>();

    public void AddSupplier(Supplier supplier)
    {
        _suppliers[supplier.SupplierId] = supplier;
    }

    public Supplier GetSupplier(string supplierId)
    {
        _suppliers.TryGetValue(supplierId, out var supplier);
        return supplier;
    }
}

