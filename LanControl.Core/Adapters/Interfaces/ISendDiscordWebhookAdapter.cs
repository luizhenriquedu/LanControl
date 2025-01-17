using LanControl.Shared.ViewModels;
namespace LanControl.Core.Adapters.Interfaces;

public interface ISendDiscordWebhookAdapter
{
    public Task Send(DiscordWebhookViewModel webhook);
}