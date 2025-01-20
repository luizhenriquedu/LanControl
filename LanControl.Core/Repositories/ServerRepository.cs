using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;
using TakasakiStudio.Lina.Database.Repositories;

namespace LanControl.Core.Repositories;
[Repository<IServerRepository>]
public class ServerRepository(DbContext dbContext) : BaseRepository<Server, int>(dbContext), IServerRepository
{
    
}