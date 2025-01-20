using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services.Interfaces;

public interface IPreferencesService
{
    public ValueTask UpdateWebhookUrl(string url, string userId, string userName);
    public ValueTask UpdateEnabledWebhook(string userId);
}