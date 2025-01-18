using LanControl.Core.Repositories.Interfaces;
using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services;

public class AuthenticationService(IUserRepository userRepository) : IAuthenticationService
{
    public async Task<UserViewModel?> LoginAsync(UserLoginViewModel model)
    {
        var user = await userRepository.GetByEmail(model.Email);
        if(user is not null && user.IsValidPassword(model.Password)) return user.ToViewModel();
        return null;
    }
}