using LanControl.Core.Models;

namespace LanControl.Core.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<User?> GetById(string id);
    public Task<User?> GetByEmail(string email);
    public Task<IEnumerable<User>> GetAll();

    public void Update(User user);
    public ValueTask<int> Commit();
    public ValueTask Add(User user);
    public ValueTask<bool> ExistsByEmail(string email);
    public ValueTask<bool> ExistsById(string id);
    
}