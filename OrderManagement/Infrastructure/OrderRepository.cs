using OrderManagement.Domain;

namespace OrderManagement.Infrastructure;

public class OrderRepository
{
    private readonly Dictionary<string, Order> _orders = new Dictionary<string, Order>();

    public void AddOrder(Order order)
    {
        _orders[order.OrderNumber] = order;
    }

    public Order GetOrder(string orderNumber)
    {
        _orders.TryGetValue(orderNumber, out var order);
        return order;
    }
}
