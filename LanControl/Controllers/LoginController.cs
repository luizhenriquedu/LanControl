using LanControl.Components.Pages;
using LanControl.Core.Services.Interfaces;
using LanControl.Extensions;
using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TakasakiStudio.Lina.AspNet.Controllers;

namespace LanControl.Controllers;

[ApiController]
[Route("login")]
public class LoginController(IAuthenticationService authenticationService) : PageController
{
    
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest();
        var user = await authenticationService.LoginAsync(model);
        if (user is null) return Unauthorized();
        await HttpContext.Session.SetUser(user);
        return Ok();
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Ok("/");
    }
    [HttpGet]
    public IActionResult LoginPage()
    {
        return RenderComponent<Login>();
    }
}