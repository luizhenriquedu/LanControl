using Isopoh.Cryptography.Argon2;
using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.Exceptions;
using LanControl.Shared.ViewModels;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Services;

[Service<IPreferencesService>]
public class PreferencesService(
    IPreferencesRepository preferencesRepository, 
    IDiscordWebhookLogService webhookLogService,
    IUserRepository userRepository,
    IServerRepository serverRepository
    ) 
    : IPreferencesService
{
    public async ValueTask UpdateEnabledWebhook(string userId)
    {
        var user = await userRepository.Get(x => x.Id == userId);
        if (user is null) return;
        var server = await serverRepository.Get(x => x.Id == user.ServerId);
        if (server is null) return;
        var preferences = await preferencesRepository.Get(x => x.ServerId == user.ServerId);
        if (preferences is null) return;
        preferences.EnableWebhookLog = !preferences.EnableWebhookLog;
        preferencesRepository.Update(preferences);
        await preferencesRepository.Commit();
        var enabledOrDisabled = preferences.EnableWebhookLog ? "ENABLED" : "DISABLED";
        await webhookLogService.LogWebhook($"{enabledOrDisabled} WEBHOOK LOG", 
            user.Name, DateTime.Now, user.Id, preferences);
    }
    
    public async ValueTask UpdateWebhookUrl(string url, string userId, string userName)
    {
        var user = await userRepository.Get(x => x.Id == userId);
        if (user is null) return;
        var server = await serverRepository.Get(x => x.Id == user.ServerId);
        if (server is null) return;
        var result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                     && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        if (!result) throw new UpdateWebhookException("Invalid url provided");
        var preferences = await preferencesRepository.Get(x => x.ServerId == user.ServerId);
        
        if (preferences is not null)
        {
            preferences.WebhookUrl = url;
            preferencesRepository.Update(preferences);
            await preferencesRepository.Commit();
            await webhookLogService.LogWebhook("UPDATE WEBHOOK URL", userName, 
                DateTime.Now, user.Id, preferences);
            
        }

        
    }
    
}