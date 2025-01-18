using LanControl.Core.Services.Interfaces;
using LanControl.Shared.ViewModels;

namespace LanControl.Core.Services;

public class MessageQueueService : IMessageQueueService
{
    private readonly Queue<DiscordWebhookViewModel> _queue = new Queue<DiscordWebhookViewModel>();

    public Task QueueMessageAsync(DiscordWebhookViewModel webhook)
    {
        _queue.Enqueue(webhook);
        return Task.CompletedTask;
    }

    public Task<DiscordWebhookViewModel?> DequeueMessageAsync()
    {
        return _queue.Count != 0 ? Task.FromResult<DiscordWebhookViewModel?>(_queue.Dequeue()) : 
            Task.FromResult<DiscordWebhookViewModel?>(null);
    }
    public bool HasPendingMessages() => _queue.Count != 0;
}