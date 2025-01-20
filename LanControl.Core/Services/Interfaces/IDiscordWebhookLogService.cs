using LanControl.Core.Models;

namespace LanControl.Core.Services.Interfaces;

public interface IDiscordWebhookLogService
{
    public Task LogWebhook(
        string action,
        User userName, 
        Preferences preferences,
        string? created = null);
}