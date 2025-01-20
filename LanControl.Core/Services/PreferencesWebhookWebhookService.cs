using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.Exceptions;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Services;

[Service<IPreferencesWebhookService>]
public class PreferencesWebhookWebhookService(
    IPreferencesRepository preferencesRepository, 
    IDiscordWebhookLogService webhookLogService,
    IUserRepository userRepository
    ) 
    : IPreferencesWebhookService
{

    public async ValueTask ToggleWebhook(string userId)
    {
        var user = await userRepository.Get(x => x.Id == userId);
        
        if (user is null) 
            throw new AdminAuthenticationException("You are not authenticated");
        
        var preferences = await preferencesRepository.Get(x => x.ServerId == user.ServerId);
        
        if (preferences is null) 
            throw new  AdminAuthenticationException("This server does not exist");
        
        preferences.EnableWebhookLog = !preferences.EnableWebhookLog;
        var enabledOrDisabled = preferences.EnableWebhookLog ? "ENABLED" : "DISABLED";
        var message = $"{enabledOrDisabled} WEBHOOK LOG";
        await webhookLogService.LogWebhook(message , user, preferences);
        
        preferencesRepository.Update(preferences);
        await preferencesRepository.Commit();
        
    }
    
    public async ValueTask UpdateWebhookUrl(string url, string userId, string userName)
    {
        var user = await userRepository.Get(x => x.Id == userId);
        
        if(user is null) throw new AdminAuthenticationException("You are not authenticated");
        
        var server = user.Server;
        var preferences = server.Preferences;
        
        if (preferences is null) 
            throw new AdminAuthenticationException("You are not authenticated");
        
        if (!IsUrlValid(url)) 
            throw new UpdateWebhookException("Invalid url provided");
        
        preferences.WebhookUrl = url;
        
        preferencesRepository.Update(preferences);
        
        await preferencesRepository.Commit();
        await webhookLogService.LogWebhook("UPDATE WEBHOOK URL", user, preferences);
        
    }
    private static bool IsUrlValid(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
    
}