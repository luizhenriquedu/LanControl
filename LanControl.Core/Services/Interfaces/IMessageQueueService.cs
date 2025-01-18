using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services.Interfaces;

public interface IMessageQueueService
{
    public Task QueueMessageAsync(DiscordWebhookViewModel webhook);
    public Task<DiscordWebhookViewModel?> DequeueMessageAsync();

    public bool HasPendingMessages();
}