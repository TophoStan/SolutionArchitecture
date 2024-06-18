namespace OrderManagement.Infrastructure.Order;

public class OrderRepository
{
    private readonly OrderMySQLContext _sqlContext;
    private readonly OrderMongoDBContext _mongoDBcontext;

    public OrderRepository(OrderMySQLContext context, OrderMongoDBContext mongoDBcontext)
    {
        _sqlContext = context;
        _mongoDBcontext = mongoDBcontext;
    }

    public async Task<bool> AddOrderAsync(Domain.Order order)
    {
        try
        {
            await _sqlContext.Orders.AddAsync(order);
            await _sqlContext.SaveChangesAsync();

            await _mongoDBcontext.SQLToMongoDB();
            return true;
        }
        catch
        {
            return false;
        }   
    }

    public async Task<Domain.Order> GetOrderAsync(string orderNumber)
    {
        return await _sqlContext.Orders.FindAsync(orderNumber);
    }
}
