
using System.Globalization;
using LanControl.Core.Models;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.Extensions;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Services;
[Service<IDiscordWebhookLogService>]
public class DiscordWebhookLogService(
    IMessageQueueService messageQueueService) : IDiscordWebhookLogService
{
    public async Task LogWebhook(string action,
        User user,
        Preferences preferences,
        string? created = null)
    {
        if (!preferences.EnableWebhookLog) return;
        var date = DateTimeOffset.UtcNow.ToBrasiliaDate();
        
        var log = new Log(user.Name, action, date, created);
        var webhook = log.ToDiscordWebhook();
        await messageQueueService.QueueMessageAsync(webhook,preferences.WebhookUrl);
    }
    
    
}