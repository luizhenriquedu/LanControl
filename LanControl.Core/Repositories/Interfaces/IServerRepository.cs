using LanControl.Core.Models;
using TakasakiStudio.Lina.Database.Interfaces;

namespace LanControl.Core.Repositories.Interfaces;

public interface IServerRepository : IBaseRepository<Server, int>
{
    public void Attach(Server server);
}
