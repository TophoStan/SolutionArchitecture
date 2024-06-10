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
    [Route("/registersupplier")]
    public IActionResult RegisterSupplier([FromBody] Supplier supplier)
    {
        _supplierService.RegisterSupplier(supplier);
        return Ok();
    }
}

