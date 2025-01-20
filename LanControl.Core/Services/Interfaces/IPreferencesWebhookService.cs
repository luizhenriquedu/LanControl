using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services.Interfaces;

public interface IPreferencesWebhookService
{
    public ValueTask UpdateWebhookUrl(string url, string userId, string userName);
    public ValueTask ToggleWebhook(string userId);
}