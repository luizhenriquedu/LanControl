using LanControl.Shared.Exceptions;
using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Services;

[Service<IUserService>]
public class UserService(IUserRepository userRepository,
    IDiscordWebhookLogService webhookLogService
    ) : IUserService
{
    public async ValueTask CreateAdmin(CreateUserViewModel model, string creatorId)
    {
        var creator = await userRepository.Get(x => x.Id == creatorId);
        if (creator is null) return;
        var server = creator.Server;
        if (await userRepository.Exists(x => x.Email == model.Email)) throw new LoginException("This email is already in use");
        await userRepository.Add(User.CreateAdmin(model.Email, model.Password, model.Name, server));
        await userRepository.Commit();
        await webhookLogService.LogWebhook("ADMIN ACCOUNT CREATED", creator.Name, DateTime.Now,  model.Name, server.Preferences);
    }

    public async ValueTask CreateTestAdmin(CreateUserViewModel model)
    {
         var server = Server.TestServer();
         var preferences = Preferences.CreatePreferences(server.Id, server);
         server.Preferences = preferences;
         await userRepository.Add(User.CreateAdmin(model.Email, model.Password, model.Name, server));
         await userRepository.Commit();
    }
}