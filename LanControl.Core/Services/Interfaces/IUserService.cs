using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services.Interfaces;

public interface IUserService
{
    public ValueTask CreateAdmin(CreateUserViewModel model, string creatorId);
    public ValueTask CreateTestAdmin(CreateUserViewModel model);
}