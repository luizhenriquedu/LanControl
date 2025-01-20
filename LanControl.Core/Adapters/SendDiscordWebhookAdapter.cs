using System.Net;
using System.Net.Http.Json;
using LanControl.Core.Adapters.Interfaces;
using LanControl.Shared.ViewModels;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;

namespace LanControl.Core.Adapters;
[Adapter<ISendDiscordWebhookAdapter>]
public class SendDiscordWebhookAdapter(HttpClient httpClient) : ISendDiscordWebhookAdapter
{
    private readonly HttpClient _httpClient = httpClient; 
    public async Task<SendDiscordWebhookAdapterResponseViewModel> Send(ToSendDiscordWebhookViewModel webhook)
    {
        
        var uri = new Uri(webhook.Url);
        var response = await _httpClient.PostAsJsonAsync(uri, webhook.Webhook);
        var resetAfter = Convert.ToInt32(response.Headers.GetValues("X-RateLimit-Reset-After").FirstOrDefault());
        var isRateLimited = response.StatusCode == HttpStatusCode.TooManyRequests;
        return new SendDiscordWebhookAdapterResponseViewModel(resetAfter * 1000, isRateLimited);
    }
}