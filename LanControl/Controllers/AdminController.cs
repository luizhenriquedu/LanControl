using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanControl.Controllers;
[ApiController]
[Route("/api/user/admin")]
public class AdminController(IUserService userService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateAdmin([FromBody] CreateUserViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest();
        await userService.CreateAdmin(model);
        return Ok();
    }
}