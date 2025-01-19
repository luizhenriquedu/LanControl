using System.Globalization;
using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels.Interfaces;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Services;
[Service<IDiscordWebhookLogService>]
public class DiscordWebhookLogService(
    IMessageQueueService messageQueueService, 
    IServerPreferencesRepository serverPreferencesRepository
    ) : IDiscordWebhookLogService
{
    public async Task LogWebhook(string action, string userName, DateTime date, string? created = null)
    {
        if (!await IsWebhookLogEnabled()) return;
        var log = new Log(userName, action, date, created);

        var webhook = log.ToDiscordWebhook();

        await messageQueueService.QueueMessageAsync(webhook);
    }

    private async Task<bool> IsWebhookLogEnabled()
    {
        var preferences = await serverPreferencesRepository.Get(x => x.EnableWebhookLog);
        return preferences is null ? false : preferences.EnableWebhookLog;
    } 
}