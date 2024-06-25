﻿using SupplierManagement.Domain;
using SupplierManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace SupplierManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupplierController : ControllerBase
{
    private readonly SupplierService _supplierService;

    public SupplierController(SupplierService supplierService)
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

    [HttpPost]
    [Route("insertproduct")]
    public async Task<IActionResult> InsertProduct([FromBody] Product product)
    {
        await _supplierService.InsertProduct(product);
        return Ok();
    }
}
