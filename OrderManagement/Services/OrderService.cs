using OrderManagement.Infrastructure;
using OrderManagement.Domain;

namespace OrderManagement.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    //private readonly EventPublisher _eventPublisher;

    public OrderService(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
        //_eventPublisher = eventPublisher;
    }

    public void AddOrder(Order order)
    {
        _orderRepository.AddOrder(order);

        // event shit
    }
}
