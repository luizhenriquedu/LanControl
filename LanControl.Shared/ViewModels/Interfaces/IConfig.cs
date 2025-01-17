namespace LanControl.Shared.ViewModels.Interfaces;

public interface IConfig
{
    public string DatabaseConnectionString { get; set; }
    public string DiscordWebhookLogUrl { get; set; }
}