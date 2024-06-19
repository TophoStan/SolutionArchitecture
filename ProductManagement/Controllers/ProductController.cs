using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain;
using ProductManagement.Domain.Events;
using ProductManagement.Services;
using RabbitMQ.domain;

namespace ProductManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    private readonly IBus _bus;

    public ProductController(ProductService productService, IBus bus)
    {
        _productService = productService;
        _bus = bus;
    }
    //get product by id
    [HttpGet]
    public async Task<IActionResult> GetProductAsync()
    {
        //var product = await _productService.GetProductAsync(id);
        //if (product == null)
        //    return NotFound();
        IInsertedEvent product = new ProductInsertedEvent
        {
            ProductName = "Product 1",
            ProductDescription = "Product 1 Description",
            Price = 100,
            StockQuantity = 10,
            Category = "Category 1"
        };
        //        {
        //            "ProductName": "Product 1",
        //"ProductDescription": "Product 1 Description",
        //"Price": 100,
        //"StockQuantity": 10,
        //"Category": "Category 1"
        //}


        await _bus.Publish(product);




        Console.WriteLine("GetProducts");
        return Ok();
    }

}
