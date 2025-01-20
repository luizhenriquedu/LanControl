using LanControl.Core.Services;
using LanControl.Core.Services.Interfaces;
using LanControl.Extensions;
using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanControl.Controllers;

[ApiController]
[Route("api/server")]
public class ServerController(IServerService serverService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateServer(CreateServerViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest();
        var user = await serverService.CreateServer(model);
        await HttpContext.Session.SetUser(user);
        return Ok();
    }
}