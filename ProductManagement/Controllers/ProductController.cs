using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain;
using ProductManagement.Services;

namespace ProductManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    //get product by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductAsync(int id)
    {
        var product = await _productService.GetProductAsync(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }
    
}
