using SupplierManagementService.Domain;
using SupplierManagementService.Domain.Events;
using SupplierManagementService.Infrastructure;

namespace SupplierManagementService.Application;

public class SupplierService
{
    private readonly SupplierRepository _supplierRepository;
    private readonly EventPublisher _eventPublisher;

    public SupplierService(SupplierRepository supplierRepository, EventPublisher eventPublisher)
    {
        _supplierRepository = supplierRepository;
        _eventPublisher = eventPublisher;
    }

    public void RegisterSupplier(Supplier supplier)
    {
        _supplierRepository.AddSupplier(supplier); // Add supplier to the database
        var @event = new SupplierRegisteredEvent
        {
            SupplierId = supplier.SupplierId,
            Name = supplier.Name,
            Address = supplier.Address,
            ContactDetails = supplier.ContactDetails
        };
        _eventPublisher.Publish(@event);
    }
}
