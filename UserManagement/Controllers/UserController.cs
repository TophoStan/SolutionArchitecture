using UserManagement.Domain;
using UserManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser([FromBody] User user)
    {
        await _userService.RegisterUserAsync(user);
        return Ok();
    }
}
