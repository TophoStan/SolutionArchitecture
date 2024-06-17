using BallComSolution.Domain;
using BallComSolution.Services;
using Microsoft.AspNetCore.Mvc;

namespace BallComSolution.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly SupplierService _supplierService;

    public SuppliersController(SupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterSupplier([FromBody] Supplier supplier)
    {
        await _supplierService.RegisterSupplierAsync(supplier);
        return Ok();
    }
}
