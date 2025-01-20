using LanControl.Shared.ViewModels;

namespace LanControl.Core.Models;

public class Log(string triggeredBy, string action, DateTimeOffset date, string? created)
{
    private  string TriggeredBy { get; init; } = triggeredBy;
    private string? Created { get; init; } = created;
    private  string Action { get; init; } = action;
    private  DateTimeOffset Date { get; init; } = date;

    public DiscordWebhookViewModel ToDiscordWebhook()
    {
        var field = new DiscordWebhookEmbedFieldViewModel(Action, $"Realizada por: {TriggeredBy}\nEm: {Date.ToString()}\n{(Created is null ? "":$"Created: {Created}")}");
        var embed = new DiscordWebhookEmbedViewModel("Acao moderativa em Lan Control",  [field]);
        return new DiscordWebhookViewModel([embed]);
    }
} 