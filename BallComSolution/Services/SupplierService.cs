using BallComSolution.Domain;
using BallComSolution.Domain.Events;
using BallComSolution.Infrastructure;

namespace BallComSolution.Services;

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
        await _supplierRepository.AddSupplierAsync(supplier);
        var @event = new SupplierRegisteredEvent
        {
            SupplierName = supplier.SupplierName,
            ContactName = supplier.SupplierName,
            ContactEmail = supplier.ContactEmail,
            ContactPhone = supplier.ContactPhone,
            Address = supplier.ContactName,
        };
        _eventPublisher.Publish(@event);
    }
}
