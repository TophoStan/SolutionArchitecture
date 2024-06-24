using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

    public async Task<bool> UpdateOrderAsync(Domain.Order order)
    {
        try
        {
            _sqlContext.Orders.Update(order);
            await _sqlContext.SaveChangesAsync();

            await _mongoDBcontext.SQLToMongoDB();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> SaveEventAsync(string aggregateId, string eventType, object eventData)
    {
        try
        {
            var orderEvent = new Domain.Events.OrderEvent
            {
                AggregateId = aggregateId,
                EventType = eventType,
                EventData = JsonSerializer.Serialize(eventData),
                EventTime = DateTime.Now
            };

            await _sqlContext.Events.AddAsync(orderEvent);
            await _sqlContext.SaveChangesAsync();

            return true;
        }
        catch   
        {
            return false;
        }

    }

    public async Task<IEnumerable<Domain.Events.OrderEvent>> GetEventsAsync(string aggregateId)
    {
        return await _sqlContext.Events
            .Where(e => e.AggregateId == aggregateId)
            .OrderBy(e => e.EventTime)
            .ToListAsync();
    }

    public async Task<Domain.Order> GetOrderAsync(string orderNumber)
    {
        return await _sqlContext.Orders.FindAsync(orderNumber);
    }
}
