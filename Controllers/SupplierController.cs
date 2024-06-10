using Microsoft.AspNetCore.Mvc;
using SupplierManagementService.Application;
using SupplierManagementService.Domain;

namespace SupplierManagementService.Controllers;
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

