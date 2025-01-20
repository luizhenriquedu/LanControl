using LanControl.Attributes;
using LanControl.Core.Services.Interfaces;
using LanControl.Extensions;
using LanControl.Shared.Exceptions;
using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanControl.Controllers.Admin;
[ApiController]
[Route("/api/admin")]
[SessionAuthorize]
public class AdminController(IUserService userService ) : ControllerBase
{
    
    [HttpPost("create")]
    
    public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminToServerViewModel model)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = HttpContext.Session.GetUser();
            var admin = await userService.CreateAdmin(model, user!.Id);
            Console.WriteLine(admin);
            if (admin is null) return Unauthorized();
            return CreatedAtAction(nameof(userService.CreateAdmin), model.Email);
        }
        catch (LoginException e)
        {
            return Unauthorized(e.Message);
        }
    }
    
    
}