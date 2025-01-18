using System.Globalization;
using LanControl.Core.Models;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels.Interfaces;

namespace LanControl.Core.Services;

public class DiscordWebhookLogService(IMessageQueueService messageQueueService) : IDiscordWebhookLogService
{
    public async Task LogWebhook(string action, string userName, string date)
    {
        var dateToDateTime = DateTime.Parse(date, new CultureInfo("en-US"));
        var log = new Log(userName, action, dateToDateTime);

        var webhook = log.ToDiscordWebhook();

        await messageQueueService.QueueMessageAsync(webhook);
    }
}