using InvoiceManagement.Services;
using MassTransit;
using RabbitMQ.domain;

namespace InvoiceManagement.Infrastructure;

public class OrderConsumer : IConsumer<IOrderConfirmedEvent>
{

    private readonly InvoiceService _invoiceService;

    public OrderConsumer(InvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    public async Task Consume(ConsumeContext<IOrderConfirmedEvent> context)
    {
        throw new NotImplementedException();
        IOrderConfirmedEvent order = context.Message;

        //TODO: Convert event to invoice
        //_invoiceService.createInvoice(order);


    }
}
