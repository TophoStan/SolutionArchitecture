using Microsoft.AspNetCore.Mvc;
using OrderManagement.Services;
using OrderManagement.Domain;

namespace OrderManagement.Controllers;

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
    [Route("/adduser")]
    public IActionResult AddUser([FromBody] User user)
    {
        Console.WriteLine("Added user");
        _userService.AddUser(user);
        return Ok();
    }
}
