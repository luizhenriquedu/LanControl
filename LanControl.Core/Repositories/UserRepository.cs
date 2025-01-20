
using System.Linq.Expressions;
using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;
using TakasakiStudio.Lina.Database.Interfaces;
using TakasakiStudio.Lina.Database.Models;
using TakasakiStudio.Lina.Database.Repositories;

namespace LanControl.Core.Repositories;

[Repository<IUserRepository>]
public class UserRepository(DbContext dbContext) : BaseRepository<User, int>(dbContext), IUserRepository
{
    public async Task<User?> GetUserIncludingServer(string id)
    {
        return await DbContext.Set<User>().Include(x => x.Server).
            Include(x => x.Server.Preferences)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}