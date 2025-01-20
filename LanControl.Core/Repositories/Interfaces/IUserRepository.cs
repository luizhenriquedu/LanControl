using System.Linq.Expressions;
using LanControl.Core.Models;
using TakasakiStudio.Lina.Database.Interfaces;

namespace LanControl.Core.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User, int>
{
    public Task<User?> GetUserIncludingServer(string id);
}