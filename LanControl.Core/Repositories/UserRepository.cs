using LanControl.Core.Database;
using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TakasakiStudio.Lina.AutoDependencyInjection.Attributes;
using TakasakiStudio.Lina.Database.Repositories;

namespace LanControl.Core.Repositories;
[Repository<IUserRepository>]
public class UserRepository(DbContext dbContext) : BaseRepository<User, int>(dbContext), IUserRepository;