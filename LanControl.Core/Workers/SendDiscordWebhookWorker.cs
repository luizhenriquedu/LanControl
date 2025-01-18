using LanControl.Core.Adapters.Interfaces;
using Microsoft.Extensions.Hosting;

namespace LanControl.Core.Workers;

public class SendDiscordWebhookWorker(ISendDiscordWebhookAdapter adapter) : BackgroundService
{
    private readonly ISendDiscordWebhookAdapter _adapter = adapter;
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            
        }
        await Task.Delay(1000, stoppingToken);
    }
}