using LanControl.Attributes;
using LanControl.Core.Services.Interfaces;
using LanControl.Extensions;
using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TakasakiStudio.Lina.AspNet.Controllers;

namespace LanControl.Controllers;
[ApiController]
[Route("api/admin/preferences")]
[SessionAuthorize]
public class Preferences(IPreferencesService preferencesService) : ControllerBase
{
    [HttpPatch("update-enabled-webhook")]
    public async Task<IActionResult> UpdateEnabledWebhook()
    {
        var user = HttpContext.Session.GetUser();
        await preferencesService.UpdateEnabledWebhook(user!.Id);
        return Ok();
    }
    [HttpPatch("update-webhook")]
    public async Task<IActionResult> UpdateWebhookUrl([FromBody] UpdateWebhookUrlViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest();
        var user = HttpContext.Session.GetUser();
        await preferencesService.UpdateWebhookUrl(model.Url, user.Id, user.Name);
        return Ok();
    }
    
}