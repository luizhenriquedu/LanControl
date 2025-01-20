using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services.Interfaces;

public interface IMessageQueueService
{
    public Task QueueMessageAsync(DiscordWebhookViewModel webhook, string url);
    public Task<ToSendDiscordWebhookViewModel?> DequeueMessageAsync();

    public bool HasPendingMessages();
}