namespace LanControl.Core.Services.Interfaces;

public interface IDiscordWebhookLogService
{
    public Task LogWebhook(string action, string userName, string date);
}