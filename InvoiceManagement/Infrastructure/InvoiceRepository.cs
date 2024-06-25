using InvoiceManagement.Domain;

namespace InvoiceManagement.Infrastructure
{
    public class InvoiceRepository
    {
        private readonly InvoiceMySQLContext _dbContext;

        public InvoiceRepository(InvoiceMySQLContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async void createInvoice(Invoice invoice)
        {
            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync();
        }
    }
}
