using LanControl.Shared.ViewModels;

namespace LanControl.Core.Models;

public class Log(string userName, string action, DateTime date)
{
    public required string UserName { get; init; } = userName;
    public required string Action { get; init; } = action;
    public required DateTime Date { get; init; } = date;

    public DiscordWebhookViewModel ToDiscordWebhook()
    {
        var field = new DiscordWebhookEmbedFieldViewModel(action, $"Realizada por {UserName}\nEm: {date.ToString()}");
        var embed = new DiscordWebhookEmbedViewModel("Acao moderativa em Lan Control",  [field]);
        return new DiscordWebhookViewModel([embed]);
    }
} 