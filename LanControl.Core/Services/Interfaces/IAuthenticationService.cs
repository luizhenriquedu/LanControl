using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services.Interfaces;

public interface IAuthenticationService
{
    public Task<UserViewModel?> LoginAsync(UserLoginViewModel model);
}