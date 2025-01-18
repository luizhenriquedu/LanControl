namespace LanControl.Core.Errors;

public class SendDiscordWebhookError(string message) : Exception(message);