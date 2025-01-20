using LanControl.Attributes;
using LanControl.Extensions;
using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TakasakiStudio.Lina.AspNet.Controllers;

namespace LanControl.Controllers;
[ApiController]
[Route("admin/preferences")]
[SessionAuthorize]
public class Preferences()
{
    [HttpPut("update-webhook")]
    public IActionResult UpdateWebhook([FromBody] UpdateWebhookUrlViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest();
        var user = HttpContext.Session.GetUser();
        return 
    }
    
}