using System.Text.Json;
using LanControl.Shared.ViewModels;

namespace LanControl.Extensions;

public static class SessionExtension
{
    private const string UserSessionName = "User";

    public static async ValueTask SetUser(this ISession session, UserViewModel user)
    {
        await session.Set(UserSessionName, user);
    }

    public static UserViewModel? GetUser(this ISession session)
    {
        return session.Get<UserViewModel>(UserSessionName);
    }
    private static async ValueTask Set<T>(this ISession session, string key, T value) where T : class
    {
        var data = JsonSerializer.Serialize(value);
        session.SetString(key, data);
        await session.CommitAsync();
    }

    private static T? Get<T>(this ISession session, string key) where T : class
    {
        var data = session.GetString(key);
        return data is null ? null : JsonSerializer.Deserialize<T>(data);
    }
}