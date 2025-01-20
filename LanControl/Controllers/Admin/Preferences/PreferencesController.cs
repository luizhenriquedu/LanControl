using LanControl.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace LanControl.Controllers.Admin.Preferences;
[ApiController]
[Route("api/admin/preferences")]
[SessionAuthorize]
public class PreferencesController : ControllerBase
{
   
    
}