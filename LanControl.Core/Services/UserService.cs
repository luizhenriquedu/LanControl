using LanControl.Shared.Exceptions;
using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Services;

[Service<IUserService>]
public class UserService(IUserRepository userRepository,
    IDiscordWebhookLogService webhookLogService
    ) : IUserService
{
    public async Task<UserViewModel?> CreateAdmin(CreateAdminToServerViewModel model, string creatorId)
    {
        var creator = await userRepository.Get(x => x.Id == creatorId);
        if (creator is null) throw new AdminAuthenticationException("You are not authenticated");
        var server = creator.Server;
        
        if (await userRepository.Exists(x => x.Email == model.Email)) 
            throw new LoginException("This email is already in use");

        if (server.Preferences is null) return null;
        
        var user = User.CreateAdmin(model.Email, model.Password, model.Name, server);
        
        await userRepository.Add(user);
        await userRepository.Commit();
        await webhookLogService.LogWebhook("ADMIN ACCOUNT CREATED", creator, server.Preferences, model.Name);
        return user.ToViewModel();
    }
    
}