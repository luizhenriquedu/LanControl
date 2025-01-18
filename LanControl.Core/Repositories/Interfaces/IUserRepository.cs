using LanControl.Core.Models;

namespace LanControl.Core.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<User?> GetById(int id);
    public Task<User?> GetByEmail(string email);
    public Task<IEnumerable<User>> GetAll();
}