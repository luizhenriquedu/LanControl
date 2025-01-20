using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services.Interfaces;

public interface IServerService
{
    public ValueTask CreateServer(CreateServerViewModel model);
}