using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services.Interfaces;

public interface IUserService
{
    public Task<UserViewModel?> CreateAdmin(CreateAdminToServerViewModel model, string creatorId);
}