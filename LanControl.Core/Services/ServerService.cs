using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Services;
[Service<IServerService>]
public class ServerService(
    IServerRepository serverRepository,
    IUserRepository userRepository,
    IPreferencesRepository preferencesRepository) : IServerService
{
    public async Task<UserViewModel> CreateServer(CreateServerViewModel model)
    {
        var server = Server.CreateServer();
        var preferences = server.Preferences;
        var user = User.CreateAdmin(model.Email, model.Password, model.Name, server);
        
        server.Admins.Add(user);
        
        await serverRepository.Add(server);
        await userRepository.Add(user);
        await preferencesRepository.Add(preferences);
        
        await serverRepository.Commit();
        await preferencesRepository.Commit();
        await userRepository.Commit();

        return user.ToViewModel();
    }
}