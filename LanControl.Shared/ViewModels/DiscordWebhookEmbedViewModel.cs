namespace LanControl.Shared.ViewModels;
public record DiscordWebhookEmbedViewModel(string Title,
    IEnumerable<DiscordWebhookEmbedFieldViewModel> Fields,
    int Color = 65280);