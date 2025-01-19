using LanControl.Components.Pages;
using Microsoft.AspNetCore.Mvc;
using TakasakiStudio.Lina.AspNet.Controllers;

namespace LanControl.Controllers;

[ApiController]
[Route("login")]
public class LoginController : PageController
{
    [HttpGet]
    public IActionResult LoginPage()
    {
        return RenderComponent<Login>();
    }
}