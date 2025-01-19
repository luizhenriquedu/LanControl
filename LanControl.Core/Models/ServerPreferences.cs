using TakasakiStudio.Lina.Database.Models;

namespace LanControl.Core.Models;

public class ServerPreferences : BaseEntity<int>
{
    public required bool EnableWebhookLog { get; set; } = false;
}