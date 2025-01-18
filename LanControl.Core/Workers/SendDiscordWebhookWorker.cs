using LanControl.Core.Adapters.Interfaces;
using LanControl.Core.Services.Interfaces;
using Microsoft.Extensions.Hosting;

namespace LanControl.Core.Workers;

public class SendDiscordWebhookWorker(ISendDiscordWebhookAdapter adapter, IMessageQueueService messageQueueService) : BackgroundService
{
    private readonly ISendDiscordWebhookAdapter _adapter = adapter;
    private readonly IMessageQueueService _messageQueueService = messageQueueService;
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (!_messageQueueService.HasPendingMessages()) return;
                var message = await _messageQueueService.DequeueMessageAsync();
                if (message is null) return;
                var response = await _adapter.Send(message);
                if (!response.IsRateLimited) return;
                await Task.Delay(response.ResetAfter, stoppingToken);
                await _adapter.Send(message);
        }
        await Task.Delay(5000, stoppingToken);
    }
}