using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services.Interfaces;

public interface IAuthenticationService
{
    public Task Login(UserLoginViewModel loginInfo);
}