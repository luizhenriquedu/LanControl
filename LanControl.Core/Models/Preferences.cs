using TakasakiStudio.Lina.Database.Models;

namespace LanControl.Core.Models;

public class Preferences : BaseEntity<int>
{
    public required bool EnableWebhookLog { get; set; } = false;
    public required string WebhookUrl { get; set; } = String.Empty;
}