using LanControl.Attributes;
using LanControl.Core.Services.Interfaces;
using LanControl.Extensions;
using LanControl.Shared.Exceptions;
using LanControl.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace LanControl.Controllers.Admin.Preferences;

[ApiController]
[SessionAuthorize]
[Route("/api/admin/preferences/webhook")]
public class PreferencesWebhookController(IPreferencesWebhookService preferencesWebhookService) : ControllerBase
{
    [HttpPatch("toggle-webhook")]
    public async Task<IActionResult> UpdateEnabledWebhook()
    {
        try
        {
            var user = HttpContext.Session.GetUser();
        
            await preferencesWebhookService.ToggleWebhook(user!.Id);
            return Ok();
        }
        catch (AdminAuthenticationException e){ return Unauthorized(e.Message);}
        
    }
    [HttpPatch("update-webhook-url")]
    public async Task<IActionResult> UpdateWebhookUrl([FromBody] UpdateWebhookUrlViewModel model)
    {
     
        if (!ModelState.IsValid) return BadRequest();
        try
        {
            var user = HttpContext.Session.GetUser();
            await preferencesWebhookService.UpdateWebhookUrl(model.Url, user!.Id, user.Name);
            return Ok();
        }
        catch (AdminAuthenticationException e)
        {
            return Unauthorized(e.Message);
        }
    }
}