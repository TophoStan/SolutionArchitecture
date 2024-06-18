using Microsoft.AspNetCore.Mvc;
using OrderManagement.Services;
using OrderManagement.Domain;

namespace OrderManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    [Route("addproduct")]
    public IActionResult AddProduct([FromBody] Product product)
    {
        Console.WriteLine("Added product");
        _productService.AddProduct(product);
        return Ok();
    }
}
