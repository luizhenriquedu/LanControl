using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanControl.Controllers;

[ApiController]
[Route("/api/user")]
public class LoginController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest();
        var user = await authenticationService.LoginAsync(model);
        if (user is null)
        {
            return Unauthorized();
        }
        return Ok();
    }

    
}