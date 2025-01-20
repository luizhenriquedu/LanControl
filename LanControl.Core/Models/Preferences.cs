using System.ComponentModel.DataAnnotations.Schema;
using TakasakiStudio.Lina.Database.Models;

namespace LanControl.Core.Models;

public class Preferences : BaseEntity<int>
{
    public required bool EnableWebhookLog { get; set; }
    public required string WebhookUrl { get; set; } = String.Empty;
    [ForeignKey("ServerId")]
    public required int ServerId { get; init; }
    public required Server Server { get; init; }

    public static Preferences CreatePreferences(int serverId, Server server)
    {
        var preferences = new Preferences()
        {
            ServerId = serverId,
            Server = server,
            WebhookUrl = String.Empty,
            EnableWebhookLog = false,
        };
        return preferences;
    }
}