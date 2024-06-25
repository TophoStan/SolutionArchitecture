using Microsoft.AspNetCore.Mvc;
using SupportManagement.Services;

namespace SupportManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupportController : ControllerBase
{
    private readonly SupportService _supportService;

    public SupportController(SupportService supportService)
    {
        _supportService = supportService;
    }
}
