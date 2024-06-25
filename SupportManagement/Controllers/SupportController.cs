using Microsoft.AspNetCore.Mvc;
using SupportManagement.Domain;
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

    [HttpPost]
    [Route("ticket")]
    public async Task<IActionResult> CreateSupportTicket([FromBody] Support support)
    {
        await _supportService.CreateSupportTicketAsync(support);
        return Ok();
    }
}
