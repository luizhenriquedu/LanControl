using System.Net.Http.Json;
using LanControl.Core.Adapters.Interfaces;
using LanControl.Core.Errors;
using LanControl.Shared.ViewModels;
using LanControl.Shared.ViewModels.Interfaces;

namespace LanControl.Core.Adapters;

public class SendDiscordWebhookAdapter(IConfig config, HttpClient httpClient) : ISendDiscordWebhookAdapter
{
    private readonly HttpClient _httpClient = httpClient; 
    public async Task Send(DiscordWebhookViewModel webhook)
    {
        if (config.DiscordWebhookLogUrl is null) 
            throw new SendDiscordWebhookError("DISCORD_WEBHOOK_URL_NOT_FOUND");
        var uri = new Uri(config.DiscordWebhookLogUrl);
        var response = await _httpClient.PostAsJsonAsync<DiscordWebhookViewModel>(uri, webhook);
    }
}