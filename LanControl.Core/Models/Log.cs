using System.Diagnostics.CodeAnalysis;
using LanControl.Shared.ViewModels;

namespace LanControl.Core.Models;

public class Log
{
    public required string UserName { get; init; }
    public required string Action { get;  init; }
    public required DateTime Date { get;  init; }
    [SetsRequiredMembers]
    public Log(string userName, string action, DateTime date)
    {
        UserName = userName;
        Action = action;
        Date = date;
    }
    public DiscordWebhookViewModel ToDiscordWebhook()
    {
        var field = new DiscordWebhookEmbedFieldViewModel(Action, $"Realizada por {UserName}\nEm: {Date.ToString()}");
        var embed = new DiscordWebhookEmbedViewModel("Acao moderativa em Lan Control",  [field]);
        return new DiscordWebhookViewModel([embed]);
    }
} 