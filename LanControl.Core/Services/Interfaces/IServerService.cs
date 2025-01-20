using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services.Interfaces;

public interface IServerService
{
    public Task<UserViewModel> CreateServer(CreateServerViewModel model);
}