using SupplierManagement.Domain;
using SupplierManagement.Domain.Events;
using SupplierManagement.Infrastructure;

namespace SupplierManagement.Services;

public class SupplierService
{
    private readonly SupplierRepository _supplierRepository;
    private readonly EventPublisher _eventPublisher;

    public SupplierService(SupplierRepository supplierRepository, EventPublisher eventPublisher)
    {
        _supplierRepository = supplierRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task RegisterSupplierAsync(Supplier supplier)
    {
        var result = await _supplierRepository.AddSupplierAsync(supplier);
        if (!result)
            return;

        var @event = new SupplierRegisteredEvent
        {
            SupplierName = supplier.SupplierName,
            ContactName = supplier.ContactName,
            ContactEmail = supplier.ContactEmail,
            ContactPhone = supplier.ContactPhone,
            Address = supplier.Address,
        };
        _eventPublisher.Publish(@event);
    }
}
