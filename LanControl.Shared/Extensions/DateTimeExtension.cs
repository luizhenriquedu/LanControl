namespace LanControl.Shared.Extensions;

public static class DateTimeExtension
{
    public static DateTimeOffset ToBrasiliaDate(this DateTimeOffset dateTime)
    {
        return dateTime.ToOffset(TimeSpan.FromHours(-3));
    }
}