using LanControl.Core.Models;
using TakasakiStudio.Lina.Database.Interfaces;

namespace LanControl.Core.Repositories.Interfaces;

public interface IPreferencesRepository : IBaseRepository<Preferences, int>
{
    public void Attach(Preferences preferences);
}