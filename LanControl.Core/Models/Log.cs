namespace LanControl.Core.Models;

public class Log(string userName, string action, DateTime date)
{
    public required string UserName { get; set; } = userName;
    public required string Action { get; set; } = action;
    public required DateTime Date { get; set; } = date;
} 