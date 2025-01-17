namespace LanControl.Shared.ViewModels.Interfaces;

public record IConfig
{
    public required string DatabaseConnectionString { get; set; }
}