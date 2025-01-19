using System.Net;
using System.Net.Http.Json;
using LanControl.Core.Adapters.Interfaces;
using LanControl.Shared.Exceptions;
using LanControl.Shared.ViewModels;
using LanControl.Shared.ViewModels.Interfaces;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Adapters;
[Adapter<ISendDiscordWebhookAdapter>]
public class SendDiscordWebhookAdapter(HttpClient httpClient, IConfig config) : ISendDiscordWebhookAdapter
{
    private readonly HttpClient _httpClient = httpClient; 
    public async Task<SendDiscordWebhookAdapterResponseViewModel> Send(DiscordWebhookViewModel webhook)
    {
        if (config.DiscordWebhookLogUrl is null) 
            throw new SendDiscordWebhookException("DISCORD_WEBHOOK_URL_NOT_FOUND");
        var uri = new Uri(config.DiscordWebhookLogUrl);
        var response = await _httpClient.PostAsJsonAsync(uri, webhook);
        var resetAfter = Convert.ToInt32(response.Headers.GetValues("X-RateLimit-Reset-After").FirstOrDefault());
        var isRateLimited = response.StatusCode == HttpStatusCode.TooManyRequests;
        return new SendDiscordWebhookAdapterResponseViewModel(resetAfter * 1000, isRateLimited);
    }
}