using LanControl.Shared.ViewModels;
namespace LanControl.Core.Adapters.Interfaces;

public interface ISendDiscordWebhookAdapter
{
    public Task<SendDiscordWebhookAdapterResponseViewModel> Send(DiscordWebhookViewModel webhook);
}