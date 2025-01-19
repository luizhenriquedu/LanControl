using System.Diagnostics.CodeAnalysis;
using LanControl.Shared.ViewModels;

namespace LanControl.Core.Models;

public class Log
{
    public required string TriggeredBy { get; init; }
    public string? Created { get; init; }
    public required string Action { get;  init; }
    public required DateTime Date { get;  init; }
    [SetsRequiredMembers]
    public Log(string triggeredBy, string action, DateTime date, string? created)
    {
        TriggeredBy = triggeredBy;
        Action = action;
        Date = date;
        Created = created;
    }
    public DiscordWebhookViewModel ToDiscordWebhook()
    {
        var field = new DiscordWebhookEmbedFieldViewModel(Action, $"Realizada por: {TriggeredBy}\nEm: {Date.ToString()}\n{(Created is null ? "":$"Created: {Created}")}");
        var embed = new DiscordWebhookEmbedViewModel("Acao moderativa em Lan Control",  [field]);
        return new DiscordWebhookViewModel([embed]);
    }
} 