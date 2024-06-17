﻿using BallComSolution.Domain;
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
    public async Task<IActionResult> RegisterSupplier([FromBody] Supplier supplier)
    {
        Console.WriteLine("Registering supplier");
        await _supplierService.RegisterSupplierAsync(supplier);
        return Ok();
    }
}
