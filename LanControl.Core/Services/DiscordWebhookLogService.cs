using System.Globalization;
using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;
using LanControl.Shared.ViewModels.Interfaces;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Services;
[Service<IDiscordWebhookLogService>]
public class DiscordWebhookLogService(
    IMessageQueueService messageQueueService, 
    IUserRepository userRepository,
    IPreferencesRepository preferencesRepository
    ) : IDiscordWebhookLogService
{
    public async Task LogWebhook(string action,
        string userName,
        DateTime date,
        string userId,
        Preferences? serverPreferences = null,
        string? created = null)
    {
        var user = await userRepository.Get(x => x.Id == userId);
        if (user is null) return;
        var preferences = await GetServerPreferencesIfNull(serverPreferences, user);
        if (preferences is null || 
            (!preferences.EnableWebhookLog || preferences.WebhookUrl == String.Empty)) 
            return;
        
        var log = new Log(userName, action, date, created);

        var webhook = log.ToDiscordWebhook();
        
        await messageQueueService.QueueMessageAsync(webhook,preferences.WebhookUrl);
    }

    private async Task<Preferences?> GetServerPreferencesIfNull(Preferences? serverPreferences, User user)
    {
        if (serverPreferences is not null) return serverPreferences;
        var preferences = await preferencesRepository.Get(x => x.ServerId == user.ServerId);
        return preferences;
        

        
    }
    
}