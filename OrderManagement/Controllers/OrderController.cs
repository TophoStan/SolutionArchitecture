using Microsoft.AspNetCore.Mvc;
using OrderManagement.Services;
using OrderManagement.Domain;

namespace OrderManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    [Route("/addorder")]
    public IActionResult AddOrder([FromBody] Order order)
    {
        Console.WriteLine("Added order");
        _orderService.AddOrder(order);
        return Ok();
    }
}
