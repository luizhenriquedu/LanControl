using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;
using TakasakiStudio.Lina.Database.Repositories;

namespace LanControl.Core.Repositories;
[Repository<IPreferencesRepository>]
public class PreferencesRepository(DbContext dbContext) : BaseRepository<Preferences, int>(dbContext), IPreferencesRepository
{
    public void Attach(Preferences preferences)
    {
        DbContext.Attach(preferences);
    }
}