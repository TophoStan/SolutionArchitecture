using MassTransit;
using RabbitMQ.domain;
using SupplierManagement.Domain;
using SupplierManagement.Domain.Events;
using SupplierManagement.Infrastructure;

namespace SupplierManagement.Services;

public class SupplierService
{
    private readonly SupplierRepository _supplierRepository;
    private readonly IBus _bus;

    public SupplierService(SupplierRepository supplierRepository, IBus bus)
    {
        _supplierRepository = supplierRepository;
        _bus = bus;
    }

    public async Task RegisterSupplierAsync(Supplier supplier)
    {
        await _supplierRepository.AddSupplierAsync(supplier);

        //ISupplierRegisteredEvent @event = new SupplierRegisteredEvent
        //{
        //    SupplierName = supplier.SupplierName,
        //    ContactName = supplier.ContactName,
        //    ContactEmail = supplier.ContactEmail,
        //    ContactPhone = supplier.ContactPhone,
        //    Address = supplier.Address,
        //};
        //_eventPublisher.Publish(@event);
    }

    public async Task InsertProduct(Product product )
    {

        // Insert into supplier database only the product id and name


        // Publish the event so that the product management service can insert the product into its database
        IInsertedEvent @event = new ProductInsertedEvent
        {
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            Price = product.Price,
            StockQuantity = product.StockQuantity,

        };
        await _bus.Publish(@event);
    }
}
