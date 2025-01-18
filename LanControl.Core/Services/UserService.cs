using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async ValueTask CreateAdmin(CreateUserViewModel model)
    {
        if (await userRepository.ExistsByEmail(model.Email)) return;
        await userRepository.Add(User.CreateAdmin());
        await userRepository.Commit();
    }
}