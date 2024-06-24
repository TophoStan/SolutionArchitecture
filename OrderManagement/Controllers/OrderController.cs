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
    [Route("addorder")]
    public async Task<IActionResult> AddOrder([FromBody] Order order)
    {
        Console.WriteLine("Added order");
        
        var result = await _orderService.AddOrder(order);
        return result ? Ok() : BadRequest();
    }

    [HttpPut]
    [Route("updateorder")]
    public async Task<IActionResult> UpdateOrder([FromBody] Order order)
    {
        Console.WriteLine("Updated order");
        
        var result = await _orderService.UpdateOrder(order);
        return result ? Ok() : BadRequest();
    }

    [HttpGet]
    [Route("getevents")]
    public async Task<IActionResult> GetEvents(string orderNumber)
    {
        var events = await _orderService.GetOrderEvents(orderNumber);
        return Ok(events);
    }
}
