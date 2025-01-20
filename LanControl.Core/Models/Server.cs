using System.Diagnostics.CodeAnalysis;
using TakasakiStudio.Lina.Database.Models;

namespace LanControl.Core.Models;

public class Server : BaseEntity<int>
{
    public  Preferences? Preferences { get; set; }
    public ICollection<User> Admins { get; set; } = [];
    
    public static Server TestServer()
    {
        ICollection<User> admins = [];
        return new Server
        {
            Admins = admins
        };
    }
}