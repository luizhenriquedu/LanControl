using LanControl.Attributes;
using LanControl.Core.Services.Interfaces;
using LanControl.Extensions;
using LanControl.Shared.Exceptions;
using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanControl.Controllers;
[ApiController]
[Route("/api/admin")]
public class AdminController(IUserService userService, IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("create")]
    [SessionAuthorize]
    public async Task<IActionResult> CreateAdmin([FromBody] CreateUserViewModel model)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = HttpContext.Session.GetUser();
            await userService.CreateAdmin(model, user!.Name);
            return CreatedAtAction(nameof(userService.CreateAdmin), model.Email);
        }
        catch (LoginException e)
        {
            return Unauthorized(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest();
        var user = await authenticationService.LoginAsync(model);
        if (user is null)
        {
            return Unauthorized();
        }
        await HttpContext.Session.SetUser(user);
        return Ok();
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Ok("/");
    }
}