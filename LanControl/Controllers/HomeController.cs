using LanControl.Components.Pages;
using Microsoft.AspNetCore.Mvc;
using TakasakiStudio.Lina.AspNet.Controllers;
namespace LanControl.Controllers;
[ApiController]
[Route("/")]
public class HomeController : PageController
{
    [HttpGet]
    public IActionResult Index()
    {
        return RenderComponent<Home>();
    }
}