using System.Globalization;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services;

public class AuthenticationService(IUserRepository userRepository, IDiscordWebhookLogService logService) : IAuthenticationService
{
    public async Task<UserViewModel?> LoginAsync(UserLoginViewModel model)
    {
        var user = await userRepository.GetByEmail(model.Email);
        if (user is null || !user.IsValidPassword(model.Password)) return null;
        var date = DateTime.Now;
        await logService.LogWebhook("LOGIN", user.Name, date);
        return user.ToViewModel();
    }
}