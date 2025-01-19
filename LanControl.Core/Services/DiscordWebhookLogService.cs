using System.Globalization;
using LanControl.Core.Models;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels.Interfaces;

namespace LanControl.Core.Services;

public class DiscordWebhookLogService(IMessageQueueService messageQueueService) : IDiscordWebhookLogService
{
    public async Task LogWebhook(string action, string userName, DateTime date, string? created = null)
    {
        var log = new Log(userName, action, date, created);

        var webhook = log.ToDiscordWebhook();

        await messageQueueService.QueueMessageAsync(webhook);
    }
}