using System.Diagnostics.CodeAnalysis;
using TakasakiStudio.Lina.Database.Models;

namespace LanControl.Core.Models;

public class Server : BaseEntity<int>
{
    public required Preferences Preferences { get; set; }
    public ICollection<User> Admins { get; set; } = new List<User>();

    [SetsRequiredMembers]
    private Server()
    {
        var preferences = Preferences.CreatePreferences(this.Id, this);
        Preferences = preferences;
    }
    public static Server CreateServer()
    {
        var server = new Server()
        {
            Admins = []
        };
        return server;
    }
}