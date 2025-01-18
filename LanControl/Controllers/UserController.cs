using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanControl.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginViewModel model)
    {
        if (!ModelState.IsValid) return Unauthorized();
        var user = await authenticationService.LoginAsync(model);
        if (user is null)
        {
            return Unauthorized();
        }
        return Ok();
    }
}