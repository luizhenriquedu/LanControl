using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanControl.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult Login([FromBody] UserLoginViewModel model)
    {
        if (!ModelState.IsValid) return Unauthorized();
        return Ok();
    }
}