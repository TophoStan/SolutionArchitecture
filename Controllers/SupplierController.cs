namespace SupplierManagementService.Controllers;

using Microsoft.AspNetCore.Mvc;
using SupplierManagementService.Application;
using SupplierManagementService.Domain;

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
    public IActionResult RegisterSupplier([FromBody] Supplier supplier)
    {
        _supplierService.RegisterSupplier(supplier);
        return Ok();
    }

    
}

