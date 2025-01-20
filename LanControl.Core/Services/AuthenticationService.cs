using System.Globalization;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Services;
[Service<IAuthenticationService>]
public class AuthenticationService(IUserRepository userRepository,
    IDiscordWebhookLogService logService,
    IServerRepository serverRepository) : IAuthenticationService
{
    public async Task<UserViewModel?> LoginAsync(UserLoginViewModel model)
    {
        var user = await userRepository.Get(x => x.Email == model.Email);
        
        if (user is null || !user.IsValidPassword(model.Password)) return null;
        var server = await serverRepository.Get(x => x.Id == user.ServerId);
        if (server is null) return null;
        var date = DateTime.Now;
        await logService.LogWebhook("LOGIN", user.Name, date, user.Id, server.Preferences);
        return user.ToViewModel();
    }
}