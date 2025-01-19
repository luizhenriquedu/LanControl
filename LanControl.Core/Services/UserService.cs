using LanControl.Shared.Exceptions;
using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Services;

[Service<IUserService>]
public class UserService(IUserRepository userRepository, IDiscordWebhookLogService webhookLogService) : IUserService
{
    public async ValueTask<bool?> CreateAdmin(CreateUserViewModel model, string creatorName)
    {
        if (await userRepository.Exists(x => x.Email == model.Email)) throw new LoginException("This email is already in use");
        await userRepository.Add(User.CreateAdmin(model.Email, model.Password, model.Name));
        await userRepository.Commit();
        await webhookLogService.LogWebhook("ADMIN ACCOUNT CREATED", creatorName, DateTime.Now, model.Name);
        return true;
    }
}