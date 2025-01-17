namespace LanControl.Shared.ViewModels;
public record DiscordWebhookEmbedViewModel(int Color, IEnumerable<DiscordWebhookEmbedFieldViewModel> Fields);