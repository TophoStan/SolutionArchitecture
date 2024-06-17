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
            SupplierId = supplier.SupplierId,
            Name = supplier.Name,
            Address = supplier.Address,
            ContactDetails = supplier.ContactDetails
        };
        _eventPublisher.Publish(@event);
    }
}
