using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services;

public class MessageQueueService : IMessageQueueService
{
    private readonly Queue<ToSendDiscordWebhookViewModel> _queue = new Queue<ToSendDiscordWebhookViewModel>();

    public Task QueueMessageAsync(DiscordWebhookViewModel webhook, string url)
    {
        _queue.Enqueue(new ToSendDiscordWebhookViewModel(webhook, url));
        return Task.CompletedTask;
    }

    public Task<ToSendDiscordWebhookViewModel?> DequeueMessageAsync()
    {
        return _queue.Count != 0 ? Task.FromResult<ToSendDiscordWebhookViewModel?>(_queue.Dequeue()) : 
            Task.FromResult<ToSendDiscordWebhookViewModel?>(null);
    }
    public bool HasPendingMessages() => _queue.Count != 0;
}